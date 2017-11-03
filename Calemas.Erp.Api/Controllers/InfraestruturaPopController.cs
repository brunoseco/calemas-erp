using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Dto;
using Common.API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace Calemas.Erp.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class InfraestruturaPopController : Controller
    {

        private readonly IInfraestruturaPopApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public InfraestruturaPopController(IInfraestruturaPopApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<InfraestruturaPopController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]InfraestruturaPopFilter filters)
        {
            var result = new HttpResult<InfraestruturaPopDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - InfraestruturaPop", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]InfraestruturaPopFilter filters)
		{
			var result = new HttpResult<InfraestruturaPopDto>(this._logger);
            try
            {
				filters.InfraestruturaPopId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - InfraestruturaPop", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]InfraestruturaPopDtoSpecialized dto)
        {
            var result = new HttpResult<InfraestruturaPopDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - InfraestruturaPop", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]InfraestruturaPopDtoSpecialized dto)
        {
            var result = new HttpResult<InfraestruturaPopDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - InfraestruturaPop", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(InfraestruturaPopDto dto)
        {
            var result = new HttpResult<InfraestruturaPopDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - InfraestruturaPop", dto);
            }
        }



    }
}
