using GalaSoft.MvvmLight.Command;
using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.ViewModel.Common;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace PruebaClaro_UWP.ViewModel
{
    public class SettingsViewModel : NotificationBase
    {

        #region Variables
        private IBusiness business;
        #endregion

        #region Comandos
        public ICommand CambiarTemaCommand { get; private set; }
        #endregion

        #region Constructor
        public SettingsViewModel(IBusiness _business)
        {
            business = _business;
            RegistrarComandos();
        }
        #endregion

        #region Metodos privados
        private void RegistrarComandos()
        {
            CambiarTemaCommand = new RelayCommand<object>(CambiarTema);
        }

        private void CambiarTema(object Tema)
        {
            string selectedTheme = Tema.ToString();

            if (selectedTheme != null)
            {
                App.RootTheme = App.GetEnum<ElementTheme>(selectedTheme);
            }
            business.TemaActual = selectedTheme;
        }
        #endregion

    }
}