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
    public class FinanceiroController : Controller
    {

        private readonly IFinanceiroApplicationService _app;
		private readonly ILogger _logger;


        public FinanceiroController(IFinanceiroApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<FinanceiroController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]FinanceiroFilter filters)
        {
            var result = new HttpResult<FinanceiroDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Financeiro", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]FinanceiroFilter filters)
		{
			var result = new HttpResult<FinanceiroDto>(this._logger);
            try
            {
				filters.FinanceiroId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Financeiro", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FinanceiroDtoSpecialized dto)
        {
            var result = new HttpResult<FinanceiroDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Financeiro", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]FinanceiroDtoSpecialized dto)
        {
            var result = new HttpResult<FinanceiroDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Financeiro", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(FinanceiroDto dto)
        {
            var result = new HttpResult<FinanceiroDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Financeiro", dto);
            }
        }
    }
}
