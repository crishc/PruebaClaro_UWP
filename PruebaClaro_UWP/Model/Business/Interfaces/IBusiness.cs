using System;

namespace PruebaClaro_UWP.Model.Business.Interfaces
{
    public interface IBusiness
    {
        event EventHandler<bool> EventoCambioEstadoInternet;

        string TemaActual { get; set; }
        bool HayInternet { get; }
    }
}