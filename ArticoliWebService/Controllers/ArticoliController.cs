﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Dtos;
using ArticoliWebService.Models;
using ArticoliWebService.Services;
using Microsoft.AspNetCore.Mvc;

namespace ArticoliWebService.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/articoli")]
    public class ArticoliController : Controller
    {
        private readonly IArticoliRepository articoliRepository;

        public ArticoliController(IArticoliRepository articoliRepository)
        {
            this.articoliRepository = articoliRepository;
        }

        [HttpGet("cerca/descrizione/{filter}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ArticoliDto>))]
        public async Task<IActionResult> GetArticoliByDesc(string filter)
        {
            var articoliDto = new List<ArticoliDto>();

            var articoli = await this.articoliRepository.SelArticoliByDescrizione(filter);
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            if (articoli.Count == 0)
                return NotFound(new ErrMsg($"Non è stato trovato alcun articolo per il filtro {filter}", this.HttpContext.Response.StatusCode.ToString()));

            foreach (var articolo in articoli)
                articoliDto.Add(this.GetArticoliDto(articolo));

            return Ok(articoliDto);

        }

        [HttpGet("cerca/codice/{CodArt}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticoliDto))]
        public async Task<IActionResult> GetArticoliByCode(string CodArt)
        {
            if(!this.articoliRepository.ArticoloExists(CodArt))
                return NotFound(new ErrMsg($"Non è stato trovato l'articolo con il codice {CodArt}", this.HttpContext.Response.StatusCode.ToString()));

            var articolo = await this.articoliRepository.SelArticoloByCodice(CodArt);

            return Ok(GetArticoliDto(articolo));
        }

        [HttpGet("cerca/ean/{Ean}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(ArticoliDto))]
        public async Task<IActionResult> GetArticoloByEan(string Ean)
        {
            var articolo = await this.articoliRepository.SelArticoliByEan(Ean);

            if(articolo == null)
                return NotFound(new ErrMsg($"Non è stato trovato l'articolo con il barcode {Ean}", this.HttpContext.Response.StatusCode.ToString()));

            return Ok(GetArticoliDto(articolo));
        }

        private ArticoliDto GetArticoliDto(Articoli articolo)
        {
            Console.WriteLine($"Codice: {articolo.CodArt}");
            var barcodeDto = new List<BarcodeDto>();

            foreach (var ean in articolo.barcode)
            {
                barcodeDto.Add(new BarcodeDto
                {
                    Barcode = ean.BarCode,
                    Tipo = ean.CodArt
                });
            }

            var articoliDto = new ArticoliDto
            {
                CodArt = articolo.CodArt,
                Descrizione = articolo.Descrizione,
                Um = articolo.Um,
                CodStat = articolo.CodStat,
                PzCart = articolo.PzCart,
                PesoNetto = articolo.PesoNetto,
                DataCreazione = articolo.DataCreazione,
                Ean = barcodeDto,
                Iva = new IvaDto(articolo.Iva.Descrizione, articolo.Iva.Aliquota),
                Categoria = (articolo.FamAssort != null) ? articolo.FamAssort.Descrizione : "Non disponibile",
                IdStatoArt = articolo.IdStatoArt
            };

            return articoliDto;
        }
    }
}
