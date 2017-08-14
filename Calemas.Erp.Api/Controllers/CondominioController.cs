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
    public class CondominioController : Controller
    {

        private readonly ICondominioApplicationService _app;
		private readonly ILogger _logger;


        public CondominioController(ICondominioApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<CondominioController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CondominioFilter filters)
        {
            var result = new HttpResult<CondominioDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Condominio", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]CondominioFilter filters)
		{
			var result = new HttpResult<CondominioDto>(this._logger);
            try
            {
				filters.CondominioId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Condominio", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CondominioDtoSpecialized dto)
        {
            var result = new HttpResult<CondominioDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Condominio", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CondominioDtoSpecialized dto)
        {
            var result = new HttpResult<CondominioDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Condominio", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(CondominioDto dto)
        {
            var result = new HttpResult<CondominioDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Condominio", dto);
            }
        }
    }
}
