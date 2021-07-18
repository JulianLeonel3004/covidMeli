using Model.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MasterModel
{
    public class Result:Generic
    {
        public Result() { }
        public Result(string description) 
        {
            this.Description = description;
        }
    }
}
