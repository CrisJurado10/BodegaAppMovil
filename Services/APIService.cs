﻿using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using ProductoApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProductoApp.Services
{//dd
    public class APIService
    {
        public static string _baseUrl;
        public HttpClient _httpClient;

        public APIService()
        {

            _baseUrl = "https://apiproductos20231127163857.azurewebsites.net";
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_baseUrl);
        }

        public async Task<bool> DeleteProducto(int ProductoId)
        {
            var response = await _httpClient.DeleteAsync($"/api/Producto/{ProductoId}");

            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        public async Task<Producto> GetProducto(int ProductoId)
        {
            var response = await _httpClient.GetAsync($"/api/Producto/{ProductoId}");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto;
            }
            return new Producto();
        }

        public async Task<List<Producto>> GetProductos()
        {
            var response = await _httpClient.GetAsync("/api/Producto");
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(json_response);
                return productos;
            }
            return new List<Producto>();

        }

        public async Task<Producto> PostProducto(Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Producto/", content);
            Debug.WriteLine(content);
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public async Task<Producto> PutProducto(int ProductoId, Producto producto)
        {
            var content = new StringContent(JsonConvert.SerializeObject(producto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Producto/{ProductoId}", content);
            Debug.WriteLine(content);
            Debug.WriteLine(response);
            if (response.IsSuccessStatusCode)
            {
                var json_response = await response.Content.ReadAsStringAsync();
                Producto producto2 = JsonConvert.DeserializeObject<Producto>(json_response);
                return producto2;
            }
            return new Producto();
        }

        public Usuario PostUsuario(Usuario usuario)
        {
            if (usuario != null){
                if (usuario.Username.Equals("Cristian") && usuario.Password.Equals("1234"))
                {
                    return new Usuario
                    {
                        IdUsuario=100,
                        Username=usuario.Username,
                        Password="",
                    };
                }
            
            }

            return null;
        }

    }
}
