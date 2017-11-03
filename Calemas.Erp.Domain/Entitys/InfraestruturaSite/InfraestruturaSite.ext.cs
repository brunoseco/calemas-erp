using Calemas.Erp.Domain.Validations;
using System;
using Common.Domain.Model;

namespace Calemas.Erp.Domain.Entitys
{
    public class InfraestruturaSite : InfraestruturaSiteBase
    {

        public InfraestruturaSite()
        {

        }

        public InfraestruturaSite(int infraestruturasiteid, string nome) :
            base(infraestruturasiteid, nome)
        {

        }

		public class InfraestruturaSiteFactory
        {
            public InfraestruturaSite GetDefaultInstance(dynamic data, CurrentUser user)
            {
                var construction = new InfraestruturaSite(data.InfraestruturaSiteId,
                                        data.Nome);

                construction.SetarDescricao(data.Descricao);
                construction.SetarLatitude(data.Latitude);
                construction.SetarLongitude(data.Longitude);
                construction.SetarEndpoint(data.Endpoint);
                construction.SetarLogin(data.Login);
                construction.SetarSenha(data.Senha);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

        public bool IsValid()
        {
            base._validationResult = new InfraestruturaSiteEstaConsistenteValidation().Validate(this);
            return base._validationResult.IsValid;

        }
        
    }
}
