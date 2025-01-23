using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace gestion_association
{
    class CRUD
    {
        private const string connectionString = "Data Source=DESKTOP-W56YUID\\SQLEXPRESS;Initial Catalog=MLR10;Integrated Security=True";

        // Fonction de connexion à la base de données
        private SqlConnection ConnectToDatabase()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        internal void AjouterEtudiant(Etudiant Etudiant)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "INSERT INTO etudiant (ID_PROMOTION, ID_LYCEE, BACCALAUREAT, SPECIALITE_BAC, ANNEE_OBTENTION_BAC, DATE_ENTREE_BTS, DATE_SORTIE_BTS, SPECIALITE_BTS, DATE_OBTENTION_DIPLOME, DATE_DE_NAISSANCE, EMAIL, NOM, PRENOM) " +
                                   "VALUES (@idPromotion, @idLycee, @baccalaureat, @specialiteBac, @anneeObtentionBac, @dateEntreeBTS, @dateSortieBTS, @specialiteBTS, @dateObtentionDiplome, @dateDeNaissance, @email, @nom, @prenom)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idPromotion", Etudiant._promotion);
                        command.Parameters.AddWithValue("@idLycee", Etudiant._lycee);
                        command.Parameters.AddWithValue("@baccalaureat", Etudiant._baccalaureat);
                        command.Parameters.AddWithValue("@specialiteBac", Etudiant._speBac);
                        command.Parameters.AddWithValue("@anneeObtentionBac", Etudiant._anneeBac);
                        command.Parameters.AddWithValue("@dateEntreeBTS", Etudiant._dateEntreeBts);
                        command.Parameters.AddWithValue("@dateSortieBTS", Etudiant._dateSortieBts);
                        command.Parameters.AddWithValue("@specialiteBTS", Etudiant._speBts);
                        command.Parameters.AddWithValue("@dateObtentionDiplome", Etudiant._dateObtentionBts);
                        command.Parameters.AddWithValue("@dateDeNaissance", Etudiant._dateNaissance);
                        command.Parameters.AddWithValue("@email", Etudiant._email);
                        command.Parameters.AddWithValue("@nom", Etudiant._nom);
                        command.Parameters.AddWithValue("@prenom", Etudiant._prenom);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
           
        }


            // Fonction pour modifier les informations d'un étudiant existant
            public void ModifierEtudiant(int idEtudiant, int idPromotion, int idLycee, string baccalaureat, string specialiteBac, DateTime anneeObtentionBac, DateTime dateEntreeBTS, DateTime dateSortieBTS, string specialiteBTS, DateTime dateObtentionDiplome, DateTime dateDeNaissance, string email, string nom, string prenom)
            {
                try
                {
                    using (SqlConnection connection = ConnectToDatabase())
                    {
                        string query = "UPDATE etudiant SET ID_PROMOTION = @idPromotion, ID_LYCEE = @idLycee, BACCALAUREAT = @baccalaureat, SPECIALITE_BAC = @specialiteBac, " +
                                       "ANNEE_OBTENTION_BAC = @anneeObtentionBac, DATE_ENTREE_BTS = @dateEntreeBTS, DATE_SORTIE_BTS = @dateSortieBTS, " +
                                       "SPECIALITE_BTS = @specialiteBTS, DATE_OBTENTION_DIPLOME = @dateObtentionDiplome, DATE_DE_NAISSANCE = @dateDeNaissance, " +
                                       "EMAIL = @email, NOM = @nom, PRENOM = @prenom " +
                                       "WHERE ID_ETUDIANT = @idEtudiant";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idPromotion", idPromotion);
                            command.Parameters.AddWithValue("@idLycee", idLycee);
                            command.Parameters.AddWithValue("@baccalaureat", baccalaureat);
                            command.Parameters.AddWithValue("@specialiteBac", specialiteBac);
                            command.Parameters.AddWithValue("@anneeObtentionBac", anneeObtentionBac);
                            command.Parameters.AddWithValue("@dateEntreeBTS", dateEntreeBTS);
                            command.Parameters.AddWithValue("@dateSortieBTS", dateSortieBTS);
                            command.Parameters.AddWithValue("@specialiteBTS", specialiteBTS);
                            command.Parameters.AddWithValue("@dateObtentionDiplome", dateObtentionDiplome);
                            command.Parameters.AddWithValue("@dateDeNaissance", dateDeNaissance);
                            command.Parameters.AddWithValue("@email", email);
                            command.Parameters.AddWithValue("@nom", nom);
                            command.Parameters.AddWithValue("@prenom", prenom);
                            command.Parameters.AddWithValue("@idEtudiant", idEtudiant);

                            command.ExecuteNonQuery();

                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }

            // Fonction pour supprimer un étudiant
            public void SupprimerEtudiant(int idEtudiant)
            {
                try
                {
                    using (SqlConnection connection = ConnectToDatabase())
                    {
                        string query = "DELETE FROM ETUDIANT WHERE ID_ETUDIANT = @idEtudiant";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@idEtudiant", idEtudiant);

                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }



        internal void AjouterTypeIntervention(TypeIntervention TypeIntervention)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "INSERT INTO TYPE_INTERVENTION (LIBELLE_INTERVENTION) " +
                                   "VALUES (@libelleIntervention)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@libelleIntervention", TypeIntervention._libelleIntervention);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        public void ModifierTypeIntervention(int idTypeIntervention, string libelleTypeIntervention)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "UPDATE type_intervention SET LIBELLE_INTERVENTION = @libelleTypeIntervention " + "WHERE ID_TYPE_INTERVENTION = @idTypeIntervention";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {    
                        command.Parameters.AddWithValue("@libelleTypeIntervention", libelleTypeIntervention);
                        command.Parameters.AddWithValue("@idTypeIntervention", idTypeIntervention);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void SupprimerTypeIntervention(int @idTypeIntervention)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "DELETE FROM TYPE_INTERVENTION WHERE ID_TYPE_INTERVENTION = @idTypeIntervention";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idTypeIntervention", idTypeIntervention);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        internal void AjouterIntervention(intervention intervention)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "INSERT INTO INTERVENTION (ID_TYPE_INTERVENTION,ID_PROFESSIONNEL,DATE_INTERVENTION) " +
                                   "VALUES (@idTypeIntervention,@professionnel,@dateIntervention)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idTypeIntervention", intervention._idTypeIntervention);
                        command.Parameters.AddWithValue("@professionnel", intervention._professionnel);
                        command.Parameters.AddWithValue("@dateIntervention", intervention._dateIntervention);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        public void ModifierIntervention(int Intervention, int idTypeIntervention, int professionnel, DateTime dateIntervention)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "UPDATE intervention SET ID_TYPE_INTERVENTION = @idTypeIntervention,ID_PROFESSIONNEL = @professionnel,DATE_INTERVENTION = @dateIntervention " + "WHERE ID_INTERVENTION = @Intervention";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idTypeIntervention", idTypeIntervention);
                        command.Parameters.AddWithValue("@professionnel", professionnel);
                        command.Parameters.AddWithValue("@dateIntervention", dateIntervention);
                        command.Parameters.AddWithValue("@Intervention", Intervention);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'intervention : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SupprimerIntervention(int @Intervention)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "DELETE FROM INTERVENTION WHERE ID_INTERVENTION = @Intervention";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Intervention", Intervention);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        internal void AjouterProfessionnel(professionnel professionnel)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "INSERT INTO PROFESSIONNEL (ID_ETUDIANT,ID_SECTEUR,DATE_ENTREE_PROFESSIONNEL) " +
                                   "VALUES (@idEtudiant,@idSecteur,@dateEntreePro)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idEtudiant", professionnel._idEtudiant);
                        command.Parameters.AddWithValue("@idSecteur", professionnel._idSecteur);
                        command.Parameters.AddWithValue("@dateEntreePro", professionnel._dateEntreePro);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void ModifierProfessionnel(int idProfessionnel, int idEtudiant, int idSecteur, DateTime dateEntreePro)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "UPDATE professionnel SET ID_ETUDIANT = @idEtudiant,ID_SECTEUR = @idSecteur,DATE_ENTREE_PROFESSIONNEL = @dateEntreePro " + "WHERE ID_PROFESSIONNEL = @idProfessionnel";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProfessionnel", idProfessionnel);
                        command.Parameters.AddWithValue("@idEtudiant", idEtudiant);
                        command.Parameters.AddWithValue("@idSecteur", idSecteur);
                        command.Parameters.AddWithValue("@dateEntreePro", dateEntreePro);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'intervention : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SupprimerProfessionnel(int idProfessionnel)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "DELETE FROM PROFESSIONNEL WHERE ID_PROFESSIONNEL = @idProfessionnel";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idProfessionnel", idProfessionnel);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        internal void AjouterCursus(postBTS postBTS)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "INSERT INTO CURSUS_POST_BTS (ID_ETUDIANT,ID_FORMATION,ANNEE_OBTENTION,RESULTAT_OBTENTION) " +
                                   "VALUES (@idEtudiant,@idFormation,@dateObtention,@resusltatObtenue)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idEtudiant", postBTS._idEtudiant);
                        command.Parameters.AddWithValue("@idFormation", postBTS._idFormation);
                        command.Parameters.AddWithValue("@dateObtention", postBTS._dateObtention);
                        command.Parameters.AddWithValue("@resusltatObtenue", postBTS._resusltatObtenue);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void ModifierCursus(int idCursus, int idEtudiant, int idFormation, DateTime dateObtention, bool resusltatObtenue)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "UPDATE cursus_post_bts SET ID_ETUDIANT = @idEtudiant,ID_FORMATION = @idFormation,ANNEE_OBTENTION = @dateObtention,RESULTAT_OBTENTION = @resusltatObtenue " + "WHERE ID_CURSUS_POST_BTS = @idCursus";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCursus", idCursus);
                        command.Parameters.AddWithValue("@idEtudiant", idEtudiant);
                        command.Parameters.AddWithValue("@idFormation", idFormation);
                        command.Parameters.AddWithValue("@dateObtention", dateObtention);
                        command.Parameters.AddWithValue("@resusltatObtenue", resusltatObtenue);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'intervention : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void SupprimerCursus(int idCursus)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "DELETE FROM CURSUS_POST_BTS WHERE ID_CURSUS_POST_BTS = @idCursus";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idCursus", idCursus);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        internal void AjouterFormation(formation formation)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "INSERT INTO FORMATION (NOM_FORMATION) " +
                                   "VALUES (@nomFormation)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nomFormation", formation._nomFormation);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
        public void ModifierFormation(int idFormation, string nomFormation)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "UPDATE formation SET NOM_FORMATION = @nomFormation " + "WHERE ID_FORMATION = @idFormation";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nomFormation", nomFormation);
                        command.Parameters.AddWithValue("@idFormation", idFormation);

                        command.ExecuteNonQuery();

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void SupprimerFormation(int idFormation)
        {
            try
            {
                using (SqlConnection connection = ConnectToDatabase())
                {
                    string query = "DELETE FROM formation WHERE ID_FORMATION = @idFormation";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@idFormation", idFormation);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
    }
    }

