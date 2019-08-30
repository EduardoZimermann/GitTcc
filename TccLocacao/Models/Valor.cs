using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class Valor : UserControls
    {
        [Key]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
    }
}