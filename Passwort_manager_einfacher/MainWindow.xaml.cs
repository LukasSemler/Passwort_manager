using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Newtonsoft;
using System.IO;
using Newtonsoft.Json;
using System.Drawing;


namespace Passwort_manager_einfacher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {
        bool erstesMalAnmelden = true;
        string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\test.json";
        User aktiv;
        bool angemeldet;

        bool Kleinbuchstaben;
        bool Großbuchstaben = false;
        bool Ziffern = false;
        bool Sonderzeichen = false;
        string PW_erzeugen;
        int Länge_passwort;
        string passwd;
        bool PasswörterEingeblendet = false;



        string key = "b14ca5898a4e4133bbce2ea2315a1916";





        public MainWindow()
        {
            
            

            InitializeComponent();
            //Alle Felder ausblenden
            
            TextBox_Reg_Vorname.Visibility = Visibility.Hidden;
            PasswortBox_Reg_Passwort.Visibility = Visibility.Hidden;
            PasswortBox_Reg_Passwort_Wiederholen.Visibility = Visibility.Hidden;
            Lable_Anmelden.Visibility = Visibility.Hidden;
            Lable_Anmelden_PW.Visibility = Visibility.Hidden;
            Lable_PW.Visibility = Visibility.Hidden;
            Lable_PW_WH.Visibility = Visibility.Hidden;
            Lable_Reg.Visibility = Visibility.Hidden;
            PasswortBox_Passwort.Visibility = Visibility.Hidden;
            Lable_Vorname.Visibility = Visibility.Hidden;
            Button_Anmelden.Visibility = Visibility.Hidden;
            Button_Registrieren.Visibility = Visibility.Hidden;

            //TabItem_ausblenden
            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Hidden;
            TabItem_PW_generieren.Visibility = Visibility.Hidden;
            TabItem_Acc_löschen.Visibility = Visibility.Hidden;

            






        }

//_________________________ Methoden Felder clearen____________________________________________________

        public bool  FelderRegClearen()
        {
            
            TextBox_Reg_Vorname.Clear();
            PasswortBox_Reg_Passwort.Clear();
            PasswortBox_Reg_Passwort_Wiederholen.Clear();
            return true;
        }


        public bool FelderAnmeldenClearen()
        {
            PasswortBox_Passwort.Clear();
            return true;
                
        }

        public bool FelderPWHinzufügenClearen()
        {
            TextBox_User_Webseite_hinzufügen.Clear();
            TextBox_Webseite_hinzufügen.Clear();
            Passwort_hizufügen_.Clear();
            Passwort_hizufügen__WH.Clear();
            return true;
        }


        public bool FelderAccLöschen()
        {
            PasswordBox_Acc_löschen.Clear();
            PasswordBox_Acc_löschen_WH.Clear();
            return true;
        }



        //_______________________________TAB1_____________________________________________________________________________________





        private void Button_anfang_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                //Schauen ob Datei vorhanden und überprüfen ob registriert
                using (StreamReader sr = new StreamReader(path))
                {
                    //User lesen wenn vorhanden
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        User U1 = JsonConvert.DeserializeObject<User>(line);
                        aktiv = U1;
                        erstesMalAnmelden = aktiv.ErstesMalAnmelden;
                    }
                    //Wenn User vorhanden ausgeben das bereits registriert
                    if (erstesMalAnmelden == false)
                    {
                        //Alles für Anmelden einblenden
                        Lable_Anmelden.Visibility = Visibility.Visible;
                        Lable_Anmelden_PW.Visibility = Visibility.Visible;
                        PasswortBox_Passwort.Visibility = Visibility.Visible;
                        Button_Anmelden.Visibility = Visibility.Visible;

                        //Fortfahren ausblenden
                        Button_anfang.Visibility = Visibility.Hidden;
                        Lable_Fortfahren.Visibility = Visibility.Hidden;



                    }
                }
               

            }//User ist nicht registriert
            catch
            {
                //Fortfahren Button und lable Ausblenden
                Button_anfang.Visibility = Visibility.Hidden;
                Lable_Fortfahren.Visibility = Visibility.Hidden;


                //Alles fürs Reg einblenden
                Lable_Reg.Visibility = Visibility.Visible;
                Lable_Vorname.Visibility = Visibility.Visible;
                Lable_PW.Visibility = Visibility.Visible;
                Lable_PW_WH.Visibility = Visibility.Visible;
                Button_Registrieren.Visibility = Visibility.Visible;
                TextBox_Reg_Vorname.Visibility = Visibility.Visible;
                PasswortBox_Reg_Passwort.Visibility = Visibility.Visible;
                PasswortBox_Reg_Passwort_Wiederholen.Visibility = Visibility.Visible;

            }
        }




        private void Button_Registrieren_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {

                //Schauen ob Datei vorhanden und überprüfen ob registriert
                using (StreamReader sr = new StreamReader(path))
                {
                    //User lesen wenn vorhanden
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        User U1 = JsonConvert.DeserializeObject<User>(line);
                        aktiv = U1;
                        erstesMalAnmelden = aktiv.ErstesMalAnmelden;
                    }
                    //Wenn User vorhanden ausgeben das bereits registriert
                    if (erstesMalAnmelden == false)
                    {
                        MessageBox.Show("Sie sind bereits registriert.");
                        FelderRegClearen();
                    }
                }
                /*
                Lable_Anmelden.Visibility = Visibility.Visible;
                PasswortBox_Passwort.Visibility = Visibility.Visible;
                Button_Anmelden.Visibility = Visibility.Visible;
                */
            }
            catch
            {

                //User erstellen
                if (TextBox_Reg_Vorname.Text != "")
                {
                    if (PasswortBox_Reg_Passwort.Password != "")
                    {
                        if (PasswortBox_Reg_Passwort_Wiederholen.Password != "")
                        {
                            if (PasswortBox_Reg_Passwort.Password == PasswortBox_Reg_Passwort_Wiederholen.Password)
                            {
                                //Lables Reg Ausblenden
                                Lable_Reg.Visibility = Visibility.Hidden;
                                Lable_Vorname.Visibility = Visibility.Hidden;
                                Lable_PW.Visibility = Visibility.Hidden;
                                Lable_PW_WH.Visibility = Visibility.Hidden;
                                Button_Registrieren.Visibility = Visibility.Hidden;
                                TextBox_Reg_Vorname.Visibility = Visibility.Hidden;
                                PasswortBox_Reg_Passwort.Visibility = Visibility.Hidden;
                                PasswortBox_Reg_Passwort_Wiederholen.Visibility = Visibility.Hidden;

                                //lable anmelden einblenden
                                Lable_Anmelden.Visibility = Visibility.Visible;
                                Lable_Anmelden_PW.Visibility = Visibility.Visible;
                                PasswortBox_Passwort.Visibility = Visibility.Visible;
                                Button_Anmelden.Visibility = Visibility.Visible;

                                erstesMalAnmelden = true;
                                MessageBox.Show("Hallo und herzlich willkommen bei Ihrem Passwort Manager");
                                User U1 = new User(TextBox_Reg_Vorname.Text, PasswortBox_Reg_Passwort.Password, false);

                                //User in Datei schreiben
                                string JsonSchreiben = JsonConvert.SerializeObject(U1);
                                using (StreamWriter sw = new StreamWriter(path))
                                {
                                    sw.WriteLine(JsonSchreiben);
                                }
                            }
                            else
                                MessageBox.Show("Die Passwörter stimmen nicht überein!");
                        }
                        else
                            MessageBox.Show("Bitte füllen Sie das 'Passwort wiederholen' Feld aus");
                            
                           
                    }
                    else
                        MessageBox.Show("Bitte füllen Sie das Feld 'Passwort' aus");
                }
                else
                    MessageBox.Show("Bitte füllen Sie das Feld 'Vorname' aus.");
                   
                
               //Felder clearen
                FelderRegClearen();
               
            }

        }

//----------------------------------------------------------------------------------------------------------------------------------------

        private void Button_Anmelden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //User lesen und anmelden
                using (StreamReader sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        User U1 = JsonConvert.DeserializeObject<User>(line);
                        aktiv = U1;
                    }
                    if (aktiv.MasterPW == PasswortBox_Passwort.Password)
                    {
                        MessageBox.Show($"Willkommen {aktiv.Vorname}");
                        angemeldet = true;
                        //Tab Item einblenden
                        TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Visible;
                        TabItem_PW_generieren.Visibility = Visibility.Visible;
                        TabItem_Acc_löschen.Visibility = Visibility.Visible;
                        //Anmelden Labels ausblenden
                        Lable_Anmelden.Visibility = Visibility.Hidden;
                        Lable_Anmelden_PW.Visibility = Visibility.Hidden;
                        PasswortBox_Passwort.Visibility = Visibility.Hidden;
                        Button_Anmelden.Visibility = Visibility.Hidden;
                        //TabItem Anmelden Reg Ausblenden
                        TabItem_Anmelden_Reg.Visibility = Visibility.Hidden;
                        //Aktives TabItem ändern
                        TabControl1.SelectedItem = TabItem_PW_hinzufügen_löschen;

                    }
                    else
                    {
                        MessageBox.Show("Die Passwort ist nicht korrekt");
                    }

                    FelderAnmeldenClearen();
                }
            }
            catch
            {
                MessageBox.Show("Sie müssen sich zuerst registrieren");
                PasswortBox_Passwort.Clear();
            }
           
        }





//_________________________TAB2_________________________________________________________________________________





        private void Button_PW_speichern_Click(object sender, RoutedEventArgs e)
        {
            //Überprüfen ob angemeldet
            if (angemeldet == false)
            {
                MessageBox.Show("Bitte melden Sie sich zuerst an!");

                FelderPWHinzufügenClearen();
            }
            else
            {
                //genaueres überprüfen (unnötig)
                /*
                //Überprüfen ob Felder leer
                if (TextBox_Webseite_hinzufügen.Text == "")
                {
                    MessageBox.Show("Bitte geben Sie einen Verwendungszweck ein!");
                    FelderPWHinzufügenClearen();
                }
                else if (TextBox_User_Webseite_hinzufügen.Text == "")
                {
                    MessageBox.Show("Bitte geben Sie einen Usernamen ein!");
                    FelderPWHinzufügenClearen();
                }
                else if (Passwort_hizufügen_.Password == "")
                {
                    MessageBox.Show("Bitte geben Sie ein Passwort ein!");
                    FelderPWHinzufügenClearen();
                }
                else if (TextBox_Webseite_hinzufügen.Text == "")
                {
                    if (TextBox_User_Webseite_hinzufügen.Text == "")
                    {
                        if (Passwort_hizufügen_.Password == "")
                        {
                            MessageBox.Show("Alle Felder sind leer");
                        }
                    }
                }
                */


                if (TextBox_Webseite_hinzufügen.Text == "" || TextBox_User_Webseite_hinzufügen.Text == "" || Passwort_hizufügen_.Password == "" )
                {
                    MessageBox.Show("Es sind nicht alle Felder ausgefüllt !"); 
                }
                else if (Passwort_hizufügen_.Password == Passwort_hizufügen__WH.Password)
                {
                  

                    //Passwort wird verschlüsselt
                    string passwort_verschlüsselt = AesOperation.EncryptString(key, Passwort_hizufügen_.Password); 

                    Passwort P1 = new Passwort(TextBox_Webseite_hinzufügen.Text, TextBox_User_Webseite_hinzufügen.Text, passwort_verschlüsselt);
                    MessageBox.Show(passwort_verschlüsselt); 
                    aktiv.ListePasswörter.Add(P1);

                    FelderPWHinzufügenClearen();
                }
                else
                    MessageBox.Show("Die Passwörter stimmen nicht überein!");
               
            }



        }

//--------------------------------------------------------------------------------------------------------------------------------------------

        private void Button_abmelden_Click(object sender, RoutedEventArgs e)
        {
            angemeldet = false;
            PasswörterEingeblendet = false;
            ListBox_Ausgeben.Items.Clear();
            MessageBox.Show("Sie wurden abgemeldet");
            Lable_Ausgabe.Content = "";
            TextBox_länge_PW.Clear();

            //TabItem Anmelden Reg einblenden
            TabItem_Anmelden_Reg.Visibility = Visibility.Visible;

            //Andere Tab Item ausblenden
            TabItem_Acc_löschen.Visibility = Visibility.Hidden;
            TabItem_PW_generieren.Visibility = Visibility.Hidden;
            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Hidden;

            //Tab item wechseln
            TabControl1.SelectedItem = TabItem_Anmelden_Reg;

            //Lable anmelden einblenden
            Lable_Anmelden.Visibility = Visibility.Visible;
            Lable_Anmelden_PW.Visibility = Visibility.Visible;
            PasswortBox_Passwort.Visibility = Visibility.Visible;
            Button_Anmelden.Visibility = Visibility.Visible;

        }

//----------------------------------------------------------------------------------------------------------------------------------------------

        private void Button_PW_laden_Click(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (PasswörterEingeblendet == false)
                {
                    //Überprüfen ob angemeldet
                    if (angemeldet == true)
                    {
                        
                        //File löschen
                        File.Delete(path);

                        //File schreiben
                        string JsonSchreiben = JsonConvert.SerializeObject(aktiv);
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            sw.WriteLine(JsonSchreiben);
                        }

                        //File lesen
                        using (StreamReader sr = new StreamReader(path))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                User U1 = JsonConvert.DeserializeObject<User>(line);
                                aktiv = U1;
                            }
                        }

                        

                        //Passwörter in ListBox geben
                        foreach (var item in aktiv.ListePasswörter)
                        {
                            ListBox_Ausgeben.Items.Add(item);
                            
                        }

                        PasswörterEingeblendet = true;

                    }
                    else
                        MessageBox.Show("Bitte melden Sie sich zuerst an!");

                }
                else
                {
                    MessageBox.Show("Die Passwörter werden bereits angezeigt");
                }
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            

        }

//------------------------------------------------------------------------------------------------------------------------------------------------

        private void Button_PW_ausblenden_Click(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (PasswörterEingeblendet == true)
                {
                    //Überprüfen ob angemeldet
                    if (angemeldet == true)
                    {
                        //ListBox leeren
                        ListBox_Ausgeben.Items.Clear();
                        PasswörterEingeblendet = false;
                    }
                    else
                        MessageBox.Show("Bitte melden Sie sich zuerst an!");
                }
                else
                {
                    MessageBox.Show("Die Passwörter werden nicht angezeigt");
                }
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
           
            

        }

        //----------------------------------------------------------------------------------------------------------------------------------------------------


        private void Button_PW_text_einblenden_Click(object sender, RoutedEventArgs e)
        {
            if (PasswörterEingeblendet == true)
            {
                foreach (var item in ListBox_Ausgeben.Items)
                {
                    if (item == ListBox_Ausgeben.SelectedItem)
                    {
                        
                        Passwort Angezeigt = (Passwort)item;
                        string passwort_entschlüsselt = AesOperation.DecryptString(key, Angezeigt.PasswortText);
                        MessageBox.Show($"Passwort Text: {passwort_entschlüsselt}");
                    }
                    
                }
            }
            else
                MessageBox.Show("Sie müssen zuerst die Passwörter einblenden!");
        }


//--------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void Button_löschen_Click(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                //auswahl treffen zum löschen
                var zuLöschen = (Passwort)ListBox_Ausgeben.SelectedItem;

                //Listbox löschen
                ListBox_Ausgeben.Items.Remove(zuLöschen);
                //Aus der Liste löschen    
                aktiv.ListePasswörter.Remove(zuLöschen);
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            

        }


//_________________________________________TAB3___________________________________________________________________________________________________

//------------Kleinbuchstaben---------------------------------------------------------------------------------------------------------------------

        private void CheckBox_Kleinbuchstaben_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Kleinbuchstaben_nein.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Kleinbuchstaben = true;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
           
        }

        private void CheckBox_Kleinbuchstaben_nein_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Kleinbuchstaben_Ja.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Kleinbuchstaben = false;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            
        }


//--------------------------------------------Großbuchstaben---------------------------------------------------------------

        private void CheckBox_Großbuchstaben_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Großbuchstaben_nein.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Großbuchstaben = true;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            
        }

        private void CheckBox_Großbuchstaben_nein_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Großbuchstaben_Ja.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Großbuchstaben = false;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            

        }



//---------------------------------------------------Ziffern--------------------------------------------------------

        private void CheckBox_Ziffern_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Ziffern_nein.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Ziffern = true;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            
        }

        private void CheckBox_Ziffern_nein_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Ziffern_Ja.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Ziffern = false;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");

            
        }

//----------------------------------------------Sonderzeichen--------------------------------------------------------

        private void CheckBox_Sonderzeichen_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Sonderzeichen_nein.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Sonderzeichen = true;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
           
        }

        private void CheckBox_Sonderzeichen_nein_Checked(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                if (CheckBox_Sonderzeichen_Ja.IsChecked == true)
                {
                    MessageBox.Show("Sie können nicht beides haben ...!");
                }
                else
                    Sonderzeichen = false;
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");            
        }

//------------------------------------------Generieren--------------------------------------------------------

        private void Button_PW_generieren_Click(object sender, RoutedEventArgs e)
        {

            if (angemeldet == true)
                try
                {
                    passwd = "";

                    if (Kleinbuchstaben == true)
                        PW_erzeugen += "abcdefghijklmnopqrstuvwxyz";
                    if (Großbuchstaben == true)
                        PW_erzeugen += "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                    if (Ziffern == true)
                        PW_erzeugen += "0123456789";
                    if (Sonderzeichen == true)
                        PW_erzeugen += @"^!\§$%&/()=?²³{[]}\\`´+*~#',.-;:_<>|";
                    if (PW_erzeugen.Length == 0)
                        MessageBox.Show("Sie müssen etwas auswählen");


                    Länge_passwort = Convert.ToInt32(TextBox_länge_PW.Text);
                    int laenge = Länge_passwort;

                    //a=1; A=2; 1=4

                    char[] lower_case = new char[] { 'z', 'y', 'x', 'w', 'v', 'u', 't', 's', 'r', 'q', 'p', 'o', 'n', 'm', 'l', 'k', 'j', 'i', 'h', 'g', 'f', 'e', 'd', 'c', 'b', 'a', };
                    char[] upper_case = new char[] { 'Z', 'Y', 'X', 'W', 'V', 'U', 'T', 'S', 'R', 'Q', 'P', 'O', 'N', 'M', 'L', 'K', 'J', 'I', 'H', 'G', 'F', 'E', 'D', 'C', 'B', 'A', };
                    char[] numbers = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0' };
                    char[] symbols = new char[] { '²', '³', '{', '[', ']', '}', '\\', '^', '°', '!', '"', '§', '$', '%', '&', '/', '(', ')', '=', '?', '`', '´', '+', '*', '~', '#', '\'', '-', '_', '.', ':', ',', ';', '<', '>', '|' };

                    System.Text.StringBuilder pool = new System.Text.StringBuilder();

                    if (Kleinbuchstaben == true)
                        pool.Append(lower_case);

                    if (Großbuchstaben == true)
                        pool.Append(upper_case);

                    if (Ziffern == true)
                        pool.Append(numbers);

                    if (Sonderzeichen == true)
                        pool.Append(symbols);

                    if ((!Kleinbuchstaben) && (!Großbuchstaben) && (!Ziffern) && (!Sonderzeichen))
                    {
                        MessageBox.Show("Nichts ausgewählt");
                        Close();
                    }
                    Random rnd = new Random();



                    for (int i = 1; i <= laenge; i++)
                    {
                        char passwd_tmp = pool[rnd.Next(pool.Length)];
                        passwd = passwd + passwd_tmp;
                    }

                    Lable_Ausgabe.Content = passwd;
                    
                    
                    
                }
                catch
                {
                    Close();
                }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");




        }

        
//------------------------------------------------In zwischenablage Speichern-----------------------------


        private void Button_Speichern_Click(object sender, RoutedEventArgs e)
        {
            if (angemeldet == true)
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetText(passwd);
                    MessageBox.Show("Passwort wurde in die Zwischenablage kopiert");
                }
                catch
                {

                    MessageBox.Show(passwd);
                }
            }
            else
                MessageBox.Show("Bitte melden Sie sich zuerst an!");
            

        }


        //_______________________________________________Tab4__________________________________________________________

        private void Button_Acc_löschen_Click(object sender, RoutedEventArgs e)
        {
            if (aktiv.ErstesMalAnmelden == false)
            {
                if (PasswordBox_Acc_löschen.Password == aktiv.MasterPW)
                {
                    if (PasswordBox_Acc_löschen_WH.Password == aktiv.MasterPW)
                    {
                        string MessageBox_text = "Wenn Sie auf 'löschen' drücken wird Ihr Account und Ihre Daten für immer gelöscht!";
                        string caption = "Account löschen";
                        MessageBoxButton button = MessageBoxButton.YesNo;
                        MessageBoxImage icon = MessageBoxImage.Warning;
                        MessageBoxResult result = MessageBox.Show(MessageBox_text, caption, button, icon);

                        if (result == MessageBoxResult.No)
                        {
                            MessageBox.Show("Der Account wurde nicht gelöscht");
                        }
                        else
                        {
                            MessageBox.Show("Ihr Account wurde gelöscht");

                            File.Delete(path);
                            angemeldet = false;

                            //TabItem ausblenden
                            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Hidden;
                            TabItem_PW_generieren.Visibility = Visibility.Hidden;
                            TabItem_Acc_löschen.Visibility = Visibility.Hidden;
                            
                            //TabItem wechseln
                            TabControl1.SelectedItem = TabItem_Anmelden_Reg;

                            //Lable Anmelden Reg ausblenden
                            Lable_Anmelden.Visibility = Visibility.Hidden;
                            Lable_Anmelden_PW.Visibility = Visibility.Hidden;
                            PasswortBox_Passwort.Visibility = Visibility.Hidden;
                            Button_Anmelden.Visibility = Visibility.Hidden;

                            //Fortfahren einblenden
                            Lable_Fortfahren.Visibility = Visibility.Visible;
                            Button_anfang.Visibility = Visibility.Visible;

                            //TabItem Anmelden Reg einblenden
                            TabItem_Anmelden_Reg.Visibility = Visibility.Visible;

                        }
                    }
                    else
                        MessageBox.Show("Die Passwörter stimmen nicht überein!");
                }
                else
                    MessageBox.Show("Das Passwort ist nicht Ihr Master Passwort");

            }
            else
                MessageBox.Show("Sie müssen sich zuerst einen Account erstellen");




        }

        
    }
}