using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocacaoDeGaragens.Models
{
    public class ModeloMoto
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public MarcaMoto Marca { get; set; }
        [ForeignKey("Marca")]
        public int MarcaFk { get; set; }
        public string Modelo { get; set; }
    }
}