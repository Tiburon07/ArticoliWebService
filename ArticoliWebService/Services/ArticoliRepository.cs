using ArticoliWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        public bool ArticoloExists(string Code)
        {
            throw new NotImplementedException();

        }

        public bool DelArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }

        public bool InsArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }

        public bool Salva()
        {
            throw new NotImplementedException();
        }

        public ICollection<Articoli> SelArticoliByDescrizione(string Descrizione)
        {
            throw new NotImplementedException();
        }

        public Articoli SelArticoloByCodice(string Code)
        {
            throw new NotImplementedException();
        }

        public Articoli SelArtocpòpByEan(string Ean)
        {
            throw new NotImplementedException();
        }

        public bool UpArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }
    }
}
