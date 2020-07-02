using Flurl.Http;
using RentSite.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace RentSite.MobileApp
{
    public class APIService
    {
        private readonly string _route = null;

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int UserId { get; set; }

#if DEBUG
       private string _apiUrl = "http://localhost:5000/api";
#endif
#if RELEASE
       private string _apiUrl = "http://mywebsite.com/api";
#endif


        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object searchRequest = null)   
        {
            try
            {
                var query = "";
                if (searchRequest != null)
                {
                    query = await searchRequest?.ToQueryString();
                }

                var list = await $"{_apiUrl}/{_route}?{query}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
                return list;
            }
            catch (FlurlHttpException ex)
            {
                if (ex.Call.HttpStatus == System.Net.HttpStatusCode.Unauthorized)
                {
                    await Application.Current.MainPage.DisplayAlert("Warning!", "You are not authenticated!", "OK");
                }

                throw;
            }
        }

        public async Task<T> GetById<T>(object id)   
        {

            var url = $"{_apiUrl}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{_apiUrl}/{_route}";
            try
            {
                return await url.WithBasicAuth(Username, Password).PostJsonAsync(request).ReceiveJson<T>();
            }
            catch (FlurlHttpException ex)
            {
                var errors = await ex.GetResponseJsonAsync<Dictionary<string, string[]>>();

                var stringBuilder = new StringBuilder();
                foreach (var error in errors)
                {
                    stringBuilder.AppendLine($"{error.Key}, ${string.Join(",", error.Value)}");
                }

               await  Application.Current.MainPage.DisplayAlert("Warrning", stringBuilder.ToString(), "OK");

                return default(T);
            }
        }

        public async Task<T> Update<T>(int? id, object request)
        {
            var url = $"{_apiUrl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }

        public async Task<bool> Delete<T>(int? id)   
        {
            var url = $"{_apiUrl}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
        }
    }
}
