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
    public class NivelAcessoController : Controller
    {

        private readonly INivelAcessoApplicationService _app;
		private readonly ILogger _logger;
		private readonly IHostingEnvironment _env;
      
        public NivelAcessoController(INivelAcessoApplicationService app, ILoggerFactory logger, IHostingEnvironment env)
        {
            this._app = app;
			this._logger = logger.CreateLogger<NivelAcessoController>();
			this._env = env;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]NivelAcessoFilter filters)
        {
            var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]NivelAcessoFilter filters)
		{
			var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
				filters.NivelAcessoId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]NivelAcessoDtoSpecialized dto)
        {
            var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]NivelAcessoDtoSpecialized dto)
        {
            var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(NivelAcessoDto dto)
        {
            var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app, dto);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", dto);
            }
        }



    }
}
