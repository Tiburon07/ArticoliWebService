using ArticoliWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Services
{
    interface IArticoliRepository
    {
        ICollection<Articoli> SelArticoliByDescrizione(string Descrizione);
        Articoli SelArticoloByCodice(string Code);
        Articoli SelArtocpòpByEan(string Ean);

        bool InsArticoli(Articoli articolo);
        bool UpArticoli(Articoli articolo);
        bool DelArticoli(Articoli articolo);
        bool Salva();
        bool ArticoloExists(string Code);
    }
}
