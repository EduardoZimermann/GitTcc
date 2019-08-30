using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using TccLocacao.enums;
using TccLocacao.Models;

namespace TccLocacao.CustomValidFields
{
    public class CustomLocacaoValid : ValidationAttribute
    {
        ContextDB db = new ContextDB();

        private LocacaoValidFields typeField;

        public CustomLocacaoValid(LocacaoValidFields type)
        {
            typeField = type;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                switch (typeField)
                {
                    case LocacaoValidFields.ValidaTipo:
                        return ValidaTipo(value);
                    case LocacaoValidFields.ValidaMarca:
                        return ValidaMarca(value);
                    case LocacaoValidFields.ValidaModelo:
                        return ValidaModelo(value);
                    case LocacaoValidFields.ValidaCor:
                        return ValidaCor(value);
                    case LocacaoValidFields.ValidaPlaca:
                        return ValidaPlaca(value);
                    case LocacaoValidFields.ValidaPeriodo:
                        return ValidaPeriodo(value);
                    case LocacaoValidFields.ValidaUsuario:
                        return ValidaUsuario(value);
                    case LocacaoValidFields.ValidaTermo:
                        return ValidaTermo(value);
                }
            }

            return new ValidationResult($"O campo {validationContext.DisplayName} é obrigatório!"); ;
        }

        #region Métodos
        private ValidationResult ValidaTipo(object value)
        {
            var existeTipo = db.TipoVeiculos.FirstOrDefault(x => x.CodigoTipo == (int)value && x.Ativo);

            if (existeTipo != null)
                return ValidationResult.Success;

            return new ValidationResult("Tipo de veículo inexistente!");
        }

        private ValidationResult ValidaMarca(object value)
        {
            var existeMarca = db.Marcas.FirstOrDefault(x => x.CodigoMarca == (int)value && x.Ativo);

            if (existeMarca != null)
                return ValidationResult.Success;

            return new ValidationResult("Marca inexistente");
        }

        private ValidationResult ValidaModelo(object value)
        {
            var existeModelo = db.Modelos.FirstOrDefault(x => x.CodigoModelo == (int)value && x.Ativo);

            if (existeModelo != null)
                return ValidationResult.Success;

            return new ValidationResult("Modelo inexistente");
        }

        private ValidationResult ValidaCor(object value)
        {
            var existeCor = db.Cores.FirstOrDefault(x => x.CodigoCor == (int)value && x.Ativo);

            if (existeCor != null)
                return ValidationResult.Success;

            return new ValidationResult("Cor inexistente!");
        }

        private ValidationResult ValidaPlaca(object value)
        {
            var placaBR = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{4}$");

            var placaMerc = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{1}[a-zA-Z]{1}[0-9]{2}$");

            var placaMoto = Regex.IsMatch(value.ToString(), @"^[a-zA-Z]{3}[0-9]{2}[a-zA-Z]{1}[0-9]{1}$");

            if (placaBR || placaMerc || placaMoto)
            {
                //var existePlaca = db.Locacoes.FirstOrDefault(x => x.Placa.ToLower() == value.ToString().ToLower() && x.Ativo);

                //if (existePlaca == null)
                    return ValidationResult.Success;

                //return new ValidationResult("Veículo já cadastrado no sistema");
            }

            return new ValidationResult("A placa está em um formato incorreto!");
        }

        private ValidationResult ValidaPeriodo(object value)
        {
            var existePeriodo = db.Periodos.FirstOrDefault(x => x.CodigoPeriodo == (int)value && x.Ativo);

            if (existePeriodo != null)
                return ValidationResult.Success;

            return new ValidationResult("Período inexistente!");
        }

        private ValidationResult ValidaUsuario(object value)
        {
            try
            {
                //int existeUsuario = db.Usuarios.FirstOrDefault(x => x.CodigoUsuario == (int)value && x.Ativo).Id;

                //var existeRegistro = db.Locacoes.FirstOrDefault(x => x.UsuarioFk == existeUsuario && x.Ativo);

                //if (existeRegistro != null)
                    //return new ValidationResult("Usuário informado já possui um registro ativo no sistema!");

                return ValidationResult.Success;
            }
            catch (NullReferenceException)
            {
                return new ValidationResult("Usuário inexistente!");
            }
        }

        private ValidationResult ValidaTermo(object value)
        {
            if ((bool)value)
                return ValidationResult.Success;

            return new ValidationResult("Você precisa aceitar os termos de uso!");
        }
        #endregion
    }
}