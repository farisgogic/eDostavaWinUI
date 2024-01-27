using eDostava.Model;
using Flurl.Http;
using System.Text;

namespace eDostava.WinUI
{
    public class APIService
    { 
        private string _resource = null;
        public string _endpoint = "http://localhost:7068/api/";

        public static string userName = null;
        public static string password = null;

        public APIService(string resource)
        {
            _resource = resource;
        }

        public async Task<T> Get<T>(object search = null)
        {
            var query = "";
            if(search != null)
            {
                query = await search.ToQueryString();
            }
            var list = await $"{_endpoint}{_resource}?{query}".WithBasicAuth(userName,password).GetJsonAsync<T>();
            
            return list;
        }

        public async Task<T> GetById<T>(object id)
        {
            var result = await $"{_endpoint}{_resource}/{id}".WithBasicAuth(userName, password).GetJsonAsync<T>();

            return result;
        }

        public async Task<T> Post<T>(object request)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}".WithBasicAuth(userName, password).PostJsonAsync(request).ReceiveJson<T>();
                return result;
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

        public async Task<T> Put<T>(object id, object request)
        {
            try
            {
                var result = await $"{_endpoint}{_resource}/{id}".WithBasicAuth(userName, password).PutJsonAsync(request).ReceiveJson<T>();
                return result;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception in Put method: {ex.Message}");
                throw;
            }
        }

        public async Task<List<Korisnik>> GetKorisnici()
        {
            var query = $"?korisnickoime={userName}";

            var list = await $"{_endpoint}{_resource}{query}".WithBasicAuth(userName, password).GetJsonAsync<List<Korisnik>>();

            return list;
        }

        public async Task<Restoran> GetRestaurantByKorisnikId(int korisnikId)
        {
            var restoran = await $"{_endpoint}{_resource}".WithBasicAuth(userName, password).GetJsonAsync<List<Restoran>>();
            return restoran.FirstOrDefault(r => r.KorisnikId == korisnikId);
        }

        public async Task<List<T>> GetByName<T>(string naziv)
        {
            var query = $"naziv={naziv}";
            var list = await $"{_endpoint}{_resource}?{query}".GetJsonAsync<List<T>>();
            return list;
        }

        public async Task<List<Narudzba>> GetNarudzbaByRestoranId(int restoranId)
        {
            var query = $"RestoranId={restoranId}";
            var narudzbe = await $"{_endpoint}{_resource}?{query}".WithBasicAuth(userName, password).GetJsonAsync<List<Narudzba>>();
            return narudzbe;
        }

        public async Task<T> Update<T>(object id, object request)
        {
            var result = await $"{_endpoint}{_resource}/{id}".WithBasicAuth(userName, password).PutJsonAsync(request).ReceiveJson<T>();
            return result;
        }

    }
}
