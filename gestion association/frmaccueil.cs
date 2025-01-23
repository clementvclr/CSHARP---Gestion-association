using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace gestion_association
{
    public partial class frmaccueil : Form
    {
        public frmaccueil()
        {
            InitializeComponent();
            this.panelAcc.Controls.Clear();
            frmhome FrmDashboard_Vrb = new frmhome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelAcc.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnEtudiant_click(object sender, EventArgs e)
        {
            this.panelAcc.Controls.Clear();
            frmetudiant FrmDashboard_Vrb = new frmetudiant() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelAcc.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnIntervention_Click(object sender, EventArgs e)
        {
            this.panelAcc.Controls.Clear();
            frmintervention FrmDashboard_Vrb = new frmintervention() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelAcc.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnProfessionnel_Click(object sender, EventArgs e)
        {
            this.panelAcc.Controls.Clear();
            frmprofessionnel FrmDashboard_Vrb = new frmprofessionnel() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelAcc.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void btnPostBts_Click(object sender, EventArgs e)
        {
            this.panelAcc.Controls.Clear();
            frmpostBts FrmDashboard_Vrb = new frmpostBts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
            this.panelAcc.Controls.Add(FrmDashboard_Vrb);
            FrmDashboard_Vrb.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir vous déconnecter ?", "Confirmation de déconnexion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
                frmconnexion connexionForm = new frmconnexion();
                connexionForm.Show();
                this.Hide();
            }
        }

        private void panelAcc_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
