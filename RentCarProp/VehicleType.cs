using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace RentCarProp
{
    public partial class VehicleType : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public VehicleType()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }
        private void loadData()
        {
            var laborlist = (from c in bd.Tipos_Vehículos
                             select c).ToList();

            dataGridView1.DataSource = laborlist;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Activo;\'\';Inactivo";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[2].DefaultCellStyle = dataGridViewCellStyle1;
        }
        private void searchValue()
        {            
            var vehycle = (from em in bd.Tipos_Vehículos
                          where (em.Descripcion.ToString().Contains(textBox1.Text))
                          //|| em.Estado.ToString().Contains(cbxEstado.Text))
                          select em);
            //var datos = new BindingList<Tipos_Vehículos>(vehycle);
            this.dataGridView1.DataSource = vehycle.ToList();
            //dataGridView1.Refresh();
            //this.loadData();
        }

        private void updateData(VehicleType vehicle, int index)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cbxEstado.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateVehicle = (from a in bd.Tipos_Vehículos
                                     select a).Where(m => m.Id.Equals(Item)).SingleOrDefault();

                updateVehicle.Descripcion = txtDescription.Text;
                updateVehicle.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.SaveChanges();
                txtDescription.Clear();
                cbxEstado.SelectedIndex = -1;

                this.loadData();
            }
        }

        private void deleteData()
        {            
            int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    var data = (from a in bd.Tipos_Vehículos
                                select a).Where(a => a.Id.Equals(Item)).SingleOrDefault();

                    bd.Tipos_Vehículos.Remove(data);
                }
                bd.SaveChanges();
                this.loadData();
            }
        }

        private void VehicleType_Load(object sender, EventArgs e)
        {
            loadData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var vehicleType = new Tipos_Vehículos();            

            if (txtDescription.Text != "")
            {
                //vehicleType.Id = int.Parse(txtID.Text);
                vehicleType.Descripcion = txtDescription.Text;
                vehicleType.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.Tipos_Vehículos.Add(vehicleType);
                bd.SaveChanges();
                loadData();
                txtDescription.Clear();
                cbxEstado.SelectedIndex = -1;
            }            
            else
            {
                MessageBox.Show("Inserte Valores Válidos");
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {            
            
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            
        }        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("No se puede actualizar GRID");          
        }

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            VehicleType delVehi = new VehicleType();
            deleteData();
            Refresh();
            MessageBox.Show("Borrado efectivo");
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                txtDescription.Text = item.Cells[1].Value.ToString();
                cbxEstado.Text = Int32.Parse(item.Cells[2].Value.ToString()) == 1 ? "Activo" : "Inactivo";
                button1.Visible = false;
                button3.Visible = true;
                index = item.Index;
            }
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VehicleType tipo = new VehicleType();
            updateData(tipo, index);
            button1.Visible = true;
            button3.Visible = false;
            MessageBox.Show("Actualizado");
            Refresh();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {            
            searchValue();            
        }
    }
}
