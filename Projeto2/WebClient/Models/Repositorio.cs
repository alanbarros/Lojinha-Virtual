using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Modelos;
using Newtonsoft.Json;

namespace WebClient.Models
{
    public class Repositorio
    {
        public HttpClient Client { get; }

        public Repositorio(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5005");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );
        }

        public async Task<IList<Cliente>> GetClientesAsync()
        {
            HttpResponseMessage response = await Client.GetAsync("api/clientes");
            if(response.IsSuccessStatusCode){
                var clientes = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Cliente>>(clientes);
            }
            return new List<Cliente>();
        }

        public async Task<IList<Usuario>> GetUsuariosAsync()
        {
            HttpResponseMessage response = await Client.GetAsync("api/usuarios");
            if(response.IsSuccessStatusCode){
                var usuarios = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Usuario>>(usuarios);
            }
            return new List<Usuario>();
        }
    }
    
}