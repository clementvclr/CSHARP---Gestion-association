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
    public partial class frmprofessionnel : Form
    {
        public frmprofessionnel()
        {
            InitializeComponent();
        }
        professionnel professionnel;
        private void frmprofessionnel_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet32.PROFESSIONNEL'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.pROFESSIONNELTableAdapter2.Fill(this.mLR10DataSet32.PROFESSIONNEL);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet31.SECTEURACTIVITE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.sECTEURACTIVITETableAdapter2.Fill(this.mLR10DataSet31.SECTEURACTIVITE);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet30.ETUDIANT'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.eTUDIANTTableAdapter.Fill(this.mLR10DataSet30.ETUDIANT);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet27.SECTEURACTIVITE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.sECTEURACTIVITETableAdapter1.Fill(this.mLR10DataSet27.SECTEURACTIVITE);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet26.PROFESSIONNEL'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.pROFESSIONNELTableAdapter1.Fill(this.mLR10DataSet26.PROFESSIONNEL);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-W56YUID\SQLEXPRESS;Initial Catalog=MLR10;Integrated Security=True");
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            object idEtudiant = cbAncienEtu.SelectedValue;
            object idSecteur = cbSecteur.SelectedValue;
            DateTime dateEntreePro = dtpEntreePro.Value;
            professionnel = new professionnel(Convert.ToInt32(idEtudiant), Convert.ToInt32(idSecteur), dateEntreePro);
            Program.crud.AjouterProfessionnel(professionnel);
            DialogResult result = MessageBox.Show("intervention ajouté avec succés !", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM PROFESSIONNEL";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgPro.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dtgPro.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce type ? ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dtgPro.SelectedRows[0].Index;
                    int idProfessionnel = Convert.ToInt32(dtgPro.Rows[rowIndex].Cells["iDPROFESSIONNELDataGridViewTextBoxColumn"].Value); // Supposons que la colonne contenant l'ID a pour nom "Id"

                    Program.crud.SupprimerProfessionnel(idProfessionnel); // Appel de la fonction SupprimerEtudiant en passant l'ID de l'étudiant à supprimer

                    dtgPro.Rows.RemoveAt(rowIndex);

                    // Autres opérations de suppression à effectuer
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Aucune ligne sélectionnée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            if (dtgPro.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgPro.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.Name == "iDPROFESSIONNELDataGridViewTextBoxColumn")
                        {
                            int intervention = Convert.ToInt32(cell.Value);
                        }
                        else if (cell.OwningColumn.Name == "iDETUDIANTDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbAncienEtu.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "iDSECTEURDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbSecteur.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "dATEENTREEPROFESSIONNELDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpEntreePro.Value = dateTimeValue;
                        }

                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int idProfessionnel = 0; // Déclarez et initialisez la variable etudiantId

            if (dtgPro.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgPro.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "iDPROFESSIONNELDataGridViewTextBoxColumn")
                    {
                        idProfessionnel = Convert.ToInt32(cell.Value);
                        break; // Sortir de la boucle foreach une fois que la valeur de etudiantId est récupérée
                    }
                }
            }

            object idEtudiant = cbAncienEtu.SelectedValue;
            object idSecteur = cbSecteur.SelectedValue;
            DateTime dateEntreePro = dtpEntreePro.Value;

            Program.crud.ModifierProfessionnel(idProfessionnel, Convert.ToInt32(idEtudiant), Convert.ToInt32(idSecteur), dateEntreePro);
            DialogResult result = MessageBox.Show("professionnel modifié avec succés !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM PROFESSIONNEL";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgPro.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
            btnConfirm.Visible = false;
        }
    }
}
