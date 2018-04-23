using GalaSoft.MvvmLight.Command;
using PruebaClaro_UWP.ViewModel.Common;
using System.Windows.Input;
using Windows.UI.Xaml;

namespace PruebaClaro_UWP.ViewModel
{
    public class SettingsViewModel : NotificationBase
    {
        #region Comandos
        private ICommand _cambiarTemaCommand;
        public ICommand CambiarTemaCommand
        {
            get { return _cambiarTemaCommand; }
        }
        #endregion

        #region Constructor
        public SettingsViewModel()
        {
            RegistrarComandos();
        }
        #endregion

        #region Metodos privados
        private void RegistrarComandos()
        {
            _cambiarTemaCommand = new RelayCommand<object>(CambiarTema);
        }

        private void CambiarTema(object Tema)
        {
            var selectedTheme = Tema.ToString();

            if (selectedTheme != null)
            {
                App.RootTheme = App.GetEnum<ElementTheme>(selectedTheme);
            }
        }
        #endregion

    }
}