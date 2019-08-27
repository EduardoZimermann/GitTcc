using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TccLocacao.Models
{
    public class Modelo : UserControls
    {
        [Key]
        public int Id { get; set; }
        public virtual Marca Marca { get; set; }
        public int CodigoModelo { get; set; }
        public string Descricao { get; set; }
    }
}