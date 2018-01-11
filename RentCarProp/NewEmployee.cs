using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RentCarProp
{    
    public partial class NewEmployee : Form
    {
        RentCarPropEntities bd;
        private int index = 0;
        public NewEmployee()
        {
            bd = new RentCarPropEntities();
            InitializeComponent();
        }

        public bool validaCedula(String ced)
        {
            if (ced == null || ced.Length != 11)
                //MessageBox.Show("Hueee");
                return false;
            int suma = 0;
            for (int i = 0; i < 10; i++)
            {
                int mul = (ced.ElementAt(i) - '0') * (i % 2 + 1);
                while (mul > 0)
                {
                    suma += mul % 10;
                    mul /= 10;
                }
            }
            int division = (suma + 9) / 10 * 10;
            int digito = division - suma;
            return digito == ced.ElementAt(10) - '0';
        }

        private void NuevoUsuario_Load(object sender, EventArgs e)
        {
            loadDataTandaLaboral();
            loadDataGrid();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {            
            if (System.Text.RegularExpressions.Regex.IsMatch(txtNoCedula.Text, "[^0-9]"))
            {
                MessageBox.Show("Solo inserte números");
                txtNoCedula.Text = txtNoCedula.Text.Remove(txtNoCedula.Text.Length - 1);
            }
            if (String.IsNullOrEmpty(txtNoCedula.Text))
            {
                //MessageBox.Show("Este campo es requerido");
            }            
        }

        private void loadDataTandaLaboral()
        {
            var laborlist = (from c in bd.Tanda_Laboral
                             select c).ToList();

            this.tanda.DataSource = laborlist;
            this.tanda.DisplayMember = "Descripcion";
            this.tanda.ValueMember = "Id_TandaLaboral";
        }

        private void loadDataGrid()
        {
            var employeeList = (from c in bd.Empleados
                             select c).ToList();

            this.dataGridView1.DataSource = employeeList.ToList();            
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
                    var data = (from a in bd.Empleados
                                select a).Where(a => a.Id_Empleado.Equals(Item)).SingleOrDefault();

                    //var usrdata = (from a in bd.Usuarios
                    //            select a).Where(a => a.Id_empleado.Equals(Item)).SingleOrDefault();

                    bd.Empleados.Remove(data);
                    //bd.Usuarios.Remove(usrdata);
                }
                bd.SaveChanges();
                this.loadDataGrid();
            }
        }
        private void searchValue()
        {
            var employee = (from em in bd.Empleados
                            where (em.Nombre.ToString().Contains(textBox1.Text)
                            || em.Apellido.ToString().Contains(textBox1.Text)
                            || em.Cédula.ToString().Contains(textBox1.Text)
                            || em.Porciento_Comision.ToString().Contains(textBox1.Text)
                            || em.Tanda_labor.ToString().Contains(textBox1.Text)
                            )
                            select em);
            var employee2 = (from us in bd.Usuarios
                             where (us.Contrasenia.ToString().Contains(textBox1.Text)
                             || us.Usuario1.ToString().Contains(textBox1.Text)
                             )
                             select us);

            this.dataGridView1.DataSource = employee.ToList();

        }

        private void updateData(NewEmployee emp, int index)
        {
            if (string.IsNullOrEmpty(txtName.Text) || string.IsNullOrEmpty(txtNoCedula.Text))
            {
                MessageBox.Show("Completar Información");
                return;
            }
            else
            {
                int Item = Int32.Parse(dataGridView1[0, index].Value.ToString());
                var updateEmployee = (from a in bd.Empleados
                                     select a).Where(m => m.Id_Empleado.Equals(Item)).SingleOrDefault();
                //var updateEmployee2 = (from a in bd.Usuarios
                //                      select a).Where(m => m.Id_empleado.Equals(Item)).SingleOrDefault();

                updateEmployee.Nombre = txtName.Text;
                updateEmployee.Apellido = txtLastName.Text;
                updateEmployee.Cédula = Int32.Parse(txtNoCedula.Text);
                updateEmployee.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                updateEmployee.Porciento_Comision = Int32.Parse(comision.Text);
                //updateEmployee2.Usuario1 = txtUser.Text;
                //updateEmployee2.Contrasenia = txtUser.Text;
                //updateEmployee2.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                bd.SaveChanges();
                txtName.Clear();
                txtLastName.Clear();
                txtNoCedula.Clear();
                comision.Clear();
                comboEstado.SelectedIndex = -1;

                this.loadDataGrid();
            }
        }
        public string getMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }

        internal static string getSha1Hash(string text)
        {
            if (String.IsNullOrEmpty(text))
                return String.Empty;

            using (var sha1 = new System.Security.Cryptography.SHA1Managed())
            {
                byte[] textData = Encoding.UTF8.GetBytes(text);

                byte[] hash = sha1.ComputeHash(textData);

                return BitConverter.ToString(hash).Replace("-", String.Empty);
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(comision.Text, "[^0-9]"))
            {                
                comision.Text = comision.Text.Remove(comision.Text.Length - 1);
            }
        }

        private void FechaIngreso_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

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
            //if (validaCedula(txtNoCedula.Text))
            //{
                if (!(string.IsNullOrEmpty(txtName.Text)) && !(string.IsNullOrEmpty(txtLastName.Text))
                && !(string.IsNullOrEmpty(comboEstado.Text)) 
                && !(string.IsNullOrEmpty(txtNoCedula.Text)) && !(string.IsNullOrEmpty(comision.Text)))
                {
                    Empleado emp = new Empleado();
                    Usuario usr = new Usuario();

                    emp.Nombre = txtName.Text;
                    emp.Apellido = txtLastName.Text;
                    emp.Cédula = Int32.Parse(txtNoCedula.Text);
                    emp.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                    emp.Fecha_Ingreso = FechaIngreso.Value.Date;
                    emp.Porciento_Comision = Decimal.Parse(comision.Text);
                    emp.Tanda_labor = Int32.Parse(tanda.SelectedValue.ToString());

                    usr.Usuario1 = txtUser.Text;
                    usr.Contrasenia = getMD5Hash(txtPass.Text);
                    usr.Id_empleado = emp.Id_Empleado;
                    usr.Estado = comboEstado.Text.ToString() == "Activo" ? 1 : 0;
                    usr.Role = null;

                    bd.Empleados.Add(emp);
                    bd.Usuarios.Add(usr);
                    MessageBox.Show("Usuario agregado con éxito");
                    bd.SaveChanges();
                    loadDataGrid();
                }            
                else
                {
                    MessageBox.Show("Digite un documento válido");
                }
            //}
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_eliminate_Click(object sender, EventArgs e)
        {
            NewEmployee delVehi = new NewEmployee();
            deleteData();
            Refresh();
            MessageBox.Show("Borrado efectivo");
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchValue();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            txtUser.ReadOnly = true;
            txtPass.ReadOnly = true;
            FechaIngreso.Visible = false;
            label8.Visible = false;

            foreach (DataGridViewRow item in this.dataGridView1.SelectedRows)
            {
                txtName.Text = item.Cells[1].Value.ToString();
                txtLastName.Text = item.Cells[2].Value.ToString();                
                txtNoCedula.Text = item.Cells[3].Value.ToString();
                //tanda.Text = Int32.Parse(item.Cells[4].Value.ToString() == loadDataTandaLaboral());
                comision.Text = item.Cells[5].Value.ToString();
                //FechaIngreso.Text = Convert.ToDateTime(item.Cells[6].Value.ToString());
                comboEstado.Text = Int32.Parse(item.Cells[7].Value.ToString()) == 1 ? "Activo" : "Inactivo";
                btn_ok_update.Visible = true;
                btn_ok.Visible = false;
                index = item.Index;
            }            
        }

        private void btn_ok_update_Click(object sender, EventArgs e)
        {
            //if (validaCedula(txtNoCedula.Text))
            //{
                NewEmployee empl = new NewEmployee();
                updateData(empl, index);
                btn_ok_update.Visible = false;
                btn_ok.Visible = true;
                MessageBox.Show("Actualizado");
                Refresh();
            //}
            //else
            //{
            //    MessageBox.Show("Digite un documento válido");
            //}
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
