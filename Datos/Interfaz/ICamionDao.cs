using Camiones.Entidades;
using Camiones.Presentacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Datos.Interfaz
{
    public interface ICamionDao
    {
        int obtenerProximoCamion();
        bool CrearCamion(Camion oCamion);
        bool ActualizarCamion(Camion oCamion);
        bool AgregarCarga(Carga oCarga);
        bool EliminarCarga(int id);
        List<EstadoCamion> obtenerEstados();
        List<Camion> obtenerCamiones();
        List<Camion> obtenerCamionesFiltrados(List<Parametro> lParam);
        List<Carga> obtenerCargas(List<Parametro> lParam);
        List<TipoCarga> obtenerTiposCargas();


    }
}
