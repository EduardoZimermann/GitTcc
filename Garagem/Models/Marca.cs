﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Garagem.Models
{
    public class Marca
    {
        [Key]
        public int Id { get; set; }
        public virtual TipoVeiculo TipoVeiculo { get; set; }
        public int CodigoMarca { get; set; }
        public int Descricao { get; set; }
    }
}