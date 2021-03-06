﻿using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using PruebaClaro_UWP.Model.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Net.Http;
using Windows.ApplicationModel.Resources;
using Newtonsoft.Json;
using System.Linq;

namespace PruebaClaro_UWP.Model.Services
{
    public class DataService : IDataService
    {
        public async Task<ObservableCollection<Pelicula>> ObtenerPeliculasAsync()
        {
            try
            {
                var loader = new ResourceLoader();
                string url = loader.GetString("ConsultaListaPeliculas");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                ObservableCollection<Pelicula> listaPeliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(responseBody);
                if (!response.IsSuccessStatusCode)
                {
                    return new ObservableCollection<Pelicula>();
                }
                return listaPeliculas;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new ObservableCollection<Pelicula>();
            }
        }
        public async Task<Pelicula> ObtenerPeliculasPorIdAsync(int id)
        {
            try
            {
                var loader = new ResourceLoader();
                string url = loader.GetString("ConsultaListaPeliculas");
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                ObservableCollection<Pelicula> listaPeliculas = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(responseBody);
                Pelicula pelicula = listaPeliculas.Where(p => p.Id == id).FirstOrDefault();
                if (!response.IsSuccessStatusCode)
                {
                    return new Pelicula();
                }
                return pelicula;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new Pelicula();
            }
        }
    }
}