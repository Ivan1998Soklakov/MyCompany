using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemsRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteServiceItem(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id=id});
            //context.ServiceItems.Remove(context.ServiceItems.FirstOrDefault(x=>x.Id==id));
            context.SaveChanges();
        }

        public ServiceItem GetServiceItemById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x=>x.Id==id);
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                //Так как объект получен в одном контексте, а изменяется для другого контекста, который его не отслеживает.
                //В итоге изменения не сохранятся. Чтобы изменения сохранились, нам явным образом надо установить
                //для его состояния значение EntityState.Added
                context.Entry(entity).State = EntityState.Added;
                //context.ServiceItems.Add(entity);
            }
            else
            {
                //Так как объект получен в одном контексте, а изменяется для другого контекста, который его не отслеживает.
                //В итоге изменения не сохранятся. Чтобы изменения сохранились, нам явным образом надо установить
                //для его состояния значение EntityState.Modified
                context.Entry(entity).State = EntityState.Modified;
                //context.ServiceItems.Add(entity);
            }
            context.SaveChanges();
        }
    }
}
