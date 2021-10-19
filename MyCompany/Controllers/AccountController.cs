using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyCompany.Models;
using System.Threading.Tasks;

namespace MyCompany.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if(ModelState.IsValid)//проверка коректны ли данные из формы
            {
                //ищет пользователя по нику
                IdentityUser user = await userManager.FindByNameAsync(model.UserName);
                if (user != null)
                {
                    //для выхода из сайта
                    await signInManager.SignOutAsync();
                    //пытаемся войти по паролю, user - пользователь который был найден, пароль, флаг "запомни меня", false - заблокировать пользователя при неудачной попытке входа
                    Microsoft.AspNetCore.Identity.SignInResult result = await signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,false);
                    if (result.Succeeded)
                    { 
                        //переадресация на Url адресс, если значение не было заданно тогда переадресация на главную страницу
                        return Redirect(returnUrl ?? "/");
                    }
                }
                else
                {
                    //nameof - создает имя, тип или элемент переменной в качестве строковой константы
                    //если пользователя не существует тогда добавляем модели LoginViewModel.UserName ошибку "Неверный логин или пароль"
                    ModelState.AddModelError(nameof(LoginViewModel.UserName), "Неверный логин или пароль");
                }
            }
            return View(model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
