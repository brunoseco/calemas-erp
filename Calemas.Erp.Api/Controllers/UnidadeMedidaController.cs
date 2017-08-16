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
    public class UnidadeMedidaController : Controller
    {

        private readonly IUnidadeMedidaApplicationService _app;
		private readonly ILogger _logger;


        public UnidadeMedidaController(IUnidadeMedidaApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<UnidadeMedidaController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]UnidadeMedidaFilter filters)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - UnidadeMedida", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]UnidadeMedidaFilter filters)
		{
			var result = new HttpResult<UnidadeMedidaDto>(this._logger);
            try
            {
				filters.UnidadeMedidaId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - UnidadeMedida", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]UnidadeMedidaDtoSpecialized dto)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - UnidadeMedida", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]UnidadeMedidaDtoSpecialized dto)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - UnidadeMedida", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(UnidadeMedidaDto dto)
        {
            var result = new HttpResult<UnidadeMedidaDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - UnidadeMedida", dto);
            }
        }



    }
}
