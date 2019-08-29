using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomModeloValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        int escolha;

        public CustomModeloValid(int i)
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
                        return ValidaMarca(value);
                    case 2:
                        return ValidaCodigo(value);
                    case 3:
                        return ValidaDescricao(value);
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!");
        }

        private ValidationResult ValidaMarca(object value)
        {
            var existeMarca = db.Marcas.FirstOrDefault(x => x.CodigoMarca == (int)value && x.Ativo);

            if (existeMarca != null)
                return ValidationResult.Success;

            return new ValidationResult("Marca inexistente!");
        }

        private ValidationResult ValidaCodigo(object value)
        {
            var existeCodigo = db.Modelos.FirstOrDefault(x => x.CodigoModelo == (int)value);

            if (existeCodigo == null)
                return ValidationResult.Success;

            return new ValidationResult("Código já existente no sistema!");
        }

        private ValidationResult ValidaDescricao(object value)
        {
            var existeModelo = db.Modelos.FirstOrDefault(x => x.Descricao.ToLower() == value.ToString().ToLower() && x.Ativo);

            if (existeModelo == null)
                return ValidationResult.Success;

            return new ValidationResult("Este modelo já existe no sistema!");
        }
    }
}