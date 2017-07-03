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
    public class TipoPlanoContaController : Controller
    {

        private readonly ITipoPlanoContaApplicationService _app;
		private readonly ILogger _logger;


        public TipoPlanoContaController(ITipoPlanoContaApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<TipoPlanoContaController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]TipoPlanoContaFilter filters)
        {
            var result = new HttpResult<TipoPlanoContaDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoPlanoConta", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]TipoPlanoContaFilter filters)
		{
			var result = new HttpResult<TipoPlanoContaDto>(this._logger);
            try
            {
				filters.TipoPlanoContaId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoPlanoConta", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TipoPlanoContaDtoSpecialized dto)
        {
            var result = new HttpResult<TipoPlanoContaDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoPlanoConta", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TipoPlanoContaDtoSpecialized dto)
        {
            var result = new HttpResult<TipoPlanoContaDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoPlanoConta", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(TipoPlanoContaDto dto)
        {
            var result = new HttpResult<TipoPlanoContaDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoPlanoConta", dto);
            }
        }
    }
}
