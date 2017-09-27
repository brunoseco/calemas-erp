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
using Calemas.Erp.CrossCuting;
using Calemas.Erp.Domain.Entitys;

namespace Calemas.Erp.Api.Controllers
{
	[Authorize]
    [Route("api/tipoordemservico/more")]
    public class TipoOrdemServicoMoreController : Controller
    {

        private readonly ITipoOrdemServicoRepository _rep;
        private readonly ITipoOrdemServicoApplicationService _app;
		private readonly ILogger _logger;

        public TipoOrdemServicoMoreController(ITipoOrdemServicoRepository rep, ITipoOrdemServicoApplicationService app, ILoggerFactory logger)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<TipoOrdemServicoMoreController>();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]TipoOrdemServicoFilter filters)
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
				
				if (filters.FilterBehavior == FilterBehavior.Export)
                {
					var searchResult = await this._rep.GetDataListCustom(filters);
                    var export = new ExportExcelCustom<dynamic>(filters);
                    var file = export.ExportFile(this.Response, searchResult, "TipoOrdemServico");
                    return File(file, export.ContentTypeExcel(), export.GetFileName());
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", filters);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<TipoOrdemServicoDtoSpecialized> dtos)
        {
            var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - TipoOrdemServico", dtos);
            }

        }

		[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<TipoOrdemServicoDtoSpecialized> dtos)
        {
            var result = new HttpResult<TipoOrdemServicoDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Calemas.Erp - TipoOrdemServico", dtos);
            }

        }

    }
}
