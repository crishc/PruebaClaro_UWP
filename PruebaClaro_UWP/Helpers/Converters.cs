using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using PruebaClaro_UWP.Model.Data.SQLite.Types;
using System;
using System.Collections.ObjectModel;

namespace PruebaClaro_UWP.Helpers
{
    public static class Converters
    {
        public static ObservableCollection<PeliculaGeneral> ConvertirColeccionAPeliculasSimples(ObservableCollection<Pelicula> db_coleccionPeliculas)
        {
            ObservableCollection<PeliculaGeneral> nuevaColeccion = new ObservableCollection<PeliculaGeneral>();
            foreach (var item in db_coleccionPeliculas)
            {
                nuevaColeccion.Add(ConvertirPeliculaASimple(item));
            }
            return nuevaColeccion;
        }

        private static PeliculaGeneral ConvertirPeliculaASimple(Pelicula item)
        {
            return new PeliculaGeneral()
            {
                Id = item.Id,
                Titulo = item.Titulo,
                Duracion = item.Duracion,
                UrlImagen = item.UrlImagen
            };
        }
    }
}
