using GalaSoft.MvvmLight.Command;
using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.Model.Data.SQLite.Types;
using PruebaClaro_UWP.ViewModel.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.ApplicationModel.Core;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace PruebaClaro_UWP.ViewModel
{
    public class MoviesViewModel : NotificationBase
    {

        #region Variables
        private IBusiness business;
        #endregion

        #region Propiedades
        public ObservableCollection<PeliculaGeneral> listaResultado;
        public ObservableCollection<PeliculaGeneral> ListaResultado
        {
            get { return listaResultado; }
            set { SetProperty(ref listaResultado, value); }
        }

        private BitmapImage logoClaro;
        public BitmapImage LogoClaro
        {
            get { return logoClaro; }
            set { SetProperty(ref logoClaro, value); }
        }

        private ObservableCollection<PeliculaGeneral> peliculas;
        public ObservableCollection<PeliculaGeneral> Peliculas
        {
            get { return peliculas; }
            set { SetProperty(ref peliculas, value); }
        }

        private PeliculaGeneral peliculaSeleccionada;
        public PeliculaGeneral PeliculaSeleccionada
        {
            get { return peliculaSeleccionada; }
            set
            {
                if (value != peliculaSeleccionada && value != null)
                {
                    business.PeliculaSeleccionadaAsync(value.Id);
                }
                SetProperty(ref peliculaSeleccionada, value);
            }
        }

        private bool internetFalla;
        public bool InternetFalla
        {
            get { return internetFalla; }
            set { SetProperty(ref internetFalla, value); }
        }

        private string query;
        public string Query
        {
            get { return query; }
            set { SetProperty(ref query, value); }
        }
        #endregion

        #region Comandos
        public ICommand PageLoadedCommand { get; private set; }
        public ICommand TextChangedCommand { get; private set; }
        public ICommand QuerySubmittedCommand { get; private set; }
        #endregion

        #region Constructor
        public MoviesViewModel(IBusiness _business)
        {
            business = _business;
            RegistrarComandos();
        }
        #endregion

        #region Metodos privados 
        private void RegistrarComandos()
        {
            PageLoadedCommand = new RelayCommand(PageLoadedAsync);
            QuerySubmittedCommand = new RelayCommand<AutoSuggestBoxQuerySubmittedEventArgs>(QuerySubmittedChanged);
            TextChangedCommand = new RelayCommand<object>(TextChanged);
        }
        private async void TextChanged(object data)
        {
            ListaResultado = await business.BuscarPelicula(Query);
        }
        private void QuerySubmittedChanged(AutoSuggestBoxQuerySubmittedEventArgs data)
        {
            if (data.ChosenSuggestion != null)
            {
                Query = "";
                PeliculaSeleccionada = (PeliculaGeneral)data.ChosenSuggestion;
            }
            //ListaResultado = await bussinesLayer.BuscarPelicula(TextoBuscador);
        }

        private async void PageLoadedAsync()
        {
            await CargarPantalla();
        }

        private async Task CargarPantalla()
        {
            CargarImagenRespectoATema();
            Peliculas = new ObservableCollection<PeliculaGeneral>();
            if (Peliculas.Count == 0)
            {
                Peliculas = await business.ObtenerPeliculasAsync();
            }
            if (Peliculas.Count() == 0)
            {
                InternetFalla = true;
                business.EventoCambioEstadoInternet += Business_EventoCambioEstadoInternet;
            }
        }

        private async void Business_EventoCambioEstadoInternet(object sender, bool e)
        {
            if (e)
            {
                await SolicitarPeliculasAsync();
            }
        }

        private async Task SolicitarPeliculasAsync()
        {
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
                async () =>
                {
                    Peliculas = await business.ObtenerPeliculasAsync();
                    if (Peliculas.Count() > 0)
                    {
                        InternetFalla = false;
                        business.EventoCambioEstadoInternet += Business_EventoCambioEstadoInternet;
                    }
                });

        }

        private void CargarImagenRespectoATema()
        {
            if (business.TemaActual == "Light")
            {
                LogoClaro = new BitmapImage(new Uri("ms-appx:///Assets/Iconos/LogoNegro.png"));
            }
            else
            {
                LogoClaro = new BitmapImage(new Uri("ms-appx:///Assets/Iconos/Logo.png"));

            }
        }
        #endregion
    }
}
