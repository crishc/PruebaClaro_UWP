using PruebaClaro_UWP.Helpers;
using PruebaClaro_UWP.View;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace PruebaClaro_UWP
{
    public sealed partial class MainPage : Page
    {
        private RootFrameNavigationHelper _navHelper;

        public MainPage()
        {
            this.InitializeComponent();
            _navHelper = new RootFrameNavigationHelper(ContentFrame);
        }

        private void Shell_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked && Shell.SelectedItem != Shell.SettingsItem)
            {
                    ContentFrame.Navigate(typeof(Settings));
            }
            else if(args.InvokedItem.ToString().Equals("Ciencia ficción") && !((NavigationViewItem)Shell.SelectedItem).Content.ToString().Equals("Ciencia ficción"))
            {
                ContentFrame.Navigate(typeof(Movies));
            }
        }

        private void Shell_Loaded(object sender, RoutedEventArgs e)
        {
            Shell.SelectedItem = (NavigationViewItem)Shell.MenuItems[0];
            ContentFrame.Navigate(typeof(Movies));
        }
    }
}