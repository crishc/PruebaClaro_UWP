using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.Model.Data.Repositories.Interfaces;
using PruebaClaro_UWP.Model.Services.Interfaces;
using System;
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
    }
}