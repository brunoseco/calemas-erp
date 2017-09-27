using System.Collections.Generic;
using Common.API;
using Common.Domain.Base;
using System;
using Microsoft.AspNetCore.Http;

namespace Calemas.Erp.CrossCuting
{
    public class ExportExcelCustom<T> : ExportExcel<T>
    {
        public ExportExcelCustom(FilterBase filter) : base(filter)
        {
            


        }

        public override byte[] ExportFile(HttpResponse response, IEnumerable<T> data, string nome)
        {
            var content = Export(data, nome);
            var dataAtual = DateTime.Now.ToString("d");

            var fileName = string.Concat(nome, "_", dataAtual.Replace("/", ""), ".xls");
            response.Headers.Add("content-disposition", "attachment; filename=Information" + fileName);
            response.ContentType = "application/vnd.ms-excel";
            return System.Text.Encoding.UTF8.GetBytes(content);
        } 
    }
}
