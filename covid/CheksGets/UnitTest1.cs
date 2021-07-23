using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services.Implementations;
using Services.Interfaces;
using System;

namespace CheksGets
{
    [TestClass]
    public class UnitTest1
    {
        private IPeopleService peopleService;

        public UnitTest1(IPeopleService peopleService)
        {
            this.peopleService = peopleService;
        }

        [TestMethod]
        public void TestMethod1()
        {
            try
            {
                peopleService.GetAllAsync();
                Equals(true);
            }catch(Exception e)
            {
                Equals(false);
            }

           
            
        }
    }
}
