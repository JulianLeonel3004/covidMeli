using Model.Generics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Model.MasterModel
{
    public class Country:Generic
    {
        public Country() { }
        public Country(string description)
        {
            this.Description = description;
        }
    }
}
