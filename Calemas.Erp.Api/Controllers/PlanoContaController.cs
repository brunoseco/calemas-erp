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

namespace Calemas.Erp.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class PlanoContaController : Controller
    {

        private readonly IPlanoContaApplicationService _app;
		private readonly ILogger _logger;


        public PlanoContaController(IPlanoContaApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<PlanoContaController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PlanoContaFilter filters)
        {
            var result = new HttpResult<PlanoContaDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - PlanoConta", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]PlanoContaFilter filters)
		{
			var result = new HttpResult<PlanoContaDto>(this._logger);
            try
            {
				filters.PlanoContaId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - PlanoConta", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PlanoContaDtoSpecialized dto)
        {
            var result = new HttpResult<PlanoContaDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - PlanoConta", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]PlanoContaDtoSpecialized dto)
        {
            var result = new HttpResult<PlanoContaDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - PlanoConta", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(PlanoContaDto dto)
        {
            var result = new HttpResult<PlanoContaDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - PlanoConta", dto);
            }
        }
    }
}
