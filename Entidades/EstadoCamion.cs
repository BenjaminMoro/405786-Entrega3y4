using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Camiones.Entidades
{
    public class EstadoCamion
    {
        public int Id { get; set; }
        public int Estado { get; set; }

        public string Nombre { get; set; }

        public EstadoCamion(int nombre, int id)
        {
            Estado = nombre;
            Id = id;
        }

        public EstadoCamion(string nombre, int id)
        {
            Nombre = nombre;
            Id = id;
        }

        public override string ToString()
        {
            return Estado.ToString();
        }
    }
}
