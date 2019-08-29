using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Cor : UserControls
    {
        [Key]
        public int Id { get; set; }

        [CustomCorValid(1)]
        public int CodigoCor { get; set; }

        [CustomCorValid(2)]
        public string Descricao { get; set; }
    }
}