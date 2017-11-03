using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class InfraestruturaPop : InfraestruturaPopBase
    {

        public InfraestruturaPop()
        {

        }

        public InfraestruturaPop(int infraestruturapopid, string nome, int infraestruturasiteid) :
            base(infraestruturapopid, nome, infraestruturasiteid)
        {

        }

		public class InfraestruturaPopFactory
        {
            public InfraestruturaPop GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new InfraestruturaPop(data.InfraestruturaPopId,
                                        data.Nome,
                                        data.InfraestruturaSiteId);

                construction.SetarDescricao(data.Descricao);
                construction.SetarLatitude(data.Latitude);
                construction.SetarLongitude(data.Longitude);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new InfraestruturaPopEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
