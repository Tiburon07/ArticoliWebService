using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Controller
{
    [ApiController]
    [Route("api/saluti")]
    public class SalutiController
    {
        [HttpGet]
        public string GetSaluti()
        {
            return "\"Saluti, sono la tua prima web api creata in C#\"";
        }

        [HttpGet("{Nome}")]
        public string GetSaluti2(string Nome)
        {
            try
            {
                if (Nome == "Marco")
                    throw new Exception("\"Errore: L'utente Marco è disabilitato\"");
                else return $"\"Saluti, {Nome} sono la tua prima web api creata in C#\"";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

    }
}
