using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using PruebaClaro_UWP.Model.Business;
using PruebaClaro_UWP.Model.Business.Interfaces;
using PruebaClaro_UWP.Model.Data.Repositories;
using PruebaClaro_UWP.Model.Data.Repositories.Interfaces;
using PruebaClaro_UWP.Model.Services;
using PruebaClaro_UWP.Model.Services.Interfaces;

namespace PruebaClaro_UWP.ViewModel.Common
{
    public class ViewModelLocator
    {

        public DetailsViewModel Details => ServiceLocator.Current.GetInstance<DetailsViewModel>();
        public MoviesViewModel Movies => ServiceLocator.Current.GetInstance<MoviesViewModel>();
        public SettingsViewModel Settings => ServiceLocator.Current.GetInstance<SettingsViewModel>();

        static ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            RegistroServicios(SimpleIoc.Default);
            RegistroViewModel(SimpleIoc.Default);
        }
        private static void RegistroServicios(SimpleIoc ioc)
        {
            ioc.Register<IBusiness, Business>();
            ioc.Register<IDataRepository, DataRepository>();
            ioc.Register<IDataService, DataService>();
        }
        private static void RegistroViewModel(SimpleIoc ioc)
        {
            ioc.Register<DetailsViewModel>();
            ioc.Register<MoviesViewModel>();
            ioc.Register<SettingsViewModel>();
        }

    }
}