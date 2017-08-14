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
    public class AgendaColaboradorController : Controller
    {

        private readonly IAgendaColaboradorApplicationService _app;
		private readonly ILogger _logger;


        public AgendaColaboradorController(IAgendaColaboradorApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<AgendaColaboradorController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]AgendaColaboradorFilter filters)
        {
            var result = new HttpResult<AgendaColaboradorDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - AgendaColaborador", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]AgendaColaboradorFilter filters)
		{
			var result = new HttpResult<AgendaColaboradorDto>(this._logger);
            try
            {
				filters.AgendaId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - AgendaColaborador", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AgendaColaboradorDtoSpecialized dto)
        {
            var result = new HttpResult<AgendaColaboradorDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - AgendaColaborador", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]AgendaColaboradorDtoSpecialized dto)
        {
            var result = new HttpResult<AgendaColaboradorDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - AgendaColaborador", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(AgendaColaboradorDto dto)
        {
            var result = new HttpResult<AgendaColaboradorDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - AgendaColaborador", dto);
            }
        }
    }
}
