using GalaSoft.MvvmLight.Command;
using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.ViewModel.Common;
using System;
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
            PageLoadedCommand = new RelayCommand(PageLoaded);
        }

        private void PageLoaded()
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
