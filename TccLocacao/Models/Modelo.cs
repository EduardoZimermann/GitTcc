using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Modelo : UserControls
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("MarcaFk")]
        public Marca Marca { get; set; }

        [CustomModeloValid(1)]
        public int MarcaFk { get; set; }

        [CustomModeloValid(2)]
        public int CodigoModelo { get; set; }

        [CustomModeloValid(3)]
        public string Descricao { get; set; }
    }
}