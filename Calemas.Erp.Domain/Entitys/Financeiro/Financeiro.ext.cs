using Calemas.Erp.Domain.Validations;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class Financeiro : FinanceiroBase
    {

        public Financeiro()
        {

        }

        public Financeiro(int financeiroid, DateTime datavencimento, int parcela, int planocontaid, decimal valororiginal, decimal valordesconto, decimal valormultajuros, decimal valorfinal, int pessoaid, string descricao, bool baixado, decimal valordescontoatevencimento, decimal percentualjuros, decimal percentualmulta) :
            base(financeiroid, datavencimento, parcela, planocontaid, valororiginal, valordesconto, valormultajuros, valorfinal, pessoaid, descricao, baixado, valordescontoatevencimento, percentualjuros, percentualmulta)
        {

        }

		public class FinanceiroFactory
        {
            public Financeiro GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new Financeiro(data.FinanceiroId,
                                        data.DataVencimento,
                                        data.Parcela,
                                        data.PlanoContaId,
                                        data.ValorOriginal,
                                        data.ValorDesconto,
                                        data.ValorMultaJuros,
                                        data.ValorFinal,
                                        data.PessoaId,
                                        data.Descricao,
                                        data.Baixado,
                                        data.ValorDescontoAteVencimento,
                                        data.PercentualJuros,
                                        data.PercentualMulta);

                construction.SetarDataBaixa(data.DataBaixa);


				return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new FinanceiroEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
