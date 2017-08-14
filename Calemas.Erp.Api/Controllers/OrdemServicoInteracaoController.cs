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
    public class OrdemServicoInteracaoController : Controller
    {

        private readonly IOrdemServicoInteracaoApplicationService _app;
		private readonly ILogger _logger;


        public OrdemServicoInteracaoController(IOrdemServicoInteracaoApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<OrdemServicoInteracaoController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]OrdemServicoInteracaoFilter filters)
        {
            var result = new HttpResult<OrdemServicoInteracaoDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - OrdemServicoInteracao", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]OrdemServicoInteracaoFilter filters)
		{
			var result = new HttpResult<OrdemServicoInteracaoDto>(this._logger);
            try
            {
				filters.OrdemServicoInteracaoId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - OrdemServicoInteracao", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrdemServicoInteracaoDtoSpecialized dto)
        {
            var result = new HttpResult<OrdemServicoInteracaoDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - OrdemServicoInteracao", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]OrdemServicoInteracaoDtoSpecialized dto)
        {
            var result = new HttpResult<OrdemServicoInteracaoDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - OrdemServicoInteracao", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(OrdemServicoInteracaoDto dto)
        {
            var result = new HttpResult<OrdemServicoInteracaoDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - OrdemServicoInteracao", dto);
            }
        }
    }
}
