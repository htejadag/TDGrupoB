namespace TDB.Gateway.Aplicacion.ProductosClient
{
    public partial class Client
    {

        public Client(System.Net.Http.IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("MsMaestro");
            _settings = new System.Lazy<Newtonsoft.Json.JsonSerializerSettings>(CreateSerializerSettings);
        }

    }
}
