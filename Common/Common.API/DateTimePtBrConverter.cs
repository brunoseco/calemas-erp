using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.API
{
    public class DateTimePtBrConverter : DateTimeConverterBase
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DateTime.Parse(reader.Value.ToString());
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString("dd/MM/yyyy HH:mm"));
        }
    }
}
