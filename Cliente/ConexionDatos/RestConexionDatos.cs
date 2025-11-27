using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Cliente.ConexionDatos
{
    public class RestConexionDatos : IRestConexionDatos
    {
        public readonly HttpClient httpClient;
        private readonly string dominio;
        private readonly string url;
        private readonly JsonSerializerOptions jsonSerializerOptions;
        public RestConexionDatos()
        {
            httpClient = new HttpClient();
            dominio = DeviceInfo.Platform == DevicePlatform.Android? "http://10.0.2.2:5018": "http://localhost:5018";
        }
        public Task AddPlato(Plato plato)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlato(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Plato>> ObtenerPlatos()
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlato(Plato plato)
        {
            throw new NotImplementedException();
        }
    }
}
