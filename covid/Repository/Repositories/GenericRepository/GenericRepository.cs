using Model.Generics;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Repositories.GenericRepository
{
    public class GenericRepository<T> : IGenericRepository<T> where T:Generic
    {
        protected AplicationDbContext context;

        public GenericRepository(AplicationDbContext context)
        {
            this.context = context;
        }

        public virtual IList<T> getAll()
        {
            return context.Set<T>().ToList();
        }

        public virtual T getByDescription(string description)
        {
            try
            {
                return context.Set<T>().Where(x => x.Description.Equals(description)).Single();
            
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public virtual T getByID(int id)
        {
            try
            {
                return context.Set<T>().Where(x => x.Id == id).Single();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public virtual void insert(T obj)
        {
            context.Set<T>().Add(obj);
            context.SaveChanges();
        }

        public void insertList(IList<T> objList)
        {
            foreach (T obj in objList)
            {
                context.Set<T>().Add(obj);
            }

            context.SaveChanges();
        }
    }
}
