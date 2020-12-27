using ArticoliWebService.Controllers;
using ArticoliWebService.Dtos;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ArticoliWebService.test
{
    public class ArticoliControllerTest
    {
        [Fact]
        public async Task TestGetArticoliByCode()
        {
            string CodArt = "000992601";
            
            //Arrange
            var dbContext = DBContextMocker.alphaShopDBContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));
            
            //Act
            var response = await controller.GetArticoliByCode(CodArt) as ObjectResult;
            var value = response.Value as ArticoliDto;

            dbContext.Dispose();

            //Assert
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(value);
            Assert.Equal(CodArt, value.CodArt);

        }

        [Fact]
        public async Task TestErrGetArticoliByCode()
        {
            string CodArt = "0009926010";

            //Arrange
            var dbContext = DBContextMocker.alphaShopDBContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

            //Act
            var response = await controller.GetArticoliByCode(CodArt) as ObjectResult;
            var value = response.Value as ArticoliDto;

            dbContext.Dispose();

            //Assert
            Assert.Equal(404, response.StatusCode);
            Assert.Null(value);
            Assert.Equal($"Non è stato trovato l'articolo con il codice 0009926010", response.Value);

        }

        [Fact]
        public async Task TestSelArticoliDescrizione()
        {
            string Descrizione = "ACQUA ROCCHETTA";

            //Arrange
            var dbContext = DBContextMocker.alphaShopDBContext();
            var controller = new ArticoliController(new ArticoliRepository(dbContext));

            //Act
            var response = await controller.GetArticoliByDesc(Descrizione) as ObjectResult;
            var value = response.Value as ICollection<ArticoliDto>;

            dbContext.Dispose();

            //Assert
            Assert.Equal(200, response.StatusCode);
            Assert.NotNull(value);
            Assert.Equal(3, value.Count);
            Assert.Equal($"002001201",value.FirstOrDefault().CodArt);
        }
    }
}
