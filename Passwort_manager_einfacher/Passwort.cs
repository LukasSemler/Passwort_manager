using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft;

namespace Passwort_manager_einfacher
{
    class Passwort
    {
        public string Verwendungszweck { get; set; }
        public string Username { get; set; }
        public string PasswortText { get; set; }

        public Passwort( string verwendungszweck, string username, string passwortText)
        {
            Verwendungszweck = verwendungszweck;
            Username = username;
            PasswortText = passwortText;
        }


        public override string ToString()
        {
            return $"Verwendungszweck: {Verwendungszweck} | Username: {Username} | Passwort: *************";
        }
    }
}
