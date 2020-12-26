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

        public async Task<Articoli> SelArticoloByCodice(string Code)
        {
            return await this.alphaShopDBContext.Articoli
                    .Where(a => a.CodArt.Equals(Code))
                    .Include(a => a.barcode)
                    .Include(a => a.FamAssort)
                    .Include(a => a.Iva)
                    .FirstOrDefaultAsync();
        }

        public async Task<Articoli> SelArticoliByEan(string Ean)
        {
            return await this.alphaShopDBContext.Barcode
                    .Include(a => a.articolo.barcode)
                    .Include(a => a.articolo.FamAssort)
                    .Include(a => a.articolo.Iva)
                    .Where(b => b.BarCode.Equals(Ean))
                    .Select(a => a.articolo)
                    .FirstOrDefaultAsync();
        }

        public bool ArticoloExists(string Code)
        {
            return this.alphaShopDBContext.Articoli
                    .Any(a => a.CodArt == Code);
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
