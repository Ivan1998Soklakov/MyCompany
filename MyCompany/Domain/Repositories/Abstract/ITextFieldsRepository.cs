using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface ITextFieldsRepository
    {
        IQueryable<TextField> GetTextFields();//выборка всех текстовых полей
        TextField GetTextFieldById(Guid id);//выбрать текстовое поле по идентификатору
        TextField GetTextFieldByCodeWord(string codeWord);//выбрать текстовое поле по кодовому слову
        void SaveTextField(TextField entity);//сохранить изменения текстового поля
        void DeleteTextField(Guid id);//удалить текстовое поле
    }
}
