using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Http;
using MusicHouse.Models;
using Newtonsoft.Json.Linq;

namespace MusicHouse.Client
{
    public class ManageData
    {
        static readonly HttpClient client = new HttpClient();

        public ManageData(string baseUrl)
        {
            this.BaseUrl = baseUrl;
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private string BaseUrl { get; set; }

        public HttpResponseMessage CreateAsJson<T>(T obj, string controller)
        {
            return client.PostAsJsonAsync<T>(BaseUrl + controller, obj).Result;
        }

        public HttpResponseMessage CreateAsXML<T>(T obj, string controller)
        {
            return client.PostAsXmlAsync<T>(BaseUrl + controller, obj).Result;
        }

        public HttpResponseMessage Get(string controller)
        {
            return client.GetAsync(BaseUrl + controller).Result;
        }

        public HttpResponseMessage Get(string controller, int id)
        {
            return client.GetAsync(BaseUrl + controller + "/" + id).Result;
        }

        public HttpResponseMessage Delete(string controller, int id)
        {
            return client.DeleteAsync(BaseUrl + controller + "/" + id).Result;
        }

        public HttpResponseMessage UpdateAsJson<T>(T obj, string controller, int id)
        {
            string reqURL = BaseUrl + controller + "/" + id;

            return client.PutAsJsonAsync<T>(reqURL, obj).Result;
        }

        public HttpResponseMessage UpdateAsXML<T>(T obj, string controller, int id)
        {
            string reqURL = BaseUrl + controller + "/" + id;

            return client.PutAsXmlAsync<T>(reqURL, obj).Result;
        }
    }
}
