using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccGaragem.Models
{
    public class Cor
    {
        [Key]
        public int Id { get; set; }
        public int CodigoCor { get; set; }
        public string Descricao { get; set; }
    }
}