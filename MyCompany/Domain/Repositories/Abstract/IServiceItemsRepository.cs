using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IServiceItemsRepository
    {
        IQueryable<ServiceItem> GetServiceItems();//выборка всех услуг
        ServiceItem GetServiceItemById(Guid id);//выбрать услугу по идентификатору
        void SaveServiceItem(ServiceItem entity);//сохранить новую или изменения услугу
        void DeleteServiceItem(Guid id);//удалить услугу
    }
}
