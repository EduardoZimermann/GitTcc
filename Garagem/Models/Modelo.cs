using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garagem.Models
{
    public class Modelo
    {
        [Key]
        public int Id { get; set; }
        public int CodigoTipo { get; set; }
        public int CodigoMarca { get; set; }
        public int CodigoModelo { get; set; }
        public string Descricao { get; set; }
    }
}