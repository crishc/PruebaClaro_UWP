using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace PruebaClaro_UWP.View
{
    public sealed partial class Movies : Page
    {
        public Movies()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            if(e.SourcePageType == typeof(Details) && listView.SelectedItem != null)
            {
                listView.PrepareConnectedAnimation("imagenPelicula", listView.SelectedItem, "ImagenPeliculaAnim");
            }
        }

    }
}