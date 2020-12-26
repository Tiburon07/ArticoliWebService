using ArticoliWebService.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ArticoliWebService.test
{
    public class SalutiControllerTest
    {
        readonly SalutiController salutiController;

        public SalutiControllerTest()
        {
            salutiController = new SalutiController();
        }

        [Fact]
        public void TestGetSaluti()
        {
            string retVal = salutiController.GetSaluti();
            Assert.Equal("\"Saluti, sono la tua prima web api creata in C#\"",retVal);

        }

        [Fact]
        public void TestGetSaluti2()
        {
            string retVal = salutiController.GetSaluti2("Tiburon");
            Assert.Equal("\"Saluti, Tiburon sono la tua prima web api creata in C#\"", retVal);

        }

        [Fact]
        public void TestGetSalutiErr()
        {
            string retVal = salutiController.GetSaluti2("Marco");
            Assert.Equal("\"Saluti, Marco sono la tua prima web api creata in C#\"", retVal);

        }
    }
}
