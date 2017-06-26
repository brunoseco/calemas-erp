using Calemas.Erp.Domain.Validations;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Colaborador : ColaboradorBase
    {

        public Colaborador()
        {

        }

        public Colaborador(
            int colaboradorId, 
            string account, 
            string password, 
            bool ativo, 
            int pessoaid,
            string nome,
            string apelido,
            string cpf_cnpj,
            string rg_ie,
            string email,
            string telefone,
            string celular,
            string comercial,
            DateTime? dataNascimento,
            int? estadoCivilId,
            int? sexo,
            bool? juridica)
            : base(colaboradorId, account, password, ativo)
        {
            this.Pessoa = new Pessoa(pessoaid, nome, apelido);
            this.Pessoa.SetarCPF_CNPJ(cpf_cnpj);
            this.Pessoa.SetarRG_IE(rg_ie);
            this.Pessoa.SetarEmail(email);
            this.Pessoa.SetarTelefone(telefone);
            this.Pessoa.SetarCelular(celular);
            this.Pessoa.SetarComercial(comercial);
            this.Pessoa.SetarDataNascimento(dataNascimento);
            this.Pessoa.SetarEstadoCivilId(estadoCivilId);
            this.Pessoa.SetarSexo(sexo);
            this.Pessoa.SetarJuridica(juridica);

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
