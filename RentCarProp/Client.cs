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
    public partial class Client : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public Client()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }
        public static bool validaCedula(string pCedula)
        {
            int vnTotal = 0;
            string vcCedula = pCedula.Replace("-", "");
            int pLongCed = vcCedula.Trim().Length;
            int[] digitoMult = new int[11] { 1, 2, 1, 2, 1, 2, 1, 2, 1, 2, 1 };

            if (pLongCed < 11 || pLongCed > 11)
                return false;

            for (int vDig = 1; vDig <= pLongCed; vDig++)
            {
                int vCalculo = Int32.Parse(vcCedula.Substring(vDig - 1, 1)) * digitoMult[vDig - 1];
                if (vCalculo < 10)
                    vnTotal += vCalculo;
                else
                    vnTotal += Int32.Parse(vCalculo.ToString().Substring(0, 1)) + Int32.Parse(vCalculo.ToString().Substring(1, 1));
            }

            if (vnTotal % 10 == 0)
                return true;
            else
                MessageBox.Show("Es igual");
                return false;
        }
        private void loadData()
        {
            var clientlist = (from c in bd.Clientes
                               select c).ToList();

            this.dataGridView1.DataSource = clientlist.ToList();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1.Format = "Activo;\'\';Inactivo";
            dataGridViewCellStyle1.NullValue = null;
            dataGridView1.Columns[7].DefaultCellStyle = dataGridViewCellStyle1;
        }
        private void deleteData()
        {
            int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
            if (this.dataGridView1.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
                {
                    var data = (from a in bd.Clientes
                                select a).Where(a => a.Id_Cliente.Equals(Item)).SingleOrDefault();
                    bd.Clientes.Remove(data);
                }
                bd.SaveChanges();
                this.loadData();
            }
        }
        private void searchValue()
        {
            var clients = (from em in bd.Clientes
                            where (em.Límite_Credito.ToString().Contains(textBox1.Text)
                            || em.Nombre.ToString().Contains(textBox1.Text)
                            || em.Apellido.ToString().Contains(textBox1.Text)
                            || em.No_Tarjeta.ToString().Contains(textBox1.Text)
                            || em.Tipo_Persona.ToString().Contains(textBox1.Text)
                            || em.Cedula.ToString().Contains(textBox1.Text)
                            )
                            select em);

            this.dataGridView1.DataSource = clients.ToList();
        }
        private void updateData(Client cli, int index)
        {
            if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtLastName.Text) || string.IsNullOrEmpty(txtLimiteCred.Text)
                || string.IsNullOrEmpty(txtCedula.Text) || string.IsNullOrEmpty(txtNoTarjeta.Text) || string.IsNullOrEmpty(cbx_TipoPersona.Text)
                || string.IsNullOrEmpty(comboEstado.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateClient = (from a in bd.Clientes
                                    select a).Where(m => m.Id_Cliente.Equals(Item)).SingleOrDefault();

                updateClient.Nombre = txtNombre.Text;
                updateClient.Apellido = txtLastName.Text;
                updateClient.Cedula = Int32.Parse(txtCedula.Text);
                updateClient.No_Tarjeta = Int32.Parse(txtNoTarjeta.Text);
                updateClient.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                updateClient.Límite_Credito = int.Parse(txtLimiteCred.Text);
                updateClient.Tipo_Persona = cbx_TipoPersona.Text.ToString();

                bd.SaveChanges();

                txtNombre.Clear();
                txtLastName.Clear();
                comboEstado.SelectedIndex = -1; ;
                txtCedula.Clear();
                txtNoTarjeta.Clear();
                txtLimiteCred.Clear();
                cbx_TipoPersona.SelectedIndex = -1;

                this.loadData();
            }
        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void cbx_TipoCombustible_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtNoPlaca_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNoTarjeta.Text, "[^0-9]"))
            {
                txtNoTarjeta.Text = txtNoTarjeta.Text.Remove(txtNoTarjeta.Text.Length - 1);
            }
        }

        private void txtLimiteCred_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtLimiteCred.Text, "[^0-9]"))
            {
                txtLimiteCred.Text = txtLimiteCred.Text.Remove(txtLimiteCred.Text.Length - 1);
            }
        }

        private void txtCedula_TextChanged(object sender, EventArgs e)
        {
            validaCedula(txtCedula.Text);
            if (System.Text.RegularExpressions.Regex.IsMatch(txtCedula.Text, "[^0-9]"))
            {
                txtCedula.Text = txtCedula.Text.Remove(txtCedula.Text.Length - 1);
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

        private void Client_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void btn_ok_update_Click(object sender, EventArgs e)
        {
                       
        }

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            deleteData();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(txtNombre.Text)) && !(string.IsNullOrEmpty(txtLastName.Text)) &&
               !(string.IsNullOrEmpty(comboEstado.Text)) && !(string.IsNullOrEmpty(txtCedula.Text)) &&
               !(string.IsNullOrEmpty(txtNoTarjeta.Text)) && !(string.IsNullOrEmpty(txtLimiteCred.Text))
               && !(string.IsNullOrEmpty(cbx_TipoPersona.Text)))
            {
                Cliente client = new Cliente();

                client.Nombre = txtNombre.Text;
                client.Apellido = txtLastName.Text;
                client.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                client.Cedula = int.Parse(txtCedula.Text);
                client.No_Tarjeta = int.Parse(txtNoTarjeta.Text);
                client.Límite_Credito = int.Parse(txtLimiteCred.Text);
                client.Tipo_Persona = cbx_TipoPersona.Text.ToString();

                bd.Clientes.Add(client);
                MessageBox.Show("Cliente agregado con éxito");                
                bd.SaveChanges();

                txtNombre.Clear();
                txtLastName.Clear();
                comboEstado.SelectedIndex = -1;;
                txtCedula.Clear();
                txtNoTarjeta.Clear();
                txtLimiteCred.Clear();
                cbx_TipoPersona.SelectedIndex = -1;

                loadData();
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

        private void btn_update_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                txtNombre.Text = item.Cells[1].Value.ToString();
                txtLastName.Text = item.Cells[2].Value.ToString();
                txtCedula.Text = item.Cells[3].Value.ToString();
                txtNoTarjeta.Text = item.Cells[4].Value.ToString();
                txtLimiteCred.Text = item.Cells[5].Value.ToString();
                cbx_TipoPersona.Text = item.Cells[6].Value.ToString();
                comboEstado.Text = Int32.Parse(item.Cells[7].Value.ToString()) == 1 ? "Activo" : "Inactivo";
                btn_ok_update.Visible = true;
                btn_ok.Visible = false;
                index = item.Index;

                //Client clie = new Client();
                //updateData(clie, index);
                //btn_ok_update.Visible = true;
                //btn_ok.Visible = false;
                //MessageBox.Show("Actualizado");
                //Refresh();
            }            
        }        
    }
}
