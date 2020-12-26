using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Models
{
    public class Ean
    {
        public string CodArt { get; set; }
        [Key]
        [StringLength(13, MinimumLength = 8, ErrorMessage = "Il Barcode deve avere da 0 a 13 cifre")]
        public string BarCode { get; set; }
        public string IdTipoArt { get; set; }

        //proprietà di collegamento classi models
        public virtual Articoli articolo { get; set; }
    }
}
