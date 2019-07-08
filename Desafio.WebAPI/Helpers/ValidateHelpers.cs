using System;
using System.Collections.Generic;
using System.Net.Mail;
using AutoMapper;
using Desafio.Domain;
using Desafio.Util;
using Desafio.WebAPI.Dtos;

namespace Desafio.WebAPI.Helpers
{
    public class ValidateHelpers : Profile
    {
        public static List<Error> ValidateErrors(ContatoDto model) 
        {
            var erros = new List<Error>();

            if (string.IsNullOrEmpty(model.Canal)) {
                erros.Add(new Error {
                    StatusCode = 400,
                    Message = "O campo Canal não pode ser vazio."
                });
            }

            if (!Enum.IsDefined(typeof(CanalEnum), model.Canal)) {
                var values = Enum.GetNames(typeof(CanalEnum));
                erros.Add(new Error {
                    StatusCode = 400,
                    Message = $"O campo Canal permite apenas os seguinte valores: {string.Join(",", values)}"
                });
            }

            if (string.IsNullOrEmpty(model.Valor)) {
                erros.Add(new Error {
                    StatusCode = 400,
                    Message = "O campo Valor não pode ser vazio."
                });
            }

            if (model.Canal == CanalEnum.Email.ToString()) {
                var isValid = Utility.IsEmail(model.Valor);
                if (!isValid) {
                    erros.Add(new Error {
                        StatusCode = 400,
                        Message = "O campo Valor para o canal Email é inválido."
                    });
                }
            }

            if (model.Canal == CanalEnum.Phone.ToString()) {
                var isValid = Utility.IsPhone(model.Valor);
                if (!isValid || model.Valor.Trim().Length != 15) {
                    erros.Add(new Error {
                        StatusCode = 400,
                        Message = "O campo Valor para o canal Phone é inválido. Formato: (xx) xxxxx-xxxx ."
                    });
                }
            }

            if (model.Canal == CanalEnum.PhoneFixo.ToString()) {
                var isValid = Utility.IsPhone(model.Valor);
                if (!isValid || model.Valor.Trim().Length != 14) {
                    erros.Add(new Error {
                        StatusCode = 400,
                        Message = "O campo Valor para o canal PhoneFixo é inválido. Formato: (xx) xxxx-xxxx ."
                    });
                }
            }

            return erros;
        }
    }
}