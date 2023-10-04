using Camiones.Entidades;
using Camiones.Servicios;
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
    public partial class FrmConsulta : Form
    {
        List<Camion> lCamiones;
        IServicio servicio;
        FabricaServicioImp fabrica;
        public FrmConsulta(FabricaServicioImp fabrica)
        {
            InitializeComponent();
            lCamiones = new List<Camion>();
            this.fabrica = fabrica;
            servicio = fabrica.CrearServicio();
        }

        private void FrmConsulta_Load(object sender, EventArgs e)
        {

        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            List<Parametro> lstP = new List<Parametro>();
            lstP.Add(new Parametro("@patente", txtPatente.Text));

            lCamiones = servicio.traerCamionesFiltrados(lstP);
            dgvCamiones.Rows.Clear();

            foreach (Camion c in lCamiones)
            {
                dgvCamiones.Rows.Add(new object[] { c.Id,
                                                    c.Patente,
                                                    c.EstadoCamion.Nombre,
                                                    c.PesoMaximo,
                                                    c.PesoOcupado
                    });
            }
        }

        private void dgvCamiones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCamiones.CurrentCell.ColumnIndex == 5)
            {
                DataGridViewRow selectedRow = dgvCamiones.Rows[e.RowIndex];

                int id = Convert.ToInt32(selectedRow.Cells["ColID"].Value);
                string pat = selectedRow.Cells["ColPatente"].Value.ToString();
                string est = selectedRow.Cells["ColEstado"].Value.ToString();
                int max = Convert.ToInt32(selectedRow.Cells["ColPesoMax"].Value);
                int ocu = Convert.ToInt32(selectedRow.Cells["ColPesoOcu"].Value);

                new FrmDetalleConsulta(fabrica,id,pat,est,max,ocu).ShowDialog();
            }
        }
    }
}
