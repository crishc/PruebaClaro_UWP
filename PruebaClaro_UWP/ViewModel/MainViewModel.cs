using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using PruebaClaro_UWP.ViewModel.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;

namespace PruebaClaro_UWP.ViewModel
{
    public class MainViewModel : NotificationBase
    {
        #region Variables
        public IBusiness business;
        #endregion

        #region Propiedades
        private bool offline;
        public bool Offline
        {
            get { return offline; }
            set { SetProperty(ref offline, value); }
        }

        private Pelicula peliculaSeleccionada;
        public Pelicula PeliculaSeleccionada
        {
            get { return peliculaSeleccionada; }
            set { SetProperty(ref peliculaSeleccionada, value); }
        }
        #endregion

        #region Constructor
        public MainViewModel(IBusiness _business)
        {
            business = _business;
            Offline = !business.HayInternet;
            business.EventoCambioEstadoInternet += Business_EventoCambioEstadoInternet;
            business.EventoPeliculaSeleccionada += Business_EventoPeliculaSeleccionada;
        }
        #endregion

        #region EventHandlers
        private void Business_EventoPeliculaSeleccionada(object sender, Pelicula pelicula)
        {
            PeliculaSeleccionada = pelicula;
        }
        private async void Business_EventoCambioEstadoInternet(object sender, bool e)
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                 () =>
                 {
                     Offline = !e;
                 });
        }
        #endregion
    }
}
