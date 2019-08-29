using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Periodo : UserControls
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TipoVeiculoFk")]
        public TipoVeiculo TipoVeiculo { get; set; }

        [CustomPeriodoValid(1)]
        public int TipoVeiculoFk { get; set; }

        [CustomPeriodoValid(2)]
        public int CodigoPeriodo { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}