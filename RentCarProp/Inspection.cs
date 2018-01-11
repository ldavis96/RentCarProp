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
    public partial class Inspection : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public Inspection()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }
        private void loadDataCliente()
        {
            var Clientlist = (from c in bd.Clientes
                           select c).ToList();

            this.cbx_cliente.DataSource = Clientlist;
            this.cbx_cliente.DisplayMember = "Nombre";
            this.cbx_cliente.ValueMember = "Id_Cliente";
        }
        private void loadDataVehiculo()
        {
            var Vehlist = (from c in bd.Vehiculos
                               select c).ToList();

            this.cbx_vehiculo.DataSource = Vehlist;
            this.cbx_vehiculo.DisplayMember = "Descripcion";
            this.cbx_vehiculo.ValueMember = "Id_Vehiculo";
        }
        private void loadDataEmpleado()
        {
            var Emplist = (from c in bd.Empleados
                           select c).ToList();

            this.cbx_empleado.DataSource = Emplist;
            this.cbx_empleado.DisplayMember = "Nombre";
            this.cbx_empleado.ValueMember = "Id_Empleado";
        }
        private void loadDataGrid()
        {
            var tolist = (from c in bd.Inspeccions
                               select c).ToList();

            this.dataGridView1.DataSource = tolist.ToList();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Disponible;\'\';Rentado";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[11].DefaultCellStyle = dataGridViewCellStyle1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(cbx_cliente.Text)) && !(string.IsNullOrEmpty(cbx_empleado.Text)) &&
                !(string.IsNullOrEmpty(cbx_estado.Text)) && !(string.IsNullOrEmpty(cbx_estado_cristal.Text)) &&
                !(string.IsNullOrEmpty(cbx_galones.Text)) && !(string.IsNullOrEmpty(cbx_gato.Text)) &&
                !(string.IsNullOrEmpty(cbx_rayadura.Text)) && !(string.IsNullOrEmpty(cbx_repuesto.Text)) &&
                !(string.IsNullOrEmpty(cbx_rotura_cristal.Text)) && !(string.IsNullOrEmpty(cbx_vehiculo.Text)) &&
                !(string.IsNullOrEmpty(cbx_estado_gomas.Text)))
            {
                Inspeccion ins = new Inspeccion();

                ins.Id_Cliente = int.Parse(cbx_cliente.SelectedValue.ToString());
                ins.Empleado_inspeccion = int.Parse(cbx_empleado.SelectedValue.ToString());
                ins.Vehiculo = int.Parse(cbx_vehiculo.SelectedValue.ToString());
                ins.Tiene_Ralladuras = cbx_rayadura.Text.ToString() == "Sí" ? 1 : 0;
                ins.Cantidad_Conbustible = cbx_galones.Text.ToString();
                ins.TieneGomaRepuesto = cbx_repuesto.Text.ToString();
                ins.TieneGato = cbx_gato.Text.ToString();
                ins.TieneRoturaCrsital = cbx_rotura_cristal.Text.ToString();
                ins.EstadoGomas = cbx_estado_gomas.Text.ToString();
                ins.Fecha = FechaIngreso.Value.Date;
                ins.Estado = cbx_estado.Text.ToString() == "Disponible" ? 1 : 0;

                bd.Inspeccions.Add(ins);
                MessageBox.Show("Inspección agregada con éxito");
                bd.SaveChanges();
                loadDataGrid();

                cbx_cliente.SelectedIndex = -1;
                cbx_empleado.SelectedIndex = -1;
                cbx_vehiculo.SelectedIndex = -1;
                cbx_rayadura.SelectedIndex = -1;
                cbx_galones.SelectedIndex = -1;
                cbx_repuesto.SelectedIndex = -1;
                cbx_gato.SelectedIndex = -1;
                cbx_rotura_cristal.SelectedIndex = -1;
                cbx_estado_gomas.SelectedIndex = -1;
                cbx_estado.SelectedIndex = -1;                
            }
            else
            {
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;
                string caption = "Advertencia";
                string message = "Favor Completar todos los campos!";

                result = MessageBox.Show(message, caption, buttons);
            }
        }

        private void button2_Click(object sender, EventArgs e)
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

        private void Inspection_Load(object sender, EventArgs e)
        {
            loadDataCliente();
            loadDataEmpleado();
            loadDataVehiculo();
            loadDataGrid();
        }
    }
}
