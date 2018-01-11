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
    public partial class Vehycle : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public Vehycle()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }

        private void loadDataTipoVehiculo()
        {
            var tipoVehlist = (from c in bd.Tipos_Vehículos
                             select c).ToList();

            this.cbx_TipoVehiculo.DataSource = tipoVehlist;
            this.cbx_TipoVehiculo.DisplayMember = "Descripcion";
            this.cbx_TipoVehiculo.ValueMember = "Id";
        }
        private void loadDataMarca()
        {
            var Marklist = (from c in bd.Marcas
                               select c).ToList();

            this.cbx_Marca.DataSource = Marklist;
            this.cbx_Marca.DisplayMember = "Descripcion";
            this.cbx_Marca.ValueMember = "Id_Marca";
        }
        private void loadDataModelo()
        {
            var Modelolist = (from c in bd.Modelos
                                select c).ToList();

            this.cbx_Modelo.DataSource = Modelolist;
            this.cbx_Modelo.DisplayMember = "Descripcion";
            this.cbx_Modelo.ValueMember = "Id_Modelo";
        }
        private void loadDataTipoCombustible()
        {
            var tipoComlist = (from c in bd.Tipos_Combustible
                              select c).ToList();

            this.cbx_TipoCombustible.DataSource = tipoComlist;
            this.cbx_TipoCombustible.DisplayMember = "Descripcion";
            this.cbx_TipoCombustible.ValueMember = "Id_Combustible";
        }
        private void loadDataGrid()
        {
            var vehiclelist = (from c in bd.Vehiculos
                                select c).ToList();

            this.dataGridView1.DataSource = vehiclelist.ToList();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Activo;\'\';Inactivo";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[9].DefaultCellStyle = dataGridViewCellStyle1;
        }
        private void deleteData()
        {
            int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    var data = (from a in bd.Vehiculos
                                select a).Where(a => a.Id_Vehiculo.Equals(Item)).SingleOrDefault();
                    bd.Vehiculos.Remove(data);
                }
                bd.SaveChanges();
                this.loadDataGrid();
            }
        }
        private void searchValue()
        {
            var employee = (from em in bd.Vehiculos
                            where (em.Descripcion.ToString().Contains(textBox1.Text)
                            || em.No_Chasis.ToString().Contains(textBox1.Text)
                            || em.No_Motor.ToString().Contains(textBox1.Text)
                            || em.No_Placa.ToString().Contains(textBox1.Text)
                            || em.Tipo_Vehiculo.ToString().Contains(textBox1.Text)
                            || em.Marca.ToString().Contains(textBox1.Text)
                            || em.Modelo.ToString().Contains(textBox1.Text)
                            || em.Tipo_Combustible.ToString().Contains(textBox1.Text)
                            )
                            select em);            

            this.dataGridView1.DataSource = employee.ToList();
        }

        private void updateData(Vehycle veh, int index)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(txtNoChasis.Text) || string.IsNullOrEmpty(txtNoMotor.Text)
                || string.IsNullOrEmpty(txtNoMotor.Text) || string.IsNullOrEmpty(txtNoPlaca.Text) || string.IsNullOrEmpty(cbx_Marca.Text)
                || string.IsNullOrEmpty(cbx_Modelo.Text) || string.IsNullOrEmpty(cbx_TipoCombustible.Text) || string.IsNullOrEmpty(cbx_TipoVehiculo.Text)
                || string.IsNullOrEmpty(comboEstado.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateVehycle = (from a in bd.Vehiculos
                                      select a).Where(m => m.Id_Vehiculo.Equals(Item)).SingleOrDefault();

                updateVehycle.Descripcion = txtDescription.Text;
                updateVehycle.No_Chasis = txtNoChasis.Text;
                updateVehycle.No_Motor = Int32.Parse(txtNoMotor.Text);
                updateVehycle.No_Placa = txtNoPlaca.Text;
                updateVehycle.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                //updateEmployee2.Usuario1 = txtUser.Text;
                //updateEmployee2.Contrasenia = txtUser.Text;
                //updateEmployee2.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.SaveChanges();
                txtDescription.Clear();
                txtNoChasis.Clear();
                txtNoMotor.Clear();
                txtNoPlaca.Clear();
                comboEstado.SelectedIndex = -1;
                cbx_Marca.SelectedIndex = -1;
                cbx_Modelo.SelectedIndex = -1;
                cbx_TipoCombustible.SelectedIndex = -1;
                cbx_TipoVehiculo.SelectedIndex = -1;

                this.loadDataGrid();
            }
        }
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void Vehycle_Load(object sender, EventArgs e)
        {
            loadDataGrid();
            loadDataMarca();
            loadDataModelo();
            loadDataTipoCombustible();
            loadDataTipoVehiculo();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //searchValue();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                txtDescription.Text = item.Cells[1].Value.ToString();
                txtNoChasis.Text = item.Cells[2].Value.ToString();
                txtNoMotor.Text = item.Cells[3].Value.ToString();
                txtNoPlaca.Text = item.Cells[4].Value.ToString();
                //comision.Text = item.Cells[5].Value.ToString();
                //FechaIngreso.Text = Convert.ToDateTime(item.Cells[6].Value.ToString());
                comboEstado.Text = Int32.Parse(item.Cells[9].Value.ToString()) == 1 ? "Activo" : "Inactivo";
                btn_ok_update.Visible = true;
                btn_ok.Visible = false;
                index = item.Index;
            }
        }

        private void txtNoMotor_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNoMotor.Text, "[^0-9]"))
            {
                txtNoMotor.Text = txtNoMotor.Text.Remove(txtNoMotor.Text.Length - 1);
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

        private void btn_ok_update_Click(object sender, EventArgs e)
        {
            Vehycle empl = new Vehycle();
            updateData(empl, index);
            btn_ok_update.Visible = false;
            btn_ok.Visible = true;
            MessageBox.Show("Actualizado");
            Refresh();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtDescription.Text)) && !(string.IsNullOrEmpty(txtNoChasis.Text)) &&
                !(string.IsNullOrEmpty(comboEstado.Text)) && !(string.IsNullOrEmpty(txtNoMotor.Text)) &&
                !(string.IsNullOrEmpty(txtNoPlaca.Text)) && !(string.IsNullOrEmpty(cbx_Marca.Text))
                && !(string.IsNullOrEmpty(cbx_Modelo.Text)) && !(string.IsNullOrEmpty(cbx_TipoCombustible.Text))
                && !(string.IsNullOrEmpty(cbx_TipoVehiculo.Text)))
            {
                Vehiculo veh = new Vehiculo();

                veh.Descripcion = txtDescription.Text;
                veh.No_Chasis = txtNoChasis.Text;
                veh.No_Motor = int.Parse(txtNoMotor.Text);
                veh.No_Placa = txtNoPlaca.Text;
                veh.Marca = int.Parse(cbx_Marca.SelectedValue.ToString());
                veh.Modelo = int.Parse(cbx_Modelo.SelectedValue.ToString());
                veh.Tipo_Combustible = int.Parse(cbx_TipoCombustible.SelectedValue.ToString());
                veh.Tipo_Vehiculo = int.Parse(cbx_TipoVehiculo.SelectedValue.ToString());
                veh.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;

                bd.Vehiculos.Add(veh);
                MessageBox.Show("Vehículo agregado con éxito");
                bd.SaveChanges();
                loadDataGrid();
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

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
