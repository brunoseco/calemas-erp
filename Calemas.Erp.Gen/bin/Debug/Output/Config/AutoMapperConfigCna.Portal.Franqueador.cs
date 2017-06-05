using AutoMapper;

namespace Calemas.Erp.Application.Config
{
	public class AutoMapperConfigCalemas.Erp
    {
		public static void RegisterMappings()
		{

			Mapper.Initialize(x =>
			{
				x.AddProfile<DominioToDtoProfileCalemas.Erp>();
				x.AddProfile<DominioToDtoProfileCalemas.ErpCustom>();
			});

		}
	}
}
