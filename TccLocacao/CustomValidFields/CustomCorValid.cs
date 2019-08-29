using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomCorValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        int escolha;

        public CustomCorValid(int i)
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
                        return ValidaCodigo(value);
                    case 2:
                        return ValidaDescricao(value);
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!");
        }

        private ValidationResult ValidaCodigo(object value)
        {
            var existeCodigo = db.Cores.FirstOrDefault(x => x.CodigoCor == (int)value);

            if (existeCodigo == null)
                return ValidationResult.Success;

            return new ValidationResult("Código já existente no sistema!");
        }

        private ValidationResult ValidaDescricao(object value)
        {
            var existeCor = db.Cores.FirstOrDefault(x => x.Descricao.ToLower() == value.ToString().ToLower() && x.Ativo);

            if (existeCor == null)
                return ValidationResult.Success;

            return new ValidationResult("Cor já existente no sistema!");
        }
    }
}