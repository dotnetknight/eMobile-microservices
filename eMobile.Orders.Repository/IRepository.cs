using eMobile.Orders.Domain;
using System;
using System.Collections.Generic;

namespace eMobile.Orders.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        List<T> GetAll();
        T Get(Guid id);
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SaveChanges();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
