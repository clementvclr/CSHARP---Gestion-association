using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_association
{
    internal class Etudiant
    {
            public int _idEtudiant;
            public int _promotion;
            public int _lycee;
            public string _baccalaureat;
            public string _speBac;
            public DateTime _anneeBac;
            public DateTime _dateEntreeBts;
            public DateTime _dateSortieBts;
            public string _speBts;
            public DateTime _dateObtentionBts;
            public DateTime _dateNaissance;
            public string _email;
            public string _nom;
            public string _prenom;

            public int ID_ETUDIANT 
            {
                get { return _idEtudiant; }
                set { _idEtudiant = value; }
            }
            public int ID_PROMOTION 
            {
                get { return _promotion; }
                set { _promotion = value; }
            }
            public int ID_LYCEE 
            {
                get { return _lycee; }
                set { _lycee = value; }
            }
            public string BACCALAUREAT 
            {
                get { return _baccalaureat; }
                set { _baccalaureat = value; }
            }
            public string SPECIALITE_BAC 
            {
                get { return _speBac; }
                set { _speBac = value; }
            }
            public DateTime ANNEE_OBTENTION_BAC 
            {
                get { return _anneeBac; }
                set { _anneeBac = value; }
            }
            public DateTime DATE_ENTREE_BTS
            {
                get { return _dateEntreeBts; }
                set { _dateEntreeBts = value; }
            }
            public DateTime DATE_SORTIE_BTS 
            {
                get { return _dateSortieBts; }
                set { _dateSortieBts = value; }
            }
            public string SPECIALITE_BTS 
            {
                get { return _speBts; }
                set { _speBts = value; }
            }
            public DateTime DATE_OBTENTION_DIPLOME
            {
                get { return _dateObtentionBts; }
                set { _dateObtentionBts = value; }
            }
            public DateTime DATE_DE_NAISSANCE
            {
                get { return _dateNaissance; }
                set { _dateNaissance = value; }
            }
            public string EMAIL 
            {
                get { return _email; }
                set { _email = value; }
            }
            public string NOM 
            {
                get { return _nom; }
                set { _nom = value; }
            }
            public string PRENOM 
            {
                get { return _prenom; }
                set { _prenom = value; }
            }
            public Etudiant (int p_promotion, int p_lycee, string p_baccalaureat, string p_speBac, DateTime p_anneeBac, DateTime p_dateEntreeBts, DateTime p_dateSortieBts, string p_speBts, DateTime p_dateObtentionBts, DateTime p_dateNaissance, string p_email, string p_nom, string p_prenom)
            {
               _promotion = p_promotion;
               _lycee = p_lycee;
               _baccalaureat = p_baccalaureat;
               _speBac = p_speBac;
               _anneeBac = p_anneeBac;
               _dateEntreeBts = p_dateEntreeBts;
               _dateSortieBts = p_dateSortieBts;
               _speBts = p_speBts;
               _dateObtentionBts = p_dateObtentionBts;
               _dateNaissance = p_dateNaissance;
               _email = p_email;
               _nom = p_nom;
               _prenom = p_prenom;
             
        }
    }
}
