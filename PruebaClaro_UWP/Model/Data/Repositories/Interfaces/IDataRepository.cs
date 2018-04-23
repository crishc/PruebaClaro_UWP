using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using System.Collections.ObjectModel;

namespace PruebaClaro_UWP.Model.Data.Repositories.Interfaces
{
    public interface IDataRepository
    {
        void InsertarPeliculas(ObservableCollection<Pelicula> peliculas);
        ObservableCollection<Pelicula> ObtenerPeliculas();
        Pelicula ObtenerPeliculaPorId(int id);
    }
}