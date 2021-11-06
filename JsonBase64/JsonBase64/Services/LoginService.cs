using JsonBase64.Model;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;

namespace JsonBase64.Services
{
    class UsuariosService
    {
        HttpClient client;
        private readonly string API_USUARIOS = "Usuarios";
        public UsuariosService()
        {
            client = new HttpClient();
        }
        public async System.Threading.Tasks.Task<string> RegisterAsync(Usuario usuario)
        {
            string result = string.Empty;
            if(usuario!=null && !string.IsNullOrEmpty(usuario.Name ) && !string.IsNullOrEmpty(usuario.Password))
            {
                result = JsonSerializer.Serialize(usuario);
                //TODO: Call to your own webAPI
                StringContent content = new StringContent(result, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;

                response = await client.PostAsync(AppResources.ApiResources.APIHOST + API_USUARIOS, content);
                if (response.IsSuccessStatusCode)
                {
                    var contenido = response.Content;
                    result = await contenido.ReadAsStringAsync();
                }
            }
            return result;
        }
    }
}
