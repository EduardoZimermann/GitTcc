using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace LocacaoDeGaragens.Models
{
    public class ModeloAutomovel
    {
        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public MarcaAutomovel Marca { get; set; }
        [ForeignKey("Marca")]
        public int MarcaFk { get; set; }
        public string Modelo { get; set; }
    }
}