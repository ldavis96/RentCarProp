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
    public partial class FuelType : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public FuelType()
        {
            InitializeComponent();
            bd = new RentCarPropEntities();
        }

        private void loadData()
        {
            var laborlist = (from c in bd.Tipos_Combustible
                             select c).ToList();

            dataGridView1.DataSource = laborlist;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Activo;\'\';Inactivo";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[2].DefaultCellStyle = dataGridViewCellStyle1;
        }
        private void searchValue()
        {
            var fueltype = (from em in bd.Tipos_Combustible
                           where (em.Descripcion.ToString().Contains(textBox1.Text))                           
                           select em);            
            this.dataGridView1.DataSource = fueltype.ToList();            
        }

        private void updateData(FuelType vehicle, int index)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cbxEstado.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateFuelType = (from a in bd.Tipos_Combustible
                                     select a).Where(m => m.Id_Combustible.Equals(Item)).SingleOrDefault();

                updateFuelType.Descripcion = txtDescription.Text;
                updateFuelType.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
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
                    var data = (from a in bd.Tipos_Combustible
                                select a).Where(a => a.Id_Combustible.Equals(Item)).SingleOrDefault();

                    bd.Tipos_Combustible.Remove(data);
                }
                bd.SaveChanges();
                this.loadData();
            }
        }

        private void FuelType_Load(object sender, EventArgs e)
        {            
            loadData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FuelType tipo = new FuelType();
            updateData(tipo, index);
            button1.Visible = false;
            button3.Visible = true;
            MessageBox.Show("Actualizado");
            Refresh();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show("No se puede actualizar GRID");
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

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            FuelType delVehi = new FuelType();
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
                button1.Visible = true;
                button3.Visible = false;
                index = item.Index;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //FuelType tipo = new FuelType();
            //updateData(tipo, index);
            //button1.Visible = true;
            //button3.Visible = false;
            //MessageBox.Show("Actualizado");
            //Refresh();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            var FuelType = new Tipos_Combustible();

            if (txtDescription.Text != "")
            {
                FuelType.Descripcion = txtDescription.Text;
                FuelType.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.Tipos_Combustible.Add(FuelType);
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
    }
}
