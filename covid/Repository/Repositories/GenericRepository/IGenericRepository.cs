using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories.GenericRepository
{
    public interface IGenericRepository<T> where T:class
    {
        IList<T> getAll();
        T getByID(int id);
        void insert(T obj);
        T getByDescription(string description);
        void insertList(IList<T> objList);

    }
}
