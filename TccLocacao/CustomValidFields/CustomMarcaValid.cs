using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomMarcaValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        int escolha;

        public CustomMarcaValid(int i)
        {
            escolha = i;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                switch (escolha)
                {
                    case 1:
                        return ValidaTipo(value);
                    case 2:
                        return ValidaCodigo(value);
                    case 3:
                        return ValidaDescricao(value);
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!");
        }

        private ValidationResult ValidaTipo(object value)
        {
            var existeTipo = db.TipoVeiculos.FirstOrDefault(x => x.CodigoTipo == (int)value && x.Ativo);

            if (existeTipo != null)
                return ValidationResult.Success;

            return new ValidationResult("Tipo de veículo inexistente no sistema!");
        }

        private ValidationResult ValidaCodigo(object value)
        {
            var existeCodigo = db.Marcas.FirstOrDefault(x => x.CodigoMarca == (int)value);

            if (existeCodigo != null)
                return new ValidationResult("Código já existente no sistema.");

            return ValidationResult.Success;
        }

        private ValidationResult ValidaDescricao(object value)
        {
            var existeMarca = db.Marcas.FirstOrDefault(x => x.Descricao.ToLower() == value.ToString().ToLower() && x.Descricao != "BMW");

            if (existeMarca != null)
                return new ValidationResult("Marca já existente no sistema!");

            return ValidationResult.Success;
        }
    }
}