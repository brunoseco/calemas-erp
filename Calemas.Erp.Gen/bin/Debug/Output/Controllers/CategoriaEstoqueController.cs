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
    public class CategoriaEstoqueController : Controller
    {

        private readonly ICategoriaEstoqueApplicationService _app;
		private readonly ILogger _logger;


        public CategoriaEstoqueController(ICategoriaEstoqueApplicationService app, ILoggerFactory logger)
        {
            this._app = app;
			this._logger = logger.CreateLogger<CategoriaEstoqueController>();
			
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CategoriaEstoqueFilter filters)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
                var searchResult = await this._app.GetByFilters(filters);
                return result.ReturnCustomResponse(this._app, searchResult, filters);


            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", filters);
            }

        }


        [HttpGet("{id}")]
		public async Task<IActionResult> Get(int id, [FromQuery]CategoriaEstoqueFilter filters)
		{
			var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
				filters.CategoriaEstoqueId = id;
                var returnModel = await this._app.GetOne(filters);
                return result.ReturnCustomResponse(this._app, returnModel);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", id);
            }

		}




        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CategoriaEstoqueDtoSpecialized dto)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
                var returnModel = await this._app.Save(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", dto);
            }
        }



        [HttpPut]
        public async Task<IActionResult> Put([FromBody]CategoriaEstoqueDtoSpecialized dto)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
                var returnModel = await this._app.SavePartial(dto);
                return result.ReturnCustomResponse(this._app, returnModel);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", dto);
            }
        }


        [HttpDelete]
        public async Task<IActionResult> Delete(CategoriaEstoqueDto dto)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
                await this._app.Remove(dto);
                return result.ReturnCustomResponse(this._app);
            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", dto);
            }
        }
    }
}
