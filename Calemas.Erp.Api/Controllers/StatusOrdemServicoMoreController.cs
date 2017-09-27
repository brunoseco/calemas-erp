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
    [Route("api/statusordemservico/more")]
    public class StatusOrdemServicoMoreController : Controller
    {

        private readonly IStatusOrdemServicoRepository _rep;
        private readonly IStatusOrdemServicoApplicationService _app;
		private readonly ILogger _logger;

        public StatusOrdemServicoMoreController(IStatusOrdemServicoRepository rep, IStatusOrdemServicoApplicationService app, ILoggerFactory logger)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<StatusOrdemServicoMoreController>();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]StatusOrdemServicoFilter filters)
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
                    var file = export.ExportFile(this.Response, searchResult, "StatusOrdemServico");
                    return File(file, export.ContentTypeExcel(), export.GetFileName());
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusOrdemServico", filters);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<StatusOrdemServicoDtoSpecialized> dtos)
        {
            var result = new HttpResult<StatusOrdemServicoDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - StatusOrdemServico", dtos);
            }

        }

		[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<StatusOrdemServicoDtoSpecialized> dtos)
        {
            var result = new HttpResult<StatusOrdemServicoDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Calemas.Erp - StatusOrdemServico", dtos);
            }

        }

    }
}
