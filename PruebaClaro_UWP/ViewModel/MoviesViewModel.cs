using GalaSoft.MvvmLight.Command;
using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.Model.Data.SQLite.Types;
using PruebaClaro_UWP.ViewModel.Common;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace PruebaClaro_UWP.ViewModel
{
    public class MoviesViewModel : NotificationBase
    {

        #region Variables
        private IBusiness business;
        #endregion

        #region Propiedades
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

        private bool internetFalla;
        public bool InternetFalla
        {
            get { return internetFalla; }
            set { SetProperty(ref internetFalla, value); }
        }
        #endregion

        #region Comandos
        public ICommand PageLoadedCommand { get; private set; }
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
        }

        private async void PageLoadedAsync()
        {
            await CargarPantalla();
        }

        private async Task CargarPantalla()
        {
            CargarImagenRespectoATema();
            Peliculas = await business.ObtenerPeliculasAsync();
            if (Peliculas.Count() == 0)
            {
                InternetFalla = true;
            }
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
