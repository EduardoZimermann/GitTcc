﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.CustomValidFields;

namespace TccLocacao.Models
{
    public class TipoVeiculo : UserControls
    {
        [Key]
        public int Id { get; set; }

        [CustomTipoValid(Enums.TipoValidFields.ValidaCodigo)]
        public int CodigoTipo { get; set; }

        [CustomTipoValid(Enums.TipoValidFields.ValidaDescricao)]
        public string Descricao { get; set; }
    }
}