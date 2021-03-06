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
            phonesContext.SaveChanges();
        }

        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            phonesContext.SaveChanges();
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            entities.Remove(entity);
            phonesContext.SaveChanges();
        }

        public void SaveChanges()
        {
            phonesContext.SaveChanges();
        }
    }
}
