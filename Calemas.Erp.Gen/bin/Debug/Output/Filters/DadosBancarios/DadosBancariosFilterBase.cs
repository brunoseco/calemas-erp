using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class DadosBancariosFilterBase : FilterBase
    {

        public int DadosBancariosId { get; set;} 
        public int BancoId { get; set;} 
        public string Agencia { get; set;} 
        public string DigitoVerificadorAgencia { get; set;} 
        public string NumeroConta { get; set;} 
        public string DigitoVerificador { get; set;} 


    }
}
