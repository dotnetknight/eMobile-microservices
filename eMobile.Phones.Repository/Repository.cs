using eMobile.Phones.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eMobile.Phones.Repository
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly PhonesContext phonesContext;
        private readonly DbSet<T> entities;

        public Repository(PhonesContext phonesContext)
        {
            this.phonesContext = phonesContext;
            entities = phonesContext.Set<T>();
            this.phonesContext.Database.BeginTransactionAsync();
        }

        public List<T> GetAll()
        {
            return entities.ToList();
        }

        public T Get(Guid id)
        {
            return entities.SingleOrDefault(s => s.Id == id);
        }

        public void Insert(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Add(entity);
            SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            SaveChanges();
        }

        public void RollbackTransaction()
        {
            phonesContext.Database.RollbackTransactionAsync();
        }

        public void CommitTransaction()
        {
            phonesContext.Database.CommitTransactionAsync();
        }

        public void SaveChanges()
        {
            phonesContext.SaveChanges();
        }
    }
}
