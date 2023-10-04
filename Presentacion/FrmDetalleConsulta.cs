using Camiones.Entidades;
using Camiones.Servicios;
using Camiones.Servicios.Implementacion;
using Camiones.Servicios.Interfaz;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Camiones.Presentacion
{
    public partial class FrmDetalleConsulta : Form
    {
        int id;
        IServicio servicio;
        public FrmDetalleConsulta(FabricaServicioImp fabrica, int idCam, string patente, string estado, int pesoMax, int PesoOcu)
        {
            InitializeComponent();
            lblID.Text = lblID.Text + id;
            txtPatente.Text = patente;
            txtEstado.Text = estado;
            txtMax.Text = pesoMax.ToString();
            txtOcu.Text = PesoOcu.ToString();
            id = idCam;
            servicio = fabrica.CrearServicio();
        }

        private void FrmDetalleConsulta_Load(object sender, EventArgs e)
        {
            List<Parametro> lstP = new List<Parametro>();
            lstP.Add(new Parametro(@"id", id));

            List<Carga> lCargas = servicio.traerCargas(lstP);
            dgvCargas.Rows.Clear();

            foreach (Carga ca in lCargas)
            {
                dgvCargas.Rows.Add(new object[] { ca.Id,
                                                    ca.Peso,
                                                    ca.TipoCarga.Nombre
                    }); ;

            }
        }
    }
}
