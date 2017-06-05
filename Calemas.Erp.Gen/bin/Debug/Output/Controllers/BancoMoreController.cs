using System;
using System.Linq;
using System.Net;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Calemas.Erp.Application.Interfaces;
using Calemas.Erp.Domain.Filter;
using Calemas.Erp.Domain.Interfaces.Repository;
using Calemas.Erp.Dto;
using Common.Domain.Enums;
using Common.API;


namespace Calemas.Erp.Api.Controllers
{
	[Authorize]
    [Route("api/banco/more")]
    public class BancoMoreController : Controller
    {

        private readonly IBancoRepository _rep;
        private readonly IBancoApplicationService _app;
		private readonly ILogger _logger;

        public BancoMoreController(IBancoRepository rep, IBancoApplicationService app, ILoggerFactory logger)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<BancoController>();
        }

        [HttpGet]
        public IActionResult Get([FromQuery]BancoFilter filters)
        {
            var result = new HttpResult<dynamic>(this._logger);
            try
            {
                if (filters.FilterBehavior == FilterBehavior.GetDataItem)
                {
                    var searchResult = this._rep.GetDataItem(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataCustom)
                {
                    var searchResult = this._rep.GetDataCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                if (filters.FilterBehavior == FilterBehavior.GetDataListCustom)
                {
                    var searchResult = this._rep.GetDataListCustom(filters);
                    return result.ReturnCustomResponse(searchResult, filters);
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", filters);
            }
        }


        [HttpPost]
        public IActionResult Post([FromBody]IEnumerable<BancoDtoSpecialized> dtos)
        {
            var result = new HttpResult<BancoDto>(this._logger);
            try
            {
                var returnModels = this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - Banco", dtos);
            }

        }

    }
}