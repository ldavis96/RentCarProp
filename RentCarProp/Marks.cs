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
    public partial class Marks : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public Marks()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }
        private void loadData()
        {
            var laborlist = (from c in bd.Marcas
                             select c).ToList();

            dataGridView1.DataSource = laborlist;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Activo;\'\';Inactivo";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[2].DefaultCellStyle = dataGridViewCellStyle1;
        }

        private void Marks_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void searchValue()
        {
            var marcas = (from em in bd.Marcas
                           where (em.Descripcion.ToString().Contains(textBox1.Text))
                           select em);
            this.dataGridView1.DataSource = marcas.ToList();            
        }
        private void updateData(Marca marca, int index)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cbxEstado.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateVehicle = (from a in bd.Marcas
                                     select a).Where(m => m.Id_Marca.Equals(Item)).SingleOrDefault();

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
                    var data = (from a in bd.Marcas
                                select a).Where(a => a.Id_Marca.Equals(Item)).SingleOrDefault();

                    bd.Marcas.Remove(data);
                }
                bd.SaveChanges();
                this.loadData();
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

        private void button1_Click(object sender, EventArgs e)
        {
            var mark = new Marca();

            if (txtDescription.Text != "")
            {
                mark.Descripcion = txtDescription.Text;
                mark.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.Marcas.Add(mark);
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

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Marca tipo = new Marca();
            updateData(tipo, index);
            button1.Visible = true;
            button3.Visible = false;
            MessageBox.Show("Actualizado");
            Refresh();
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

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            Marca delVehi = new Marca();
            deleteData();
            Refresh();
            MessageBox.Show("Borrado efectivo");
        }
    }
}
