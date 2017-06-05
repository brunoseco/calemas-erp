using Common.Domain.Base;
using System;

namespace Calemas.Erp.ui.Domain.Filter
{
    public class AlunoFilterBase : FilterBase
    {

        public int AlunoId { get; set;} 
        public int? DivulgadorId { get; set;} 
        public int? MidiaId { get; set;} 
        public int? AcaoComercialId { get; set;} 
        public int? CampanhaId { get; set;} 
        public int? EmpresaParceiraId { get; set;} 
        public string Diagnostico { get; set;} 
        public bool? NaoReceberEmail { get; set;} 
        public bool? NaoReceberSMS { get; set;} 
        public int? MotivoSuspensaoId { get; set;} 
        public string EmpresaEscola { get; set;} 
        public string Escola { get; set;} 
        public int? EscolaridadeId { get; set;} 
        public string Observacoes { get; set;} 
        public int UserCreateId { get; set;} 
        public DateTime UserCreateDateStart { get; set;} 
        public DateTime UserCreateDateEnd { get; set;} 
        public DateTime UserCreateDate { get; set;} 
        public int? UserAlterId { get; set;} 
        public DateTime? UserAlterDateStart { get; set;} 
        public DateTime? UserAlterDateEnd { get; set;} 
        public DateTime? UserAlterDate { get; set;} 


    }
}
