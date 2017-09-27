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
    public class TipoOrdemServicoController : Controller
    {

        private readonly ITipoOrdemServicoApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public TipoOrdemServicoController(ITipoOrdemServicoApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<TipoOrdemServicoController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]TipoOrdemServicoFilter filters)
        {
            var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]TipoOrdemServicoFilter filters)
		{
			var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
				filters.TipoOrdemServicoId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]TipoOrdemServicoDtoSpecialized dto)
        {
            var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]TipoOrdemServicoDtoSpecialized dto)
        {
            var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(TipoOrdemServicoDto dto)
        {
            var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", dto);
            }
        }



    }
}
