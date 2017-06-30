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
    public class SetorController : Controller
    {

        private readonly ISetorApplicationService _app;
		private readonly ILogger _logger;


        public SetorController(ISetorApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<SetorController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]SetorFilter filters)
        {
            var result = new HttpResult<SetorDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Setor", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]SetorFilter filters)
		{
			var result = new HttpResult<SetorDto>(this._logger);
            try
            {
				filters.SetorId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Setor", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SetorDtoSpecialized dto)
        {
            var result = new HttpResult<SetorDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Setor", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]SetorDtoSpecialized dto)
        {
            var result = new HttpResult<SetorDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Setor", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(SetorDto dto)
        {
            var result = new HttpResult<SetorDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Setor", dto);
            }
        }
    }
}
