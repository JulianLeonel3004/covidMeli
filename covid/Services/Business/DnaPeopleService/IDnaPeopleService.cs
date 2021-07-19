using Model;
using Model.People;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Business.DnaPeopleService
{
    public interface IDnaPeopleService
    {
        void insertDnaPeople(Person person);
        IList<DnaPeople> getByDna(int id);
        IList<DnaPeople> getByPeople(int id);
    }
}
