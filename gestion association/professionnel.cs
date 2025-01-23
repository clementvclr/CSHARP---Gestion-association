using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_association
{
    internal class professionnel
    {
        public int _idProfessionnel;
        public int _idEtudiant;
        public int _idSecteur;
        public DateTime _dateEntreePro;

        public int ID_PROFESSIONNEL
        {
            get { return _idProfessionnel; }
            set { _idProfessionnel = value; }
        }
        public int ID_ETUDIANT
        {
            get { return _idEtudiant; }
            set { _idEtudiant = value; }
        }
        public int ID_SECTEUR
        {
            get { return _idSecteur; }
            set { _idSecteur = value; }
        }
        public DateTime DATE_ENTREE_PROFESSIONNEL
        {
            get { return _dateEntreePro; }
            set { _dateEntreePro = value; }
        }

        public professionnel(int p_idEtudiant, int p_idSecteur, DateTime p_dateEntreePro)
        {
            _idEtudiant = p_idEtudiant;
            _idSecteur = p_idSecteur;
            _dateEntreePro = p_dateEntreePro;

        }
    }
}
