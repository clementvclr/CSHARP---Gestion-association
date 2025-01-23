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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace gestion_association
{
    public partial class frmetudiant : Form
    {
        public frmetudiant()
        {
            InitializeComponent();
        }
        Etudiant Etudiant;
        private void Etudiant_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet19.LYCEE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.lYCEETableAdapter1.Fill(this.mLR10DataSet19.LYCEE);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet18.PROMOTION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.pROMOTIONTableAdapter1.Fill(this.mLR10DataSet18.PROMOTION);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet17.ETUDIANT'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.eTUDIANTTableAdapter2.Fill(this.mLR10DataSet17.ETUDIANT);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-W56YUID\SQLEXPRESS;Initial Catalog=MLR10;Integrated Security=True");
        private void btnAjouter_Click(object sender, EventArgs e)
        {
            object idPromotion =cbPromo.SelectedValue;
            object idLycee = cbLycee.SelectedValue;
            string baccalaureat =txtBac.Text;
            string specialiteBac =txtSpeBac.Text;
            DateTime anneeObtentionBac =dtpObtentionBac.Value;
            DateTime dateEntreeBTS =dtpEntreeBts.Value;
            DateTime dateSortieBTS =dtpSortieBts.Value;
            string specialiteBTS =txtSpeBts.Text;
            DateTime dateObtentionDiplome =dtpObtentionDiplome.Value;
            DateTime dateDeNaissance =dtpDateNaissance.Value;
            string email =txtEmail.Text;
            string nom =txtNom.Text;
            string prenom =txtPrenom.Text;
            Etudiant = new Etudiant(Convert.ToInt32(idPromotion), Convert.ToInt32(idLycee), baccalaureat, specialiteBac, anneeObtentionBac, dateEntreeBTS, dateSortieBTS, specialiteBTS, dateObtentionDiplome, dateDeNaissance, email, nom, prenom);
            Program.crud.AjouterEtudiant(Etudiant);
            DialogResult result = MessageBox.Show("Etudiant ajouté avec succés !", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM etudiant";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgEtudiant.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dtgEtudiant.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cet étudiant ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dtgEtudiant.SelectedRows[0].Index;
                    int etudiantId = Convert.ToInt32(dtgEtudiant.Rows[rowIndex].Cells["iDETUDIANTDataGridViewTextBoxColumn"].Value); // Supposons que la colonne contenant l'ID a pour nom "Id"

                    Program.crud.SupprimerEtudiant(etudiantId); // Appel de la fonction SupprimerEtudiant en passant l'ID de l'étudiant à supprimer

                    dtgEtudiant.Rows.RemoveAt(rowIndex);

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
            if (dtgEtudiant.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgEtudiant.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.Name == "iDETUDIANTDataGridViewTextBoxColumn")
                        {
                            int etudiantId = Convert.ToInt32(cell.Value);
                        }
                        else if (cell.OwningColumn.Name == "iDPROMOTIONDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbPromo.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "iDLYCEEDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbLycee.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "bACCALAUREATDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtBac.Text = autreValeur;
                        }
                        else if (cell.OwningColumn.Name == "sPECIALITEBACDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtSpeBac.Text = autreValeur;
                        }
                        else if (cell.OwningColumn.Name == "aNNEEOBTENTIONBACDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpObtentionBac.Value = dateTimeValue;
                        }
                        else if (cell.OwningColumn.Name == "dATEENTREEBTSDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpEntreeBts.Value = dateTimeValue;
                        }
                        else if (cell.OwningColumn.Name == "dATESORTIEBTSDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpSortieBts.Value = dateTimeValue;
                        }
                        else if (cell.OwningColumn.Name == "sPECIALITEBTSDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtSpeBts.Text = autreValeur;
                        }
                        else if (cell.OwningColumn.Name == "dATEOBTENTIONDIPLOMEDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpObtentionDiplome.Value = dateTimeValue;
                        }
                        else if (cell.OwningColumn.Name == "dATEDENAISSANCEDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpDateNaissance.Value = dateTimeValue;
                        }
                        else if (cell.OwningColumn.Name == "eMAILDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtEmail.Text = autreValeur;
                        }
                        else if (cell.OwningColumn.Name == "nOMDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtNom.Text = autreValeur;
                        }
                        else if (cell.OwningColumn.Name == "pRENOMDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtPrenom.Text = autreValeur;
                        }
                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int etudiantId = 0; // Déclarez et initialisez la variable etudiantId

            if (dtgEtudiant.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgEtudiant.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "iDETUDIANTDataGridViewTextBoxColumn")
                    {
                        etudiantId = Convert.ToInt32(cell.Value);
                        break; // Sortir de la boucle foreach une fois que la valeur de etudiantId est récupérée
                    }
                }
            }

            object idPromotion = cbPromo.SelectedValue;
            object idLycee = cbLycee.SelectedValue;
            string baccalaureat = txtBac.Text;
            string specialiteBac = txtSpeBac.Text;
            DateTime anneeObtentionBac = dtpObtentionBac.Value;
            DateTime dateEntreeBTS = dtpEntreeBts.Value;
            DateTime dateSortieBTS = dtpSortieBts.Value;
            string specialiteBTS = txtSpeBts.Text;
            DateTime dateObtentionDiplome = dtpObtentionDiplome.Value;
            DateTime dateDeNaissance = dtpDateNaissance.Value;
            string email = txtEmail.Text;
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            Program.crud.ModifierEtudiant(etudiantId, Convert.ToInt32(idPromotion), Convert.ToInt32(idLycee), baccalaureat, specialiteBac, anneeObtentionBac, dateEntreeBTS, dateSortieBTS, specialiteBTS, dateObtentionDiplome, dateDeNaissance, email, nom, prenom);
            DialogResult result = MessageBox.Show("Etudiant modifié avec succés !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM etudiant";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgEtudiant.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
            btnConfirm.Visible = false;
        }
    }
}
