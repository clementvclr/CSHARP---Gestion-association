using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_association
{
    internal class postBTS
    {
        public int _idCursus;
        public int _idEtudiant;
        public int _idFormation;
        public DateTime _dateObtention;
        public bool _resusltatObtenue;

        public int ID_CURSUS_POST_BTS
        {
            get { return _idCursus; }
            set { _idCursus = value; }
        }
        public int ID_ETUDIANT
        {
            get { return _idEtudiant; }
            set { _idEtudiant = value; }
        }
        public int ID_FORMATION
        {
            get { return _idFormation; }
            set { _idFormation = value; }
        }
        public DateTime ANNEE_OBTENTION
        {
            get { return _dateObtention; }
            set { _dateObtention = value; }
        }
        public bool RESULTAT_OBTENTION
        {
            get { return _resusltatObtenue; }
            set { _resusltatObtenue = value; }
        }

        public postBTS(int p_idEtudiant, int p_idFormation, DateTime p_dateObtention, bool p_resusltatObtenue)
        {
            _idEtudiant = p_idEtudiant;
            _idFormation = p_idFormation;
            _dateObtention = p_dateObtention;
            _resusltatObtenue = p_resusltatObtenue;
        }
    }
}
