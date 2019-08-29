using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Usuario : UserControls
    {
        [Key]
        public int Id { get; set; }

        [CustomUsuarioValid(1)]
        public int CodigoUsuario { get; set; }

        [CustomUsuarioValid(2)]
        public string Nome { get; set; }

        [CustomUsuarioValid(3)]
        public string Email { get; set; }
        public bool ResideFora { get; set; }
        public bool OfereceCarona { get; set; }
        public bool PCD { get; set; }
        public bool TrabalhoNoturno { get; set; }
    }
}