using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class Termo : UserControls
    {
        [Key]
        public int Id { get; set; }
        public int CodigoTermo { get; set; }
        public string Descricao { get; set; }
    }
}