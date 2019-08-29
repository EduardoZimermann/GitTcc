using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class Pendencia : UserControls
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("LocacaoFk")]
        public Locacao Locacao { get; set; }

        public int LocacaoFk { get; set; }
        public bool Aprovado { get; set; } = false;
    }
}