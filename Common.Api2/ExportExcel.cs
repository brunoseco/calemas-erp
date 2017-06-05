using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Common.API
{
    public static class ExportExcel<T>
    {

        public static string Export(IEnumerable<T> data, string nome)
        {

            var xml = string.Empty;

            xml = "<?xml version=\"1.0\"?><ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">" +
                "<ss:Styles><ss:Style ss:ID=\"1\"><ss:Font ss:Bold=\"1\"/></ss:Style></ss:Styles>";

            xml += "<ss:Worksheet ss:Name=\"" + nome + "\">";
            xml += " <ss:Table>";

            xml += "  <ss:Row ss:StyleID=\"1\">";

            foreach (var item in data.FirstOrDefault().GetType().GetTypeInfo().GetProperties()
                .Where(_=>_.GetType().GetTypeInfo().IsClass))
            {
                var propriedade = item.Name;
                xml += "<ss:Cell><ss:Data ss:Type=\"String\">" + propriedade + "</ss:Data></ss:Cell>";
            };
            xml += "  </ss:Row>";

            foreach (var item in data)
            {
                var intancia = item;
                xml += " <ss:Row>";
                foreach (var subItem in item.GetType().GetTypeInfo().GetProperties()
                    .Where(_ => _.GetType().GetTypeInfo().IsClass))
                {
                    var valor = subItem.GetValue(item);
                    if (valor.IsNotNull())
                    {
                        var ehNumber = new Regex("/^\\d +$/").IsMatch(valor.ToString());
                        xml += "<ss:Cell><ss:Data ss:Type=\"" + ((ehNumber) ? "Number" : "String") + "\">" + valor + "</ss:Data></ss:Cell>";
                    }
                }
                xml += " </ss:Row>";
            }

            xml += "</ss:Table>";
            xml += "</ss:Worksheet>";
            xml += "</ss:Workbook>";

            return xml;
        }

    }
}
