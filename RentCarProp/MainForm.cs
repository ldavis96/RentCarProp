using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCarProp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Está Seguro?", "Confirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                //Se quedará en el form
            }
            else
            {
                this.Close();
                base.OnClick(e);
            }
        }

        private void tandaLaboralToolStripMenuItem_Click(object sender, EventArgs e)
        {
           WorkOrder tandalaboral = new WorkOrder();
           tandalaboral.MdiParent = this;
           tandalaboral.Show();
        }

        private void gestionarEmpleadoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewEmployee gestionarEmpleado = new NewEmployee();
            gestionarEmpleado.ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void tipoDeVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VehicleType tipoVehiculo = new VehicleType();
            tipoVehiculo.Show();
        }

        private void marcasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Marks marcas = new Marks();
            marcas.Show();
        }

        private void tipoDeCombustibleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FuelType tipoCombustible = new FuelType();
            tipoCombustible.Show();
        }

        private void modeloVehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Models modelos = new Models();
            modelos.Show();
        }

        private void vehículoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Vehycle veh = new Vehycle();
            veh.Show();
        }

        private void clienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client client = new Client();
            client.Show();
        }

        private void inspecciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Inspection ins = new Inspection();
            ins.Show();
        }

        private void rentaDevoluciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RentCar rentc = new RentCar();
            rentc.Show();
        }

        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports repo = new Reports();
            repo.Show();
        }
    }
}
