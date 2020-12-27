using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Dtos
{
    public class ErrMsg
    {
        public string messaggio { get; set; }
        public string errore { get; set; }
        public ErrMsg(string messaggio, string errore)
        {
            this.messaggio = messaggio;
            this.errore = errore;
        }
    }
}
