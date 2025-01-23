using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_association
{
    internal class TypeIntervention
    {
        public int _idTypeIntervention;
        public string _libelleIntervention;

        public int ID_TYPE_INTERVENTION
        {
            get { return _idTypeIntervention; }
            set { _idTypeIntervention = value; }
        }
        public string LIBELLE_INTERVENTION
        {
            get { return _libelleIntervention; }
            set { _libelleIntervention = value; }
        }
       
        public TypeIntervention(string p_libelleIntervention)
        {
            _libelleIntervention = p_libelleIntervention;

        }
    }
}
