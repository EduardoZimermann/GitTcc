using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Marca : UserControls
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TipoVeiculoFk")] 
        public TipoVeiculo TipoVeiculo { get; set; }

        [CustomMarcaValid(1)]
        public int TipoVeiculoFk { get; set; }

        [CustomMarcaValid(2)]
        public int CodigoMarca { get; set; }

        [CustomMarcaValid(3)]
        public string Descricao { get; set; }
    }
}