using System;
using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Dto;
using Common.API;


namespace Calemas.Erp.Api.Controllers
{
	[Authorize]
    [Route("api/[controller]")]
    public class BancoController : Controller
    {

        private readonly IBancoApplicationService _app;
		private readonly ILogger _logger;


        public BancoController(IBancoApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<BancoController>();
			
        }

        [HttpGet]
        public IActionResult Get([FromQuery]BancoFilter filters)
        {
            var result = new HttpResult<BancoDto>(this._logger);
            try
            {
                var searchResult = this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", filters);
            }

        }


        [HttpGet("{id}")]
		public IActionResult Get(int id, [FromQuery]BancoFilter filters)
		{
			var result = new HttpResult<BancoDto>(this._logger);
            try
            {
				filters.BancoId = id;
                var returnModel = this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", id);
            }

		}




        [HttpPost]
        public IActionResult Post([FromBody]BancoDtoSpecialized dto)
        {
            var result = new HttpResult<BancoDto>(this._logger);
            try
            {
                var returnModel = this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", dto);
            }
        }



        [HttpPut]
        public IActionResult Put([FromBody]BancoDtoSpecialized dto)
        {
            var result = new HttpResult<BancoDto>(this._logger);
            try
            {
                var returnModel = this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", dto);
            }
        }


        [HttpDelete]
        public IActionResult Delete(BancoDto dto)
        {
            var result = new HttpResult<BancoDto>(this._logger);
            try
            {
                this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", dto);
            }
        }
    }
}
