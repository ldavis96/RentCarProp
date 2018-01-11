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
    public partial class WorkOrder : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public WorkOrder()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void loadData()
        {
            var laborlist = (from c in bd.Tanda_Laboral
                             select c).ToList();

            dataGridView1.DataSource = laborlist;
        }

        private void searchValue()
        {
            var vehycle = (from em in bd.Tanda_Laboral
                           where (em.Descripcion.ToString().Contains(txtDescription.Text))                           
                           select em);
            
            this.dataGridView1.DataSource = vehycle.ToList();
        }

        private void updateData(Tanda_Laboral vehicle, int index)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateTanda = (from a in bd.Tanda_Laboral
                                     select a).Where(m => m.Id_TandaLaboral.Equals(Item)).SingleOrDefault();

                updateTanda.Descripcion = txtDescription.Text;
                bd.SaveChanges();
                txtDescription.Clear();

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
                    var data = (from a in bd.Tanda_Laboral
                                select a).Where(a => a.Id_TandaLaboral.Equals(Item)).SingleOrDefault();

                    bd.Tanda_Laboral.Remove(data);
                }
                bd.SaveChanges();
                this.loadData();
            }
        }

        private void WorkOrder_Load(object sender, EventArgs e)
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
            var workorder = new Tanda_Laboral();

            if(txtDescription.Text != "")
            {
                workorder.Descripcion = txtDescription.Text;
                bd.Tanda_Laboral.Add(workorder);
                bd.SaveChanges();
                loadData();
                txtDescription.Clear();
            }
            if (txtDescription.Text == workorder.Descripcion)
            {
                MessageBox.Show("Favor insertar otra descripción");
            }
            else
            {
                MessageBox.Show("Este campo es requerido");
            }
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                txtDescription.Text = item.Cells[1].Value.ToString();                
                button1.Visible = true;
                button3.Visible = false;
                index = item.Index;
            }            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Tanda_Laboral tipo = new Tanda_Laboral();
            updateData(tipo, index);
            button1.Visible = false;
            button3.Visible = true;
            MessageBox.Show("Actualizado");
            Refresh();
        }

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            Tanda_Laboral delVehi = new Tanda_Laboral();
            deleteData();
            Refresh();
            MessageBox.Show("Borrado efectivo");
        }
    }
}
