using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using PruebaClaro_UWP.Model.Data.SQLite.Types;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace PruebaClaro_UWP.Model.Business.Interfaces
{
    public interface IBusiness
    {
        event EventHandler<bool> EventoCambioEstadoInternet;
        event EventHandler<Pelicula> EventoPeliculaSeleccionada;

        string TemaActual { get; set; }
        bool HayInternet { get; }

        Task<ObservableCollection<PeliculaGeneral>> BuscarPelicula(string peliculaBuscar);
        Task<ObservableCollection<PeliculaGeneral>> ObtenerPeliculasAsync();
        Task PeliculaSeleccionadaAsync(int id);
    }
}