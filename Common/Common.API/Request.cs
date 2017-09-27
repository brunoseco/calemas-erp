using Common.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Common.Api
{
    public class Request : IRequest
    {
        private string baseAddress;
        private List<string> customHeaders;

        public Request()
        {
            this.customHeaders = new List<string>();
        }

        public void SetAddress(string address)
        {
            this.baseAddress = address;
        }
        public void AddHeaders(string item)
        {
            this.customHeaders.Add(item);
        }
        public TResult Get<TResult>(string resource, NameValueCollection queryStringParameters = null)
        {

            var parameters = new QueryStringParameter().Add(queryStringParameters);
            return this.Get<TResult>(resource, parameters);

        }

        public TResult Post<TResult, TModel>(string resource, TModel model)
        {
            var statusCode = default(HttpStatusCode);
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(this.baseAddress);

                if (this.customHeaders.IsAny())
                    AddHeaderInClientRequest(this.customHeaders.ToArray(), client);

                var json = JsonConvert.SerializeObject(model);
                var response = client.PostAsync(resource, new StringContent(json, Encoding.UTF8, "application/json")).Result;
                statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<TResult>(data);
                    return result;
                }
            }

            throw new InvalidOperationException(statusCode.ToString());
        }

        public TResult Get<TResult>(string resource, QueryStringParameter queryParameters = null)
        {
            var statusCode = default(HttpStatusCode);
            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri(this.baseAddress);

                if (this.customHeaders.IsAny())
                    AddHeaderInClientRequest(this.customHeaders.ToArray(), client);

                resource = MakeResource(resource, queryParameters);


                var response = client.GetAsync(resource).Result;
                statusCode = response.StatusCode;

                if (statusCode == HttpStatusCode.OK)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    var result = JsonConvert.DeserializeObject<TResult>(data);
                    return result;
                }
            }

            throw new InvalidOperationException(statusCode.ToString());
        }
        private string MakeResource(string resource, QueryStringParameter queryParameters)
        {
            if (queryParameters != null && queryParameters.Get() != null)
            {
                var queryStringUrl = queryParameters.Get().ToQueryString();
                resource = String.Concat(resource, queryStringUrl);
            }

            return resource;
        }
        private void AddHeaderInClientRequest(string[] headers, HttpClient client)
        {
            if (headers.IsAny())
            {
                foreach (var header in headers)
                {
                    var headerKey = header.Split(':')[0].Trim();
                    var headerValue = header.Split(':')[1].Trim();

                    if (headerKey == "Content-Type")
                        client.DefaultRequestHeaders
                            .Accept
                            .Add(new MediaTypeWithQualityHeaderValue(headerValue));
                    else
                        client.DefaultRequestHeaders.Add(headerKey, headerValue);
                }
            }
        } 
    }
}
