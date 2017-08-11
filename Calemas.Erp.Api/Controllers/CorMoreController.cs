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
    [Route("api/cor/more")]
    public class CorMoreController : Controller
    {

        private readonly ICorRepository _rep;
        private readonly ICorApplicationService _app;
		private readonly ILogger _logger;

        public CorMoreController(ICorRepository rep, ICorApplicationService app, ILoggerFactory logger)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<CorMoreController>();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]CorFilter filters)
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
                return result.ReturnCustomException(ex,"Calemas.Erp - Cor", filters);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<CorDtoSpecialized> dtos)
        {
            var result = new HttpResult<CorDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Cor", dtos);
            }

        }

	[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<CorDtoSpecialized> dtos)
        {
            var result = new HttpResult<CorDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Calemas.Erp - Cor", dtos);
            }

        }

    }
}
