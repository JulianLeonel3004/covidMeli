using Model.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MasterModel
{
    public class Result:Generic
    {
        public const int INFECTED = 1;
        public const int HELTHY = 2;
        public const int INMUNE = 3;
        public Result() { }
        public Result(string description) 
        {
            this.Description = description;
        }

        public Result(int id, string description)
        {
            this.Id = Id;
            this.Description = description;
        }
    }
}
