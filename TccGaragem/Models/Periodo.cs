using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccGaragem.Models
{
    public class Periodo
    {
        [Key]
        public int Id { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public int CodigoPeriodo { get; set; }
        public DateTime DataInicial { get; set; } = DateTime.Now;
        public DateTime DataFinal { get; set; } = DateTime.Now;
    }
}