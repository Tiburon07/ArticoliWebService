using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDBContext alphaShopDBContext;
        public ArticoliRepository(AlphaShopDBContext alphaShopDBContext)
        {
            this.alphaShopDBContext = alphaShopDBContext;
        }

        public async Task<ICollection<Articoli>> SelArticoliByDescrizione(string Descrizione)
        {
            return await this.alphaShopDBContext.Articoli
                    .Where(a => a.Descrizione.Contains(Descrizione))
                    .OrderBy(a => a.Descrizione)
                    .ToListAsync();
        }

        public Articoli SelArticoloByCodice(string Code)
        {
            return this.alphaShopDBContext.Articoli
                    .Where(a => a.CodArt.Equals(Code))
                    .FirstOrDefault();
        }

        public Articoli SelArticoliByEan(string Ean)
        {
            return this.alphaShopDBContext.Barcode
                    .Where(b => b.BarCode.Equals(Ean))
                    .Select(a => a.articolo)
                    .FirstOrDefault();
        }

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

        public bool UpArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }
    }
}
