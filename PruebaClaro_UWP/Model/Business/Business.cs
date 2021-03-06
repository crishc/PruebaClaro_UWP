﻿using PruebaClaro_UWP.Helpers;
using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.Model.Data.Repositories.Interfaces;
using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using PruebaClaro_UWP.Model.Data.SQLite.Types;
using PruebaClaro_UWP.Model.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Networking.Connectivity;

namespace PruebaClaro_UWP.Model.Business
{
    public class Business : IBusiness
    {
        #region Variables
        private IDataRepository dataRepository;
        private IDataService dataService;
        #endregion

        #region Propiedades
        public bool HayInternet { get; set; }
        public string TemaActual { get; set; }
        #endregion

        #region Eventos
        public event EventHandler<bool> EventoCambioEstadoInternet;
        public event EventHandler<Pelicula> EventoPeliculaSeleccionada;
        #endregion

        #region Constructor
        public Business(IDataRepository dataRepository, IDataService dataService)
        {
            this.dataRepository = dataRepository;
            this.dataService = dataService;
            InicioAplicacion();
        }
        #endregion

        #region Metodos privados
        private void InicioAplicacion()
        {
            VerificarConexionInternet();
            NetworkInformation.NetworkStatusChanged += VerificarConexionInternet;
        }
        private void VerificarConexionInternet(object sender = null)
        {
            var conexion = NetworkInformation.GetInternetConnectionProfile();
            if (conexion != null && conexion.GetNetworkConnectivityLevel() == NetworkConnectivityLevel.InternetAccess)
            {
                EventoCambioEstadoInternet?.Invoke(null, true);
                HayInternet = true;
            }
            else
            {
                EventoCambioEstadoInternet?.Invoke(null, false);
                HayInternet = false;
            }
        }
        #endregion

        #region Metodos publicos
        public async Task<ObservableCollection<PeliculaGeneral>> BuscarPelicula(string peliculaBuscar)
        {
            ObservableCollection<Pelicula> peliculasEncontradas = new ObservableCollection<Pelicula>();
            if (HayInternet)
            {
                peliculasEncontradas = await dataService.ObtenerPeliculasAsync();
            }
            else
            {
                peliculasEncontradas = dataRepository.ObtenerPeliculas();
            }

            if (peliculasEncontradas != null)
            {
                peliculasEncontradas = new ObservableCollection<Pelicula>(peliculasEncontradas.Where(x => x.Titulo.ToUpper().Contains(peliculaBuscar.ToUpper())));
            }
            return Converters.ConvertirColeccionAPeliculasSimples(peliculasEncontradas);
        }
        public async Task<ObservableCollection<PeliculaGeneral>> ObtenerPeliculasAsync()
        {
            ObservableCollection<Pelicula> datosRetorno = new ObservableCollection<Pelicula>();
            if (HayInternet)
            {
                datosRetorno = await dataService.ObtenerPeliculasAsync();
                if (datosRetorno != null)
                {
                         dataRepository.InsertarPeliculas(datosRetorno);
                }
                datosRetorno = dataRepository.ObtenerPeliculas();
            }
            else
            {
                datosRetorno = dataRepository.ObtenerPeliculas();
            }
            return Converters.ConvertirColeccionAPeliculasSimples(datosRetorno);
        }
        public async Task PeliculaSeleccionadaAsync(int id)
        {
            Pelicula peliculaSeleccionada = new Pelicula();
            if (HayInternet)
            {
                peliculaSeleccionada = await dataService.ObtenerPeliculasPorIdAsync(id);
            }
            else
            {
                peliculaSeleccionada = dataRepository.ObtenerPeliculaPorId(id);
            }

            EventoPeliculaSeleccionada?.Invoke(null, peliculaSeleccionada);
        }
        #endregion
    }
}