using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

namespace PruebaClaro_UWP.View
{
    public sealed partial class Details : Page
    {
        public Details()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            ConnectedAnimation imageAnimation =
                ConnectedAnimationService.GetForCurrentView().GetAnimation("imagenPelicula");
            if (imageAnimation != null)
            {
                imageAnimation.TryStart(Imagen);
            }
        }

    }
}