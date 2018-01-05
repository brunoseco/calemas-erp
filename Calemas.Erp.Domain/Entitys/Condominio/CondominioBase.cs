using Common.Domain.Base;
using Common.Domain.Model;
using System;

namespace Calemas.Erp.Domain.Entitys
{
    public class CondominioBase : DomainBaseWithUserCreate
    {
        public CondominioBase()
        {

        }
        public CondominioBase(int condominioid, string nome, string sigla, bool ativo, int enderecoid)
        {
            this.CondominioId = condominioid;
            this.Nome = nome;
            this.Sigla = sigla;
            this.Ativo = ativo;
            this.EnderecoId = enderecoid;

        }

        public virtual int CondominioId { get; protected set; }
        public virtual string Nome { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual string Sigla { get; protected set; }
        public virtual bool Ativo { get; protected set; }
        public virtual int EnderecoId { get; protected set; }
        public virtual int? InfraestruturaPopId { get; protected set; }


public class CondominioFactoryBase
        {
            public virtual Condominio GetDefaultInstanceBase(dynamic data, CurrentUser user)
            {
                var construction = new Condominio(data.CondominioId,
                                        data.Nome,
                                        data.Sigla,
                                        data.Ativo,
                                        data.EnderecoId);

                construction.SetarDescricao(data.Descricao);
                construction.SetarInfraestruturaPopId(data.InfraestruturaPopId);


				construction.SetAttributeBehavior(data.AttributeBehavior);
        		return construction;
            }

        }

		public virtual void SetarDescricao(string descricao)
		{
			this.Descricao = descricao;
		}
		public virtual void SetarInfraestruturaPopId(int? infraestruturapopid)
		{
			this.InfraestruturaPopId = infraestruturapopid;
		}


    }
}
