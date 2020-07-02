using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flurl.Http;
using Flurl;
using RentSite.Model;
using System.Windows.Forms;

namespace RentSite.WinUI
{
   
    public class APIService 
    {
        private readonly string _route = null;
        public string endpoint = $"{Properties.Settings.Default.API}";

        public static string Username { get; set; }
        public static string Password { get; set; }
        public static int UserId{ get; set; }

        public APIService(string route)
        {
            _route = route;
        }

        public async Task<T> Get<T>(object searchRequest = null) 
        {
            var query = "";
            if (searchRequest!=null)
            {
                query = await searchRequest?.ToQueryString();
            }

            var list = await $"{endpoint}/{_route}?{query}".WithBasicAuth(Username, Password).GetJsonAsync<T>();
            return list;
        }

        public async Task<T> GetById<T>(object id)  
        {

            var url = $"{endpoint}/{_route}/{id}";

            return await url.WithBasicAuth(Username, Password).GetJsonAsync<T>();
        }
        public async Task<T> Insert<T>(object request)
        {
            var url = $"{endpoint}/{_route}";
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

                MessageBox.Show(stringBuilder.ToString(), "Greška", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return default(T);
            }
        }

        public async Task<T> Update<T>(int? id, object request)
        {
            var url = $"{endpoint}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).PutJsonAsync(request).ReceiveJson<T>();
        }
        public async Task<bool> Delete<T>(int? id)  
        {
            var url = $"{endpoint}/{_route}/{id}";
            return await url.WithBasicAuth(Username, Password).DeleteAsync().ReceiveJson<bool>();
        }
    }
}
