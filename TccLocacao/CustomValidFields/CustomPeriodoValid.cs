using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomPeriodoValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        int escolha;

        public CustomPeriodoValid(int i)
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
                        break;
                    case 4:
                        break;
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
            var existeCodigo = db.Periodos.FirstOrDefault(x => x.CodigoPeriodo == (int)value);

            if (existeCodigo != null)
                return new ValidationResult("Este código já está em uso!");

            return ValidationResult.Success;
        }
    }
}