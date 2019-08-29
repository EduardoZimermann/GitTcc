using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.Enums;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomTipoValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        TipoValidFields typeField;

        public CustomTipoValid(TipoValidFields type)
        {
            typeField = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                switch (typeField)
                {
                    case TipoValidFields.ValidaCodigo:
                        return ValidaCodigo(value);
                    case TipoValidFields.ValidaDescricao:
                        return ValidaDescricao(value);
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!");
        }

        private ValidationResult ValidaCodigo(object value)
        {
            var existeCodigo = db.TipoVeiculos.FirstOrDefault(x => x.CodigoTipo == (int)value);

            if (existeCodigo == null)
                return ValidationResult.Success;

            return new ValidationResult("Código já existente no sistema!");
        }

        private ValidationResult ValidaDescricao(object value)
        {
            var existeDescricao = db.TipoVeiculos.FirstOrDefault(x => x.Descricao.ToLower() == value.ToString().ToLower() && x.Ativo);

            if (existeDescricao == null)
                return ValidationResult.Success;

            return new ValidationResult("Tipo de veículo já existente!");
        }
    }
}