using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocacaoDeGaragens.Models
{
    public class PeriodoLocacao
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public Veiculo Tipo { get; set; }
        [ForeignKey("Tipo")]
        public int TipoFk { get; set; }
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}