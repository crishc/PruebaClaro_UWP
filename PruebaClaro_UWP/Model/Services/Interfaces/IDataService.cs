using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PruebaClaro_UWP.Model.Services.Interfaces
{
    public interface IDataService
    {
        Task<ObservableCollection<Pelicula>> ObtenerPeliculasAsync();
    }
}
