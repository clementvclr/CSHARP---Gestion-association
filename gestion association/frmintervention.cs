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
    public partial class frmintervention : Form
    {
        public frmintervention()
        {
            InitializeComponent();
        }
        TypeIntervention TypeIntervention;
        intervention intervention;
        private void frmintervention_Load(object sender, EventArgs e)
        {
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet29.TYPE_INTERVENTION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.tYPE_INTERVENTIONTableAdapter4.Fill(this.mLR10DataSet29.TYPE_INTERVENTION);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet23.PROFESSIONNEL'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.pROFESSIONNELTableAdapter1.Fill(this.mLR10DataSet23.PROFESSIONNEL);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet22.TYPE_INTERVENTION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.tYPE_INTERVENTIONTableAdapter3.Fill(this.mLR10DataSet22.TYPE_INTERVENTION);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet21.INTERVENTION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.iNTERVENTIONTableAdapter3.Fill(this.mLR10DataSet21.INTERVENTION);
            // TODO: cette ligne de code charge les données dans la table 'mLR10DataSet20.PROMOTION'. Vous pouvez la déplacer ou la supprimer selon les besoins.
            this.pROMOTIONTableAdapter.Fill(this.mLR10DataSet20.PROMOTION);

        }
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-W56YUID\SQLEXPRESS;Initial Catalog=MLR10;Integrated Security=True");
        private void btnAjouter_Click(object sender, EventArgs e)
        {  
            string libelleIntervention = txtLibelle.Text;
            TypeIntervention = new TypeIntervention(libelleIntervention);
            Program.crud.AjouterTypeIntervention(TypeIntervention);
            DialogResult result = MessageBox.Show("Type d'intervention ajouté avec succés !", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM TYPE_INTERVENTION";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgTypeIntervention.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            btnConfirmerType.Visible = true;
            if (dtgTypeIntervention.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgTypeIntervention.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.Name == "iDTYPEINTERVENTIONDataGridViewTextBoxColumn1")
                        {
                            int typeInterventionId = Convert.ToInt32(cell.Value);
                        }
                        else if (cell.OwningColumn.Name == "lIBELLEINTERVENTIONDataGridViewTextBoxColumn")
                        {
                            string autreValeur = cell.Value.ToString();
                            txtLibelle.Text = autreValeur;
                        }
                        
                    }
                }
            }    
        }

        private void btnConfirmerType_Click(object sender, EventArgs e)
        {
            int idTypeIntervention = 0; // Déclarez et initialisez la variable etudiantId

            if (dtgTypeIntervention.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgTypeIntervention.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "iDTYPEINTERVENTIONDataGridViewTextBoxColumn1")
                    {
                        idTypeIntervention = Convert.ToInt32(cell.Value);
                        break; // Sortir de la boucle foreach une fois que la valeur de etudiantId est récupérée
                    }
                }
            }

            string libelleTypeIntervention = txtLibelle.Text;
           
            Program.crud.ModifierTypeIntervention(idTypeIntervention,libelleTypeIntervention);
            DialogResult result = MessageBox.Show("Type d'intervention modifié avec succés !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Question); 
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM TYPE_INTERVENTION";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgTypeIntervention.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
            btnConfirmerType.Visible = false;
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dtgTypeIntervention.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer ce type ? ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dtgTypeIntervention.SelectedRows[0].Index;
                    int idTypeIntervention = Convert.ToInt32(dtgTypeIntervention.Rows[rowIndex].Cells["iDTYPEINTERVENTIONDataGridViewTextBoxColumn1"].Value); // Supposons que la colonne contenant l'ID a pour nom "Id"

                    Program.crud.SupprimerTypeIntervention(idTypeIntervention); // Appel de la fonction SupprimerEtudiant en passant l'ID de l'étudiant à supprimer

                    dtgTypeIntervention.Rows.RemoveAt(rowIndex);

                    // Autres opérations de suppression à effectuer
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Aucune ligne sélectionnée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnAjouterInter_Click(object sender, EventArgs e)
        {
            object idTypeIntervention = cbTypeInter.SelectedValue;
            object professionnel = cbPro.SelectedValue;
            DateTime dateIntervention = dtpDateInter.Value;
            intervention = new intervention(Convert.ToInt32(idTypeIntervention), Convert.ToInt32(professionnel), dateIntervention);
            Program.crud.AjouterIntervention(intervention);
            DialogResult result = MessageBox.Show("intervention ajouté avec succés !", "Confirmation d'ajout", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM INTERVENTION";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgIntervention.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
        }

        private void btnSupprimerInter_Click(object sender, EventArgs e)
        {
            if (dtgIntervention.SelectedRows.Count > 0)
            {
                DialogResult result = MessageBox.Show("Êtes-vous sûr de vouloir supprimer cette intervention ?", "Confirmation de suppression", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int rowIndex = dtgIntervention.SelectedRows[0].Index;
                    int intervention = Convert.ToInt32(dtgIntervention.Rows[rowIndex].Cells["iDINTERVENTIONDataGridViewTextBoxColumn"].Value); // Supposons que la colonne contenant l'ID a pour nom "Id"

                    Program.crud.SupprimerTypeIntervention(intervention); // Appel de la fonction SupprimerEtudiant en passant l'ID de l'étudiant à supprimer

                    dtgIntervention.Rows.RemoveAt(rowIndex);

                    // Autres opérations de suppression à effectuer
                }
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner une ligne à supprimer.", "Aucune ligne sélectionnée", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnModifierInter_Click(object sender, EventArgs e)
        {
            btnConfirm.Visible = true;
            if (dtgTypeIntervention.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgTypeIntervention.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.Value != null)
                    {
                        if (cell.OwningColumn.Name == "iDINTERVENTIONDataGridViewTextBoxColumn")
                        {
                            int intervention = Convert.ToInt32(cell.Value);
                        }
                        else if (cell.OwningColumn.Name == "iDTYPEINTERVENTIONDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbTypeInter.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "iDPROFESSIONNELDataGridViewTextBoxColumn")
                        {
                            string comboBoxValue = cell.Value.ToString();
                            cbPro.SelectedItem = comboBoxValue;
                        }
                        else if (cell.OwningColumn.Name == "dATEINTERVENTIONDataGridViewTextBoxColumn")
                        {
                            DateTime dateTimeValue = Convert.ToDateTime(cell.Value);
                            dtpDateInter.Value = dateTimeValue;
                        }

                    }
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int intervention = 0; // Déclarez et initialisez la variable etudiantId

            if (dtgIntervention.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dtgIntervention.SelectedRows[0];

                foreach (DataGridViewCell cell in selectedRow.Cells)
                {
                    if (cell.OwningColumn.Name == "iDINTERVENTIONDataGridViewTextBoxColumn")
                    {
                        intervention = Convert.ToInt32(cell.Value);
                        break; // Sortir de la boucle foreach une fois que la valeur de etudiantId est récupérée
                    }
                }
            }

            object idTypeIntervention = cbTypeInter.SelectedValue;
            object professionnel = cbPro.SelectedValue;
            DateTime dateIntervention = dtpDateInter.Value;

            Program.crud.ModifierIntervention(intervention, Convert.ToInt32(idTypeIntervention), Convert.ToInt32(professionnel), dateIntervention);
            DialogResult result = MessageBox.Show("intervention modifié avec succés !", "Confirmation de modification", MessageBoxButtons.OK, MessageBoxIcon.Question);
            //refresh de la datagriedview
            string sqlstm = "SELECT * FROM INTERVENTION";
            SqlDataAdapter SDA = new SqlDataAdapter(sqlstm, conn);
            DataSet DS = new System.Data.DataSet();
            SDA.Fill(DS);
            dtgIntervention.DataSource = DS.Tables[0];

            foreach (Control crt in this.Controls)
            {
                if (crt.GetType() == typeof(TextBox))
                    crt.Text = "";
            }
            btnConfirm.Visible = false;
        }
    }
}
