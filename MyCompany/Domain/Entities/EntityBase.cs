using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            DateAdded = DateTime.UtcNow;//при создании обьекта класса заносим время в переменную
        }


        [Required]//анотация Required - значение для этого свойства обязательно
        public Guid Id { get; set; }//тип Guid  - статиеский уникальныйидентификатор

        //Для каждого поля ввода указывается метка типа<label asp-for="Title"></label>.
        //Текст эта метка будет брать из атрибута Display(если он указан) для этого свойства.

        [Display(Name = "Название(Заголовок)")]
        public virtual string Title { get; set; }//ServiceItem//TextField


        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }//ServiceItem


        [Display(Name = "Полное описание")]//ServiceItem//TextField
        public virtual string Text { get; set; }


        [Display(Name = "Титульная картинка")]
        public virtual string TitleImagePath { get; set; }


        [Display(Name = "SEO метатег Title")]
        public string MetaTitle { get; set; }


        [Display(Name = "SEO метатег Description")]
        public string MetaDescription { get; set; }


        [Display(Name = "SEO метатег Keywords")]
        public string MetaKeywords { get; set; }

        //Атрибут DataType позволяет предоставлять среде выполнения информацию об использовании свойства.
        //Cвойство DateAdded с помощью атрибута мы указываем системе, что это свойство предназначено для хранения времени.
        [DataType(DataType.Time)]
        public DateTime DateAdded { get; set; }
    } 
}
