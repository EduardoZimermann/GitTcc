using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class Locacao : UserControls
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("TipoVeiculoFk")]
        public TipoVeiculo TipoVeiculo { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaTipo)]
        public int TipoVeiculoFk { get; set; }

        [ForeignKey("MarcaFk")]
        public Marca Marca { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaMarca)]
        public int MarcaFk { get; set; }

        [ForeignKey("ModeloFk")]
        public Modelo Modelo { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaModelo)]
        public int ModeloFk { get; set; }

        [ForeignKey("CorFk")]
        public Cor Cor { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaCor)]
        public int CorFk { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaPlaca)]
        public string Placa { get; set; }

        [ForeignKey("PeriodoFk")]
        public Periodo Periodo { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaPeriodo)]
        public int PeriodoFk { get; set; }

        [ForeignKey("UsuarioFk")]
        public Usuario Usuario { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaUsuario)]
        public int UsuarioFk { get; set; }

        [CustomLocacaoValid(enums.LocacaoValidFields.ValidaTermo)]
        public bool AceiteTermo { get; set; }

        public string Status { get; set; } = "Em aprovação!";
    }
}