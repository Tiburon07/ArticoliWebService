using ArticoliWebService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Services
{
    public interface IArticoliRepository
    {
        Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione);
        Task<Articoli> SelArticoloByCodice(string Code);
        Task<Articoli> SelArticoliByEan(string Ean);

        bool InsArticoli(Articoli articolo);
        bool UpArticoli(Articoli articolo);
        bool DelArticoli(Articoli articolo);
        bool Salva();
        bool ArticoloExists(string Code);
    }
}
