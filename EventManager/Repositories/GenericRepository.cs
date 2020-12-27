using EventManager.Interfaces;
using EventManager.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EventManager.Repositories
{
    public class GenericRepository<T> : IGenericInterface<T> where T : class
    {

        private EventManagerDbEntities db = null;
        private DbSet<T> table = null;

        public GenericRepository()
        {
            this.db = new EventManagerDbEntities();
            table = db.Set<T>();
        }

        public GenericRepository(EventManagerDbEntities db)
        {
            this.db = db;
            table = db.Set<T>();
        }

        public IEnumerable<T> SelectAll()
        {
            try
            {
                return table.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public T GetById(object id)
        {
            try
            {
                return table.Find(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Insert(T obj)
        {
            try
            {
                table.Add(obj);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                table.Attach(obj);
                db.Entry(obj).State = EntityState.Modified;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Delete(object id)
        {
            try
            {
                T entityToDelete = table.Find(id);
                if (db.Entry(entityToDelete).State == EntityState.Detached)
                {
                    table.Attach(entityToDelete);
                }
                table.Remove(entityToDelete);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            try
            {
                if (!this.disposed)
                {
                    if (disposing)
                    {
                        db.Dispose();
                    }
                }
                this.disposed = true;
            }
            catch (Exception ex)
            {

            }
        }

        public void Dispose()
        {
            try
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }
            catch (Exception ex)
            {

            }
        }

    }
}