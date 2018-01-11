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
    public partial class Models : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public Models()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }
        private void loadData()
        {
            var laborlist = (from c in bd.Modelos
                             select c).ToList();

            dataGridView1.DataSource = laborlist;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Activo;\'\';Inactivo";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[3].DefaultCellStyle = dataGridViewCellStyle1;
        }
        private void searchValue()
        {
            var modelos = (from em in bd.Modelos
                          where (em.Descripcion.ToString().Contains(textBox1.Text))
                          select em);
            this.dataGridView1.DataSource = modelos.ToList();
        }
        private void updateData(Modelo model, int index)
        {
            if (string.IsNullOrEmpty(txtDescription.Text) || string.IsNullOrEmpty(cbxEstado.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateMarca = (from a in bd.Modelos
                                     select a).Where(m => m.Id_Modelo.Equals(Item)).SingleOrDefault();

                updateMarca.Descripcion = txtDescription.Text;
                updateMarca.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
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
                    var data = (from a in bd.Modelos
                                select a).Where(a => a.Id_Modelo.Equals(Item)).SingleOrDefault();

                    bd.Modelos.Remove(data);
                }
                bd.SaveChanges();
                this.loadData();
            }
        }
        private void Models_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var model = new Modelo();

            if (txtDescription.Text != "")
            {
                model.Descripcion = txtDescription.Text;
                model.Estado = cbxEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.Modelos.Add(model);
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

        private void button1_Click(object sender, EventArgs e)
        {
            Modelo tipo = new Modelo();
            updateData(tipo, index);
            button1.Visible = false;
            button3.Visible = true;
            MessageBox.Show("Actualizado");
            Refresh();
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                txtDescription.Text = item.Cells[2].Value.ToString();
                cbxEstado.Text = Int32.Parse(item.Cells[3].Value.ToString()) == 1 ? "Activo" : "Inactivo";
                button1.Visible = true;
                button3.Visible = false;
                index = item.Index;
            }
        }

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            Modelo delVehi = new Modelo();
            deleteData();
            Refresh();
            MessageBox.Show("Borrado efectivo");
        }
    }
}
