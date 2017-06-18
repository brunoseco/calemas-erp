using Calemas.Erp.Domain.Entitys;
using Calemas.Erp.Domain.Filter;
using System.Linq;

namespace Calemas.Erp.Data.Repository
{
    public static class PessoaFilterBasicExtension
    {

        public static IQueryable<Pessoa> WithBasicFilters(this IQueryable<Pessoa> queryBase, PessoaFilter filters)
        {
            var queryFilter = queryBase;

            if (filters.PessoaId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.PessoaId == filters.PessoaId);
			};
            if (filters.CPF_CNPJ.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.CPF_CNPJ.Contains(filters.CPF_CNPJ));
			};
            if (filters.RG_IE.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.RG_IE.Contains(filters.RG_IE));
			};
            if (filters.Nome.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Nome.Contains(filters.Nome));
			};
            if (filters.Apelido.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Apelido.Contains(filters.Apelido));
			};
            if (filters.Email.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Email.Contains(filters.Email));
			};
            if (filters.Telefone.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Telefone.Contains(filters.Telefone));
			};
            if (filters.Celular.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Celular.Contains(filters.Celular));
			};
            if (filters.Comercial.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Comercial.Contains(filters.Comercial));
			};
            if (filters.DataNascimentoStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.DataNascimento != null && _.DataNascimento.Value >= filters.DataNascimentoStart.Value);
			};
            if (filters.DataNascimentoEnd.IsSent()) 
			{ 
				filters.DataNascimentoEnd = filters.DataNascimentoEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.DataNascimento != null &&  _.DataNascimento.Value <= filters.DataNascimentoEnd);
			};

            if (filters.EstadoCivilId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EstadoCivilId != null && _.EstadoCivilId.Value == filters.EstadoCivilId);
			};
            if (filters.Sexo.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Sexo != null && _.Sexo.Value == filters.Sexo);
			};
            if (filters.Juridica.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.Juridica != null && _.Juridica.Value == filters.Juridica);
			};
            if (filters.EnderecoId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.EnderecoId != null && _.EnderecoId.Value == filters.EnderecoId);
			};
            if (filters.UserCreateId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateId == filters.UserCreateId);
			};
            if (filters.UserCreateDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserCreateDate >= filters.UserCreateDateStart );
			};
            if (filters.UserCreateDateEnd.IsSent()) 
			{ 
				filters.UserCreateDateEnd = filters.UserCreateDateEnd.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserCreateDate  <= filters.UserCreateDateEnd);
			};

            if (filters.UserAlterId.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterId != null && _.UserAlterId.Value == filters.UserAlterId);
			};
            if (filters.UserAlterDateStart.IsSent()) 
			{ 
				
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null && _.UserAlterDate.Value >= filters.UserAlterDateStart.Value);
			};
            if (filters.UserAlterDateEnd.IsSent()) 
			{ 
				filters.UserAlterDateEnd = filters.UserAlterDateEnd.Value.AddDays(1).AddMilliseconds(-1);
				queryFilter = queryFilter.Where(_=>_.UserAlterDate != null &&  _.UserAlterDate.Value <= filters.UserAlterDateEnd);
			};



            return queryFilter;
        }

    }
}