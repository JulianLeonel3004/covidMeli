using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class DnaPeople
    {
        public int Id { get; set; }
        public int IdDna { get; set; }
        public int IdPeople { get; set; }
        public DnaPeople(int idDna, int idPeople)
        {
            IdDna = idDna;
            IdPeople = idPeople;
        }

    }
}
