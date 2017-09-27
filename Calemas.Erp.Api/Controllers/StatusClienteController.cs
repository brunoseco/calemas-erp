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
    public class StatusClienteController : Controller
    {

        private readonly IStatusClienteApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public StatusClienteController(IStatusClienteApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<StatusClienteController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]StatusClienteFilter filters)
        {
            var result = new HttpResult<StatusClienteDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusCliente", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]StatusClienteFilter filters)
		{
			var result = new HttpResult<StatusClienteDto>(this._logger);
            try
            {
				filters.StatusClienteId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusCliente", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]StatusClienteDtoSpecialized dto)
        {
            var result = new HttpResult<StatusClienteDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusCliente", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]StatusClienteDtoSpecialized dto)
        {
            var result = new HttpResult<StatusClienteDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusCliente", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(StatusClienteDto dto)
        {
            var result = new HttpResult<StatusClienteDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusCliente", dto);
            }
        }



    }
}
