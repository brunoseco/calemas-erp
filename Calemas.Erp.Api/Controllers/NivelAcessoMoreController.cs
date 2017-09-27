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
    [Route("api/nivelacesso/more")]
    public class NivelAcessoMoreController : Controller
    {

        private readonly INivelAcessoRepository _rep;
        private readonly INivelAcessoApplicationService _app;
		private readonly ILogger _logger;

        public NivelAcessoMoreController(INivelAcessoRepository rep, INivelAcessoApplicationService app, ILoggerFactory logger)
        {
            this._rep = rep;
            this._app = app;
			this._logger = logger.CreateLogger<NivelAcessoMoreController>();
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery]NivelAcessoFilter filters)
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
                    var file = export.ExportFile(this.Response, searchResult, "NivelAcesso");
                    return File(file, export.ContentTypeExcel(), export.GetFileName());
                }

                throw new InvalidOperationException("invalid FilterBehavior");

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", filters);
            }
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody]IEnumerable<NivelAcessoDtoSpecialized> dtos)
        {
            var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
                var returnModels = await this._app.Save(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex,"Calemas.Erp - NivelAcesso", dtos);
            }

        }

		[HttpPut]
        public async Task<IActionResult> Put([FromBody]IEnumerable<NivelAcessoDtoSpecialized> dtos)
        {
            var result = new HttpResult<NivelAcessoDto>(this._logger);
            try
            {
                var returnModels = await this._app.SavePartial(dtos);
                return result.ReturnCustomResponse(this._app, returnModels);

            }
            catch (Exception ex)
            {
                return result.ReturnCustomException(ex, "Calemas.Erp - NivelAcesso", dtos);
            }

        }

    }
}
