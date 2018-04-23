using System.Collections.Generic;

namespace PruebaClaro_UWP.Model.Data.SQLite.Types
{
    public class PeliculaType
    {
        public int Id { get; set; }
        public int Estado { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string Clasificacion { get; set; }
        public string UrlImagen { get; set; }
        public List<string> Genero { get; set; }
        public List<string> Actor { get; set; }
        public List<string> Director { get; set; }
        public List<string> Escritor { get; set; }
        public List<string> Productor { get; set; }
        public string TítuloOriginal { get; set; }

        public override string ToString()
        {
            return this.Titulo;
        }
    }
}