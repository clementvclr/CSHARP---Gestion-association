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
    public partial class frmpostBts : Form
    {
        public frmpostBts()
        {
            InitializeComponent();
        }
        postBTS postBTS;
        formation formation;
        private void frmpostBts_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet34.FORMATION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fORMATIONTableAdapter2.Fill(this.mLR10DataSet34.FORMATION);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet33.ETUDIANT'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.eTUDIANTTableAdapter.Fill(this.mLR10DataSet33.ETUDIANT);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet28.FORMATION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.fORMATIONTableAdapter1.Fill(this.mLR10DataSet28.FORMATION);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet25.SECTEURACTIVITE'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.sECTEURACTIVITETableAdapter.Fill(this.mLR10DataSet25.SECTEURACTIVITE);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet24.CURSUS_POST_BTS'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.cURSUS_POST_BTSTableAdapter1.Fill(this.mLR10DataSet24.CURSUS_POST_BTS);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-W56YUID\SQLEXPRESS;Initial Catalog=MLR10;Integrated Security=True");
        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            object idEtudiant = cbAncienEtu.SelectedValue;
            object idFormation = cbFormation.SelectedValue;
            DateTime dateObtention = dtpAnneeobt.Value;
            bool resusltatObtenue = chbDiplome.Checked;
            bool resultb;
            if (resusltatObtenue)
            {
                resultb = true;
            }
            else
            {
                resultb = false;
            }
            postBTS = new postBTS(Convert.ToInt32(idEtudiant), Convert.ToInt32(idFormation), dateObtention, resultb);
            Program.crud.AjouterCursus(postBTS);
            DialogResult result = MessageBox.Show("Cursus ajouté avec succés !", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM CURSUS_POST_BTS";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgCursus.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            if (dtgCursus.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgCursus.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.Name == "iDPROFESSIONNELDataGridViewTextBoxColumn")
                        {
                            int idCursus = Convert.ToInt32(cell.Value);
                        }
                        else if (cell.OwningColumn.Name == "iDETUDIANTDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbAncienEtu.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "iDSECTEURDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbFormation.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "dATEENTREEPROFESSIONNELDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpAnneeobt.Value = dateTimeValue;
                        }
                        else if (cell.OwningColumn.Name == "rESULTATOBTENTIONDataGridViewCheckBoxColumn")
                        {
                            bool resultb = (bool)cell.Value;
                            chbDiplome.Checked = resultb;
                        }

                    }
                }
            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dtgCursus.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce type ? ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dtgCursus.SelectedRows[0].Index;
                    int idCursus = Convert.ToInt32(dtgCursus.Rows[rowIndex].Cells["iDCURSUSPOSTBTSDataGridViewTextBoxColumn"].Value); // Supposons que la colonne contenant l'ID a pour nom "Id"

                    Program.crud.SupprimerCursus(idCursus); // Appel de la fonction SupprimerEtudiant en passant l'ID de l'étudiant à supprimer

                    dtgCursus.Rows.RemoveAt(rowIndex);

                    // Autres opérations de suppression à effectuer
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Aucune ligne sélectionnée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int idCursus = 0; // Déclarez et initialisez la variable etudiantId
            if (dtgCursus.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgCursus.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "iDCURSUSPOSTBTSDataGridViewTextBoxColumn")
                    {
                        idCursus = Convert.ToInt32(cell.Value);
                        break; // Sortir de la boucle foreach une fois que la valeur de etudiantId est récupérée
                    }
                }
            }

            object idEtudiant = cbAncienEtu.SelectedValue;
            object idFormation = cbFormation.SelectedValue;
            DateTime dateObtention = dtpAnneeobt.Value;
            bool resusltatObtenue = chbDiplome.Checked;
            bool resultb;
            if (resusltatObtenue)
            {
                resultb = true;
            }
            else
            {
                resultb = false;
            }
            Program.crud.ModifierCursus(idCursus, Convert.ToInt32(idEtudiant), Convert.ToInt32(idFormation), dateObtention, resultb);
            DialogResult result = MessageBox.Show("Cursus modifié avec succés !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM CURSUS_POST_BTS";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgCursus.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
            btnConfirm.Visible = false;
        }

        private void btnAjouterFormation_Click(object sender, EventArgs e)
        {
            string nomFormation = txtFormation.Text;
            formation = new formation(nomFormation);
            Program.crud.AjouterFormation(formation);
            DialogResult result = MessageBox.Show("formation ajouté avec succés !", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM FORMATION";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgFormation.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
        }

        private void btnSupprimerFormation_Click(object sender, EventArgs e)
        {
            if (dtgFormation.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette formation ? ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dtgFormation.SelectedRows[0].Index;
                    int idFormation = Convert.ToInt32(dtgFormation.Rows[rowIndex].Cells["iDFORMATIONDataGridViewTextBoxColumn1"].Value); // Supposons que la colonne contenant l'ID a pour nom "Id"

                    Program.crud.SupprimerFormation(idFormation); // Appel de la fonction SupprimerEtudiant en passant l'ID de l'étudiant à supprimer

                    dtgFormation.Rows.RemoveAt(rowIndex);

                    // Autres opérations de suppression à effectuer
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Aucune ligne sélectionnée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModifierFormation_Click(object sender, EventArgs e)
        {
            btnConfirmer.Visible = true;
            if (dtgFormation.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgFormation.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.Name == "iDFORMATIONDataGridViewTextBoxColumn1")
                        {
                            int idFormation = Convert.ToInt32(cell.Value);
                        }
                        else if (cell.OwningColumn.Name == "nOMFORMATIONDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtFormation.Text = autreValeur;
                        }

                    }
                }
            }
        }

        private void btnConfirmer_Click(object sender, EventArgs e)
        {
            int idFormation = 0; // Déclarez et initialisez la variable etudiantId

            if (dtgFormation.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgFormation.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "iDFORMATIONDataGridViewTextBoxColumn1")
                    {
                        idFormation = Convert.ToInt32(cell.Value);
                        break; // Sortir de la boucle foreach une fois que la valeur de etudiantId est récupérée
                    }
                }
            }

            string nomFormation = txtFormation.Text;

            Program.crud.ModifierFormation(idFormation, nomFormation);
            DialogResult result = MessageBox.Show("Formation modifié avec succés !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM FORMATION";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgFormation.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
            btnConfirmer.Visible = false;
        }
    }
}
