using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Dto;
using Common.Domain.Enums;
using Common.API;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Calemas.Erp.Api.Controllers
{
	[Authorize]
    [Route("api/categoriaestoque/more")]
    public class CategoriaEstoqueMoreController : Controller
    {

        private readonly ICategoriaEstoqueRepository _rep;
        private readonly ICategoriaEstoqueApplicationService _app;
		private readonly ILogger _logger;

        public CategoriaEstoqueMoreController(ICategoriaEstoqueRepository rep, ICategoriaEstoqueApplicationService app, ILoggerFactory logger)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<CategoriaEstoqueMoreController>();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CategoriaEstoqueFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger);
            try
            {
                if (filters.FilterBehavior == FilterBehavior.GetDataItem)
                {
                    var searchResult = await this._rep.GetDataItem(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataCustom)
                {
                    var searchResult = await this._rep.GetDataCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataListCustom)
                {
                    var searchResult = await this._rep.GetDataListCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", filters);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<CategoriaEstoqueDtoSpecialized> dtos)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - CategoriaEstoque", dtos);
            }

        }

	[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<CategoriaEstoqueDtoSpecialized> dtos)
        {
            var result = new HttpResult<CategoriaEstoqueDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Calemas.Erp - CategoriaEstoque", dtos);
            }

        }

    }
}
