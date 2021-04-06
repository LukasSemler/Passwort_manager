using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace Passwort_manager_einfacher
{
    class User
    {
        public string Vorname { get; set; }
        public string MasterPW { get; set; }
        public bool ErstesMalAnmelden { get; set; }

        public List<Passwort> ListePasswörter = new List<Passwort> { };


        public User(string vorname, string masterPW, bool erstesMalAnmelden)
        {
            Vorname = vorname;
            
            MasterPW = masterPW;
            ErstesMalAnmelden = erstesMalAnmelden;

        }

        public override string ToString()
        {
            return $"Vorname: {Vorname} | MasterPW: {MasterPW} | listePW {ListePasswörter}";
        }
    }
}
