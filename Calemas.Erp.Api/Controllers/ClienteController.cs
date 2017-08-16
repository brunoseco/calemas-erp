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
    public class ClienteController : Controller
    {

        private readonly IClienteApplicationService _app;
		private readonly ILogger _logger;


        public ClienteController(IClienteApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<ClienteController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]ClienteFilter filters)
        {
            var result = new HttpResult<ClienteDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Cliente", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]ClienteFilter filters)
		{
			var result = new HttpResult<ClienteDto>(this._logger);
            try
            {
				filters.ClienteId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Cliente", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ClienteDtoSpecialized dto)
        {
            var result = new HttpResult<ClienteDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Cliente", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]ClienteDtoSpecialized dto)
        {
            var result = new HttpResult<ClienteDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Cliente", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(ClienteDto dto)
        {
            var result = new HttpResult<ClienteDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Cliente", dto);
            }
        }



    }
}
