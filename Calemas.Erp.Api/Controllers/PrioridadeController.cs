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
    public class PrioridadeController : Controller
    {

        private readonly IPrioridadeApplicationService _app;
		private readonly ILogger _logger;


        public PrioridadeController(IPrioridadeApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<PrioridadeController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PrioridadeFilter filters)
        {
            var result = new HttpResult<PrioridadeDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Prioridade", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]PrioridadeFilter filters)
		{
			var result = new HttpResult<PrioridadeDto>(this._logger);
            try
            {
				filters.PrioridadeId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Prioridade", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PrioridadeDtoSpecialized dto)
        {
            var result = new HttpResult<PrioridadeDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Prioridade", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]PrioridadeDtoSpecialized dto)
        {
            var result = new HttpResult<PrioridadeDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Prioridade", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(PrioridadeDto dto)
        {
            var result = new HttpResult<PrioridadeDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Prioridade", dto);
            }
        }



    }
}
