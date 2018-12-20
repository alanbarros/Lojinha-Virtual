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
        private readonly HttpClient _client;

        public Repositorio(HttpClient client)
        {
            client.BaseAddress = new Uri("http://localhost:5005");
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
            );

            _client = client;
        }

        public async Task<IList<Cliente>> GetClientesAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/clientes");
            if(response.IsSuccessStatusCode){
                var clientes = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Cliente>>(clientes);
            }
            return new List<Cliente>();
        }

        public async Task<IList<Usuario>> GetUsuariosAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("api/usuarios");
            if(response.IsSuccessStatusCode){
                var usuarios = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IList<Usuario>>(usuarios);
            }
            return new List<Usuario>();
        }

        public async Task<Usuario> GetUsuarioAsync(long Id){
            HttpResponseMessage response = await _client.GetAsync($"api/usuarios/{Id}");
            if(response.IsSuccessStatusCode){
                var usuario = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Usuario>(usuario);
            }
            return new Usuario();
        }

        public async Task<bool> PostUsuarioAsync(Usuario usuario){
            HttpResponseMessage response = await _client.PostAsJsonAsync("api/usuarios",usuario);
            if(response.IsSuccessStatusCode){
                return true;
            }
            return false;
        }

        public async Task<bool> PostUsuarioAsync(long? id, Usuario usuario){
            if(usuario.Id == id){
                HttpResponseMessage response = await _client.PutAsJsonAsync($"api/usuarios/{id}", usuario);
                if(response.IsSuccessStatusCode){
                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteUsuarioAsync(long? id){
            if(id != null){
                HttpResponseMessage response = await _client.DeleteAsync($"api/usuarios/{id}");
                if(response.IsSuccessStatusCode){
                    return true;
                }
            }
            return false;
        }
    }
    
}