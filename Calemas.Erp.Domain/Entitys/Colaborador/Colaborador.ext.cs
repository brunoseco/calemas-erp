using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Colaborador : ColaboradorBase
    {

        public Colaborador()
        {

        }
        
        public class FactoryColaborador
        {
            public Colaborador GetInstance(dynamic model)
            {
                var _colaborador = new Colaborador()
                {
                    ColaboradorId = model.ColaboradorId,
                    Account = model.Account,
                    Password = model.Password,
                    Ativo = model.Ativo
                };

                _colaborador.Pessoa = new Pessoa(model.Pessoa.PessoaId, model.Pessoa.Nome, model.Pessoa.Apelido);
                _colaborador.Pessoa.SetarCPF_CNPJ(model.Pessoa.CPF_CNPJ);
                _colaborador.Pessoa.SetarRG_IE(model.Pessoa.RG_IE);
                _colaborador.Pessoa.SetarEmail(model.Pessoa.Email);
                _colaborador.Pessoa.SetarTelefone(model.Pessoa.Telefone);
                _colaborador.Pessoa.SetarCelular(model.Pessoa.Celular);
                _colaborador.Pessoa.SetarComercial(model.Pessoa.Comercial);
                _colaborador.Pessoa.SetarDataNascimento(model.Pessoa.DataNascimento);
                _colaborador.Pessoa.SetarEstadoCivilId(model.Pessoa.EstadoCivilId);
                _colaborador.Pessoa.SetarSexo(model.Pessoa.Sexo);
                _colaborador.Pessoa.SetarJuridica(model.Pessoa.Juridica);

                return _colaborador;
            }
        }

        public Colaborador(int colaboradorId, string account, string password, bool ativo)
            : base(colaboradorId, account, password, ativo) { }
        
        public virtual Pessoa Pessoa { get; set; }

        public bool IsValid()
        {
            base._validationResult = new ColaboradorEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;
        }

    }
}
