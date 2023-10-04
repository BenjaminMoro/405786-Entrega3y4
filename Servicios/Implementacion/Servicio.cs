using Camiones.Datos.Implementacion;
using Camiones.Datos.Interfaz;
using Camiones.Entidades;
using Camiones.Presentacion;
using Camiones.Servicios.Interfaz;
using Microsoft.Reporting.Map.WebForms.VirtualEarth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Servicios.Implementacion
{
    public class Servicio : IServicio
    {
        private ICamionDao dao;

        public Servicio()
        {
            dao = new CamionDao();
        }

        public bool SActualizarCamion(Camion oCamion)
        {
            return dao.ActualizarCamion(oCamion);
        }

        public bool SAgregarCarga(Carga oCarga)
        {
            return dao.AgregarCarga(oCarga);
        }

        public bool SCrearCamion(Camion oCamion)
        {
            return dao.CrearCamion(oCamion);
        }

        public bool SEliminarCarga(int id)
        {
            return dao.EliminarCarga(id);
        }

        public List<Camion> traerCamiones()
        {
            return dao.obtenerCamiones();
        }

        public List<Camion> traerCamionesFiltrados(List<Parametro> lParam)
        {
            return dao.obtenerCamionesFiltrados(lParam);
        }

        public List<Carga> traerCargas(List<Parametro> lParam)
        {
            return dao.obtenerCargas(lParam);
        }

        public List<EstadoCamion> traerEstados()
        {
            return dao.obtenerEstados();
        }

        public int traerProximoPresupuesto()
        {
            return dao.obtenerProximoCamion();
        }

        public List<TipoCarga> traerTiposCargas()
        {
            return dao.obtenerTiposCargas();
        }
    }
}
