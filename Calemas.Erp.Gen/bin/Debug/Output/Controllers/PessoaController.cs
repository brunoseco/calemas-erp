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
    public class PessoaController : Controller
    {

        private readonly IPessoaApplicationService _app;
		private readonly ILogger _logger;


        public PessoaController(IPessoaApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<PessoaController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]PessoaFilter filters)
        {
            var result = new HttpResult<PessoaDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Pessoa", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]PessoaFilter filters)
		{
			var result = new HttpResult<PessoaDto>(this._logger);
            try
            {
				filters.PessoaId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Pessoa", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]PessoaDtoSpecialized dto)
        {
            var result = new HttpResult<PessoaDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Pessoa", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]PessoaDtoSpecialized dto)
        {
            var result = new HttpResult<PessoaDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Pessoa", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(PessoaDto dto)
        {
            var result = new HttpResult<PessoaDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Pessoa", dto);
            }
        }
    }
}
