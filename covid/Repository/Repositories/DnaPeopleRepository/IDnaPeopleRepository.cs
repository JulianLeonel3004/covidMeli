using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories.DnaPeopleRepository
{
    public interface IDnaPeopleRepository
    {
        IList<DnaPeople> getAll();
        IList<DnaPeople> getByIdPeople(int idPeople);
        IList<DnaPeople> getByIdDna(int idDna);
        void insert(DnaPeople dnaPeople);
        void insertList(IList<DnaPeople> dnaPeople);
    }
}
