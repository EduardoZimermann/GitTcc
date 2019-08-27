using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class Marca : UserControls
    {
        [Key]
        public int Id { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public int CodigoMarca { get; set; }
        public string Descricao { get; set; }
    }
}