using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using static gestion_association.CRUD;

namespace gestion_association
{
    internal static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        public static CRUD crud;
        [STAThread]
        static void Main()
        {
            crud = new CRUD();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmconnexion());
        }
    }
}
