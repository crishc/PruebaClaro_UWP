using PruebaClaro_UWP.Model.Data.Repositories.Interfaces;
using PruebaClaro_UWP.Model.Data.SQLite;
using PruebaClaro_UWP.Model.Data.SQLite.Entities;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;

namespace PruebaClaro_UWP.Model.Data.Repositories
{
    public class DataRepository : IDataRepository
    {
        public async void InsertarPeliculas(ObservableCollection<Pelicula> peliculas)
        {
            try
            {
                using (var db = new DataContext())
                {
                    foreach (var item in peliculas)
                    {
                        if (db.Pelicula.Where(p=>p.Id==item.Id).FirstOrDefault() ==null)
                        {
                            await db.Pelicula.AddAsync(item);
                        }
                    }
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }
        public ObservableCollection<Pelicula> ObtenerPeliculas()
        {
            try
            {
                ObservableCollection<Pelicula> datosGuardados = new ObservableCollection<Pelicula>();
                using (var db = new DataContext())
                {
                    datosGuardados = new ObservableCollection<Pelicula>(db.Pelicula);
                }
                return datosGuardados;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new ObservableCollection<Pelicula>();
            }
        }
        public Pelicula ObtenerPeliculaPorId(int id)
        {
            try
            {
                Pelicula pelicula = new Pelicula();
                using (var db = new DataContext())
                {
                    pelicula = db.Pelicula.Where(p => p.Id == id).FirstOrDefault();
                }
                return pelicula;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                return new Pelicula();
            }
        }
    }
}