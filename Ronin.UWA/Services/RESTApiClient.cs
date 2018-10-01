using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Web.Http;
using Windows.Data.Json;


namespace Ronin.UWA.Services
{
    public static class RESTApiClient
    {
        public static async Task<IEnumerable<T>> GetAsync<T>(string resName = null)
        {
            if (resName == null)
                resName = typeof(T).ToString().Split('.').Last();
            ApiObjectsTuple? objProfile = ApiObjectSelector.GetObjectProfile(typeof(T));
            if (objProfile != null)
            {

                HttpResponseMessage response = await App.HttpClient.GetAsync(new Uri(App.BaseApiUrl + resName), Windows.Web.Http.HttpCompletionOption.ResponseContentRead);
                var content = await response.Content.ReadAsStringAsync();
                var Items = JsonConvert.DeserializeObject<IEnumerable<T>>(content);
                return Items;
            }
            return null;
        }

        public static async Task<Uri> PostAsync<T>(T obj, string resName = null)
        {
            if (resName == null)
                resName = typeof(T).ToString().Split('.').Last();
            var jsonContent = new HttpStringContent(JsonConvert.SerializeObject(obj), Windows.Storage.Streams.UnicodeEncoding.Utf8, "application/json");
            HttpResponseMessage response = await App.HttpClient.PostAsync(new Uri(App.BaseApiUrl + resName), jsonContent);
            response.EnsureSuccessStatusCode();
            //if (response.IsSuccessStatusCode)
            return response.Headers.Location;
        }

        public static async Task<Uri> PutAsync<T>(T obj, string resName = null)
        {
            if (resName == null)
                resName = typeof(T).ToString().Split('.').Last();
            var jsonContent = new HttpStringContent(JsonConvert.SerializeObject(obj));

            HttpResponseMessage response = await App.HttpClient.PutAsync(new Uri(App.BaseApiUrl + resName), jsonContent);
            response.EnsureSuccessStatusCode();
            //if (response.IsSuccessStatusCode)
            return response.Headers.Location;
        }
    }
}
