﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ArticoliWebService.Models
{
    public class FamAssort
    {
        [Key]
        public int Id { get; set; }
        public string Descrizione { get; set; }

        //proprietà di collegamento classi models
        public virtual ICollection<Articoli> Articoli { get; set; }

    }
}
