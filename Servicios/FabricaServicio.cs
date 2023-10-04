using Camiones.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Servicios
{
    public abstract class FabricaServicio
    {
        public abstract IServicio CrearServicio();
    }
}
