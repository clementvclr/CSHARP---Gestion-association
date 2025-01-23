using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gestion_association
{
    internal class formation
    {
        public int _idFormation;
        public string _nomFormation;

        public int ID_FORMATION
        {
            get { return _idFormation; }
            set { _idFormation = value; }
        }
        public string NOM_FORMATION
        {
            get { return _nomFormation; }
            set { _nomFormation = value; }
        }

        public formation(string p_nomFormation)
        {
            _nomFormation = p_nomFormation;
        }
    }
}
