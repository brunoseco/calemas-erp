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
    public class StatusSolicitacaoEstoqueMovimentacaoController : Controller
    {

        private readonly IStatusSolicitacaoEstoqueMovimentacaoApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public StatusSolicitacaoEstoqueMovimentacaoController(IStatusSolicitacaoEstoqueMovimentacaoApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<StatusSolicitacaoEstoqueMovimentacaoController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]StatusSolicitacaoEstoqueMovimentacaoFilter filters)
        {
            var result = new HttpResult<StatusSolicitacaoEstoqueMovimentacaoDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusSolicitacaoEstoqueMovimentacao", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]StatusSolicitacaoEstoqueMovimentacaoFilter filters)
		{
			var result = new HttpResult<StatusSolicitacaoEstoqueMovimentacaoDto>(this._logger);
            try
            {
				filters.StatusSolicitacaoEstoqueMovimentacaoId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusSolicitacaoEstoqueMovimentacao", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StatusSolicitacaoEstoqueMovimentacaoDtoSpecialized dto)
        {
            var result = new HttpResult<StatusSolicitacaoEstoqueMovimentacaoDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusSolicitacaoEstoqueMovimentacao", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]StatusSolicitacaoEstoqueMovimentacaoDtoSpecialized dto)
        {
            var result = new HttpResult<StatusSolicitacaoEstoqueMovimentacaoDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusSolicitacaoEstoqueMovimentacao", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(StatusSolicitacaoEstoqueMovimentacaoDto dto)
        {
            var result = new HttpResult<StatusSolicitacaoEstoqueMovimentacaoDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusSolicitacaoEstoqueMovimentacao", dto);
            }
        }



    }
}
