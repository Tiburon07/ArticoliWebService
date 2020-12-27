using ArticoliWebService.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArticoliWebService.test
{
    class DBContextMocker
    {
        public static AlphaShopDBContext alphaShopDBContext()
        {
            var connectionString = "Data Source=localhost;Initial Catalog=AlphaShop;Integrated Security=False;User ID=sa;Password=123Stella";
            var options = new DbContextOptionsBuilder<AlphaShopDBContext>()
                .UseSqlServer(connectionString)
                .Options;
            var dbContext = new AlphaShopDBContext(options);
            return dbContext;
        }
    }
}
