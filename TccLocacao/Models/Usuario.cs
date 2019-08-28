using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class Usuario : UserControls
    {
        [Key]
        public int Id { get; set; }
        public int CodigoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public bool ResideFora { get; set; }
        public bool OfereceCarona { get; set; }
        public bool PCD { get; set; }
        public bool TrabalhoNoturno { get; set; }
    }
}