using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_association
{
    public partial class frmconnexion : Form
    {
        public frmconnexion()
        {
            InitializeComponent();
        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-W56YUID\SQLEXPRESS;Initial Catalog=MLR10;Integrated Security=True");
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String username, password;
            username = txtId.Text;
            password = txtmdp.Text;

            try 
            {
                string query = "SELECT * FROM Users WHERE Username = @username AND Password = @password";
                SqlCommand command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                SqlDataAdapter sda = new SqlDataAdapter(command);

                DataTable dataTable = new DataTable();
                sda.Fill(dataTable);
                if (dataTable.Rows.Count > 0 )
                {
                    username = txtId.Text;
                    password = txtmdp.Text;
                }
                //page généré
                frmaccueil accueilForm = new frmaccueil();
                accueilForm.Show();
                this.Hide();
            }
            catch
            {
                MessageBox.Show("Mauvais identifiants");
            }
            finally
            {
                conn.Close();
            }
            
        }

        private void chbMdp_CheckedChanged(object sender, EventArgs e)
        {
            if (chbMdp.Checked == true)
            {
                txtmdp.PasswordChar = '\0';
            }
            else
            {
                txtmdp.PasswordChar = '*'; // Masque le mot de passe avec un caractère spécifié (par exemple, une étoile)
            }
        }
    }
}
