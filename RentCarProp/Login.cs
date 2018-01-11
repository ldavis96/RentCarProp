using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace RentCarProp
{
    public partial class Login : Form
    {
        //private string user;
        //private string pass;
        RentCarPropEntities bd;
        public Login()
        {
           bd = new RentCarPropEntities();
           InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("¿Está seguro?", "Confirm", MessageBoxButtons.YesNo);
            if (res == DialogResult.No)
            {
                //se quedará en el form
            }
            else
            {
                this.Close();
            }
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            //string claveEncriptadaMD5 = getMD5Hash(txtPass.Text); 
            //01-NOV-2017. PREGUNTARLE AL PROFESOR CÓMO APLICAR ESTA PARTE (ENCRIPTAR LA CLAVE)

            Usuario usrs = (from u in bd.Usuarios
                            where u.Usuario1.Equals(txtUser.Text) &&
                                    u.Contrasenia.Equals(txtPass.Text)
                            select u).FirstOrDefault();

            if (usrs == null || string.IsNullOrEmpty(txtUser.Text) || string.IsNullOrEmpty(txtPass.Text))
            {
                MessageBox.Show("Introduzca valores válidos");
                txtUser.Clear();
                txtPass.Clear();
            }
            else
            {
                MainForm frm = new MainForm();
                this.Hide();
                frm.Show();
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //this.linkLabel1.LinkVisited = false;           
            //Login login = new Login();
            //login.Show();
            //colocar una condicion para que muestre el login, si es admin dejar pasar a crear nuevo usuario
            //NewEmployee NewUser = new NewEmployee();
            //NewUser.ShowDialog();
        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '-';
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
    }
}
