using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_association
{
    internal class intervention
    {
        public int _intervention;
        public int _idTypeIntervention;
        public int _professionnel;
        public DateTime _dateIntervention;

        public int ID_INTERVENTION
        {
            get { return _intervention; }
            set { _intervention = value; }
        }
        public int ID_TYPE_INTERVENTION
        {
            get { return _idTypeIntervention; }
            set { _idTypeIntervention = value; }
        }
        public int ID_PROFESSIONNEL
        {
            get { return _professionnel; }
            set { _professionnel = value; }
        }
        public DateTime DATE_INTERVENTION
        {
            get { return _dateIntervention; }
            set { _dateIntervention = value; }
        }

        public intervention(int p_idTypeIntervention, int p_professionnel, DateTime p_dateIntervention)
        {
            _idTypeIntervention = p_idTypeIntervention;
            _professionnel = p_professionnel;
            _dateIntervention = p_dateIntervention;

        }
    }
}
