using Camiones.Servicios;
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
    public partial class FrmPrincipal : Form
    {
        FabricaServicioImp fabrica;
        public FrmPrincipal(FabricaServicioImp fabrica)
        {
            InitializeComponent();
            this.fabrica = fabrica;
        }

        private void nuevoCamionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCamiones(fabrica).ShowDialog();
        }

        private void subirCargaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmCargas(fabrica).ShowDialog();
        }

        private void consToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmConsulta(fabrica).ShowDialog();
        }

        private void camionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmReporteCamiones().ShowDialog();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {

        }
    }
}
