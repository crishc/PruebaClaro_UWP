namespace PruebaClaro_UWP.Model.Data.SQLite.Entities
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Duracion { get; set; }
        public string Clasificacion { get; set; }
        public string UrlImagen { get; set; }
        public string Genero { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string Escritor { get; set; }
        public string Productor { get; set; }
        public string TítuloOriginal { get; set; }
    }
}