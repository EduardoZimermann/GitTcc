using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomUsuarioValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        int escolha;

        public CustomUsuarioValid(int i)
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
                        return ValidaNome(value);
                    case 3:
                        return ValidaEmail(value);
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!");
        }

        private ValidationResult ValidaCodigo(object value)
        {
            var existeCodigo = db.Usuarios.FirstOrDefault(x => x.CodigoUsuario == (int)value);

            if (existeCodigo != null)
                return new ValidationResult("Este código já está em uso!");

            return ValidationResult.Success;
        }

        private ValidationResult ValidaNome(object value)
        {
            var nomeValido = Regex.IsMatch(value.ToString(), @"^[ a-zA-Z á-ú]*$");

            if (nomeValido)
                return ValidationResult.Success;

            return new ValidationResult("Nome inválido!");
        }

        private ValidationResult ValidaEmail(object value)
        {
            var emailValido = Regex.IsMatch(value.ToString(), @"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$");

            if (emailValido)
                return ValidationResult.Success;

            return new ValidationResult("E-mail inválido!");
        }
    }
}