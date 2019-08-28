using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Locacao : UserControls
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaTipo)]
        public virtual TipoVeiculo TipoVeiculo { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaMarca)]
        public virtual Marca Marca { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaModelo)]
        public virtual Modelo Modelo { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaCor)]
        public virtual Cor Cor { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaPlaca)]
        public string Placa { get; set; }

        [Required]
        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaPeriodo)]
        public virtual Periodo Periodo { get; set; }

        [Required]
        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaUsuario)]
        public virtual Usuario Usuario { get; set; }

        [Required]
        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaTermo)]
        public bool AceiteTermo { get; set; }
    }
}