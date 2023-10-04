using Camiones.Entidades;
using Camiones.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Servicios.Interfaz
{
    public interface IServicio
    {
        int traerProximoPresupuesto();
        List<EstadoCamion> traerEstados();
        List<Camion> traerCamiones();
        List<Camion> traerCamionesFiltrados(List<Parametro> lParam);
        List<Carga> traerCargas(List<Parametro> lParam);
        List<TipoCarga> traerTiposCargas();
        bool SCrearCamion(Camion oCamion);
        bool SActualizarCamion(Camion oCamion);
        bool SAgregarCarga(Carga oCarga);
        bool SEliminarCarga(int id);
    }
}
