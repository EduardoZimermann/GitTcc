using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LocacaoDeGaragens.Models
{
    public class Cor
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Nome { get; set; }
    }
}