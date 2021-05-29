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
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Controls.Primitives;

namespace Passwort_manager_einfacher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    /// 


    public partial class MainWindow : Window
    {

        #region Variablen

       
        string path =  @"..\..\bin\debug\test.txt";
        string path2 = @"..\..\bin\debug\test2.txt";
        User aktiv;
        

        bool Kleinbuchstaben;
        bool Großbuchstaben = false;
        bool Ziffern = false;
        bool Sonderzeichen = false;
        string PW_erzeugen;
        int Länge_passwort;
        string passwd;

        


        string key = "b14ca5898a4e4133bbce2ea2315a1916";


        bool gespeichert = true;


        List<User> ListeRegUser = new List<User>();
        List<User> geladen;


        #endregion


        #region Main_Window
        public MainWindow()
        {


            InitializeComponent(); 
            AnfangTabItemAusblenden();


            string line; 


            try
            {
                //File entschlüsseln und verschlüsseltes löschen
                Sicherheit.DecryptFile(path2, path);
                File.Delete(path2);


                //Pass the file path and file name to the StreamReader constructor
                StreamReader sr = new StreamReader("../../bin/debug/test.txt");
                //Read the first line of text
                line = sr.ReadLine();
                //Continue to read until you reach end of file
                while (line != null)
                {
                    //write the lie to console window
                   
                    geladen = JsonConvert.DeserializeObject<List<User>>(line);
                    //Read the next line
                    line = sr.ReadLine();
                }
                //close the file
                sr.Close();


                foreach (var item in geladen)
                {
                    ListeRegUser.Add(item);
                }


                

            }
            catch
            {

            }




        }

        #endregion

        #region Felder Clearen
        //_________________________ Methoden Felder clearen____________________________________________________

        public void FelderRegClearen()
        {
            
            TextBox_Reg_Vorname.Clear();
            PasswortBox_Reg_Passwort.Clear();
            PasswortBox_Reg_Passwort_Wiederholen.Clear();
            TextBox_Reg_Username.Clear(); 
        
        }


        public void FelderAnmeldenClearen()
        {
            PasswortBox_Passwort.Clear();
            TextBox_Login_Username.Clear(); 
                
        }

        public void FelderPWHinzufügenClearen()
        {
            TextBox_User_Webseite_hinzufügen.Clear();
            TextBox_Webseite_hinzufügen.Clear();
            Passwort_hizufügen_.Clear();
            Passwort_hizufügen__WH.Clear();
           
        }


        public void FelderAccLöschen()
        {
            PasswordBox_Acc_löschen.Clear();
            PasswordBox_Acc_löschen_WH.Clear();
        }




        #endregion

        #region Felder ein und Ausblenden

        public void AlleFelderAusblenden()
        {
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
        }

        public void AnfangTabItemAusblenden()
        {
            //TabItem_ausblenden
            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Hidden;
            TabItem_PW_generieren.Visibility = Visibility.Hidden;
            TabItem_Acc_löschen.Visibility = Visibility.Hidden;
        }

        public void AnmeldenEinblenden()
        {
            //Alles für Anmelden einblenden
            Lable_Anmelden.Visibility = Visibility.Visible;
            Lable_Anmelden_PW.Visibility = Visibility.Visible;
            PasswortBox_Passwort.Visibility = Visibility.Visible;
            Button_Anmelden.Visibility = Visibility.Visible;
        }

       
        public void TabItemsEinblenden()
        {
            //Tab Item einblenden
            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Visible;
            TabItem_PW_generieren.Visibility = Visibility.Visible;
            TabItem_Acc_löschen.Visibility = Visibility.Visible;
        }

        public void TabItemsAusblenden()
        {
            //Tab Item einblenden
            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Hidden;
            TabItem_PW_generieren.Visibility = Visibility.Hidden;
            TabItem_Acc_löschen.Visibility = Visibility.Hidden;
        }

        public void RegistrierenEinblenden()
        {
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

        public void Reg_Ausblenden()
        {
            Lable_Reg.Visibility = Visibility.Hidden;
            Lable_Vorname.Visibility = Visibility.Hidden;
            Lable_PW.Visibility = Visibility.Hidden;
            Lable_PW_WH.Visibility = Visibility.Hidden;
            Button_Registrieren.Visibility = Visibility.Hidden;
            TextBox_Reg_Vorname.Visibility = Visibility.Hidden;
            PasswortBox_Reg_Passwort.Visibility = Visibility.Hidden;
            PasswortBox_Reg_Passwort_Wiederholen.Visibility = Visibility.Hidden;

        }

        public void Login_einblenden()
        {
            Lable_Anmelden.Visibility = Visibility.Visible;
            Lable_Anmelden_PW.Visibility = Visibility.Visible;
            PasswortBox_Passwort.Visibility = Visibility.Visible;
            Button_Anmelden.Visibility = Visibility.Visible;
        }

        public void AnmeldenAusblenden()
        {
            //Anmelden Labels ausblenden
            Lable_Anmelden.Visibility = Visibility.Hidden;
            Lable_Anmelden_PW.Visibility = Visibility.Hidden;
            PasswortBox_Passwort.Visibility = Visibility.Hidden;
            Button_Anmelden.Visibility = Visibility.Hidden;
        }

        public void AndereTabItemAusblenden()
        {
            //Andere Tab Item ausblenden
            TabItem_Acc_löschen.Visibility = Visibility.Hidden;
            TabItem_PW_generieren.Visibility = Visibility.Hidden;
            TabItem_PW_hinzufügen_löschen.Visibility = Visibility.Hidden;
        }




        #endregion

        #region Check Caps_Lock
        private void Check_Caps_Lock(object sender, RoutedEventArgs e)
        {
            if ((Keyboard.GetKeyStates(Key.CapsLock) & KeyStates.Toggled) == KeyStates.Toggled)
            {
                if (PasswortBox_Reg_Passwort.ToolTip == null)
                {
                    ToolTip tt = new ToolTip();
                    tt.Content = "Warning: CapsLock is on";
                    tt.PlacementTarget = sender as UIElement;
                    tt.Placement = PlacementMode.Bottom;
                    PasswortBox_Reg_Passwort.ToolTip = tt;
                    tt.IsOpen = true;
                }
            }
            else
            {
                var currentToolTip = PasswortBox_Reg_Passwort.ToolTip as ToolTip;
                if (currentToolTip != null)
                {
                    currentToolTip.IsOpen = false;
                }

                PasswortBox_Reg_Passwort.ToolTip = null;
            }
        }

        #endregion



        #region TAB1

        //_______________________________TAB1_____________________________________________________________________________________



        private void Button_Registrieren_Click(object sender, RoutedEventArgs e)
        {
        

            //User erstellen
            if (TextBox_Reg_Vorname.Text != "" && TextBox_Reg_Username.Text != "")
            {
                if (PasswortBox_Reg_Passwort.Password != "")
                {
                    if (PasswortBox_Reg_Passwort_Wiederholen.Password != "")
                    {
                        if (PasswortBox_Reg_Passwort.Password == PasswortBox_Reg_Passwort_Wiederholen.Password)
                        {

                            string passwort_verschlüsselt = AesOperation.EncryptString(key, PasswortBox_Reg_Passwort.Password);
                            User U1 = new User(TextBox_Reg_Vorname.Text, passwort_verschlüsselt, TextBox_Reg_Username.Text, false);

                            //Überprüfen ob Liste leer
                            if (ListeRegUser.Count != 0)
                            {
                                //Wenn Liste nicht leer dann User mit überprüfen erstellen
                                foreach (var item in ListeRegUser)
                                {
                                    //Username überprüfen
                                    if (U1.Username == item.Username)
                                    {
                                        MessageBox.Show("Der Username ist leider schon vorhanden !");
                                        //Felder clearen
                                        FelderRegClearen();
                                        break; 
                                    }
                                    else
                                    {
                                        MessageBox.Show("Hallo und herzlich willkommen bei Ihrem Passwort Manager");

                                        //Neuen User zu der Liste von Reg Usern hinzufügen
                                        ListeRegUser.Add(U1);

                                        //User in Datei schreiben
                                        string JsonSchreiben = JsonConvert.SerializeObject(ListeRegUser);
                                        using (StreamWriter sw = new StreamWriter(path))
                                        {
                                            sw.WriteLine(JsonSchreiben);
                                        }


                                        //Felder clearen
                                        FelderRegClearen();

                                        break;
                                    }
                                }
                            }
                            //User ohne überprüfen erstellen weil Liste leer somit kann es keinen User doppelt geben
                            else
                            {
                                MessageBox.Show("Hallo und herzlich willkommen bei Ihrem Passwort Manager");

                                //Neuen User zu der Liste von Reg Usern hinzufügen
                                ListeRegUser.Add(U1);

                                //User in Datei schreiben
                                string JsonSchreiben = JsonConvert.SerializeObject(ListeRegUser);
                                using (StreamWriter sw = new StreamWriter(path))
                                {
                                    sw.WriteLine(JsonSchreiben);
                                }


                                //Felder clearen
                                FelderRegClearen();

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
                MessageBox.Show("Es sind nicht alle Felder ausgefüllt");
                   
                
          
               
            

        }

        private void Button_Anmelden_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string UsernameEingabe = TextBox_Login_Username.Text;
                string PasswortEingabe = PasswortBox_Passwort.Password;
                string passwort_entschlüsselt;

                foreach (var item in ListeRegUser)
                {
                    
                    passwort_entschlüsselt = AesOperation.DecryptString(key, item.MasterPW);
                    //item.MasterPW = passwort_entschlüsselt;
                    

                    
                    if (UsernameEingabe == item.Username )
                    {
                        if (PasswortEingabe == passwort_entschlüsselt)
                        {
                            aktiv = item;
                            TabItemsEinblenden();
                            MessageBox.Show($"Willkommen {aktiv.Vorname}");

                            //TabItem Anmelden Reg Ausblenden
                            TabItem_Anmelden_Reg.Visibility = Visibility.Hidden;

                            //Aktives TabItem ändern
                            TabControl1.SelectedItem = TabItem_PW_hinzufügen_löschen;

                            //Passwort wieder verschlüsseln
                            /*
                            string verschlüsseltes_PW = AesOperation.EncryptString(key, aktiv.MasterPW);
                            aktiv.MasterPW = verschlüsseltes_PW;
                            */

                            ListBox_Ausgeben.ItemsSource = aktiv.ListePasswörter;

                        }
                        else
                        {
                            MessageBox.Show("Die Passwort ist nicht korrekt");
                        }

                    }
                    else
                    {
                       
                    }
                
                }
                
                  
                FelderAnmeldenClearen();
                
            }
                    
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString()); 
            }
           
           
        }


        #endregion

        #region TAB2

        //_________________________TAB2_________________________________________________________________________________





        private void Button_PW_speichern_Click(object sender, RoutedEventArgs e)
        {
            
          
            if (TextBox_Webseite_hinzufügen.Text != "" && TextBox_User_Webseite_hinzufügen.Text != "" && Passwort_hizufügen_.Password != "" && Passwort_hizufügen_.Password == Passwort_hizufügen__WH.Password)
            {


                //Passwort wird verschlüsselt
                string passwort_verschlüsselt = AesOperation.EncryptString(key, Passwort_hizufügen_.Password);

                Passwort P1 = new Passwort(TextBox_Webseite_hinzufügen.Text, TextBox_User_Webseite_hinzufügen.Text, passwort_verschlüsselt);
                aktiv.ListePasswörter.Add(P1);


                //Gespeichert auf false setzen
                gespeichert = false;
                Lable_Gespeichert.Background = Brushes.Red;

               

                ListBox_Ausgeben.ItemsSource = aktiv.ListePasswörter;

                ListBox_Ausgeben.Items.Refresh(); 



                FelderPWHinzufügenClearen();


            }
            else
            {
                MessageBox.Show("Sie haben ein Feld vergessen, oder die Passwörter stimmen nicht überein !");
                Passwort_hizufügen_.Clear();
                Passwort_hizufügen__WH.Clear(); 
            }
                    
               
            



        }

        //--------------------------------------------------------------------------------------------------------------------------------------------




        private void Button_abmelden_Click(object sender, RoutedEventArgs e)
        {
            //Überprüfen ob es änderungen gibt
            if (gespeichert == true)
            {
               
                
                MessageBox.Show("Sie wurden abgemeldet");
                Lable_Ausgabe.Content = "";
                TextBox_länge_PW.Clear();

                //TabItem Anmelden Reg einblenden
                TabItem_Anmelden_Reg.Visibility = Visibility.Visible;

                AndereTabItemAusblenden(); 

                //Tab item wechseln
                TabControl1.SelectedItem = TabItem_Anmelden_Reg;

                

                //Fenster schließen
                //Passwort_manager.Close();

             
            }
            else
            {
                string MessageBox_text = "Wenn Sie das Programm schließen werden alle nicht gespeicherten Änderungen verworfen ! Wollen sie wirlkich verlassen ? ";
                string caption = "Programm verlassen";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxImage icon = MessageBoxImage.Warning;
                MessageBoxResult result = MessageBox.Show(MessageBox_text, caption, button, icon);

                if(result == MessageBoxResult.Yes)
                {

                    MessageBox.Show("TESt");


                    ListBox_Ausgeben.Items.Clear(); 
                    MessageBox.Show("Sie wurden abgemeldet");
                    Lable_Ausgabe.Content = "";
                    TextBox_länge_PW.Clear();

                    //TabItem Anmelden Reg einblenden
                    TabItem_Anmelden_Reg.Visibility = Visibility.Visible;

                    TabItemsAusblenden(); 

                    //Tab item wechseln
                    TabControl1.SelectedItem = TabItem_Anmelden_Reg;

                    //AnmeldenEinblenden();

//__________________________________________________________________________________________________________________________________________________________________

                    



                }
                

            }

        }

//----------------------------------------------------------------------------------------------------------------------------------------------

        private void Button_PW_laden_Click(object sender, RoutedEventArgs e)
        {

            //File löschen
            File.Delete(path);

            //File schreiben
            string JsonSchreiben = JsonConvert.SerializeObject(ListeRegUser);
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
                    geladen = JsonConvert.DeserializeObject<List<User>>(line);
                   
                }
            }

            foreach (var item in geladen)
            {
                ListeRegUser.Add(item); 
            }


            //Item source Festlegen
            ListBox_Ausgeben.ItemsSource = aktiv.ListePasswörter;




            //Gespeichert auf true setzen
            gespeichert = true;
            Lable_Gespeichert.Background = Brushes.Lime; 

            

        }

//------------------------------------------------------------------------------------------------------------------------------------------------


        private void Button_PW_text_einblenden_Click(object sender, RoutedEventArgs e)
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


//--------------------------------------------------------------------------------------------------------------------------------------------------------------


        private void Button_löschen_Click(object sender, RoutedEventArgs e)
        {
            
            //auswahl treffen zum löschen
            var zuLöschen = (Passwort)ListBox_Ausgeben.SelectedItem;

           
            //Aus der Liste löschen    
            aktiv.ListePasswörter.Remove(zuLöschen);

            //Item Source 
            ListBox_Ausgeben.ItemsSource = aktiv.ListePasswörter;
            ListBox_Ausgeben.Items.Refresh(); 

            //Lable auf Rot setzen und geseichert auf false
            Lable_Gespeichert.Background = Brushes.Red;
            gespeichert = false; 

           
            

        }

        #endregion

        #region TAB3

        //_________________________________________TAB3___________________________________________________________________________________________________

        //------------------------Großbuchstaben----------------------------------------
        private void Radio_Großbuchstaben_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Großbuchstaben_Ja.IsChecked == true)
            {
                Radio_Großbuchstaben_Nein.IsChecked = false;
                Großbuchstaben = true;
                MessageBox.Show(Großbuchstaben.ToString()); 
            }
            else if (Radio_Großbuchstaben_Nein.IsChecked == true)
            {
                Radio_Großbuchstaben_Ja.IsChecked = false;
                Großbuchstaben = false;
                MessageBox.Show(Großbuchstaben.ToString());
            }
            
        }

        private void Radio_Großbuchstaben_Nein_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Großbuchstaben_Nein.IsChecked == true)
            {
                Radio_Großbuchstaben_Ja.IsChecked = false;
                Großbuchstaben = false;
                

            }
            else if (Radio_Großbuchstaben_Ja.IsChecked == true)
            {
               Radio_Großbuchstaben_Nein.IsChecked = false;
                Großbuchstaben = true;
                

            }
        }

        //------------------------Kleinbuchstaben----------------------------------------


        private void Radio_Kleinbuchstaben_Ja_Checked(object sender, RoutedEventArgs e)
        {

            if (Radio_Kleinbuchstaben_Ja.IsChecked == true)
            {
                Radio_Kleinbuchstaben_Nein.IsChecked = false;
                Kleinbuchstaben = true;
                
            }
            else if (Radio_Kleinbuchstaben_Nein.IsChecked == true)
            {
                Radio_Kleinbuchstaben_Ja.IsChecked = false;
                Kleinbuchstaben = false;
               
            }
        }


        private void Radio_Kleinbuchstaben_Nein_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Kleinbuchstaben_Nein.IsChecked == true)
            {
                Radio_Kleinbuchstaben_Ja.IsChecked = false;
                Kleinbuchstaben = false;


            }
            else if (Radio_Kleinbuchstaben_Ja.IsChecked == true)
            {
                Radio_Kleinbuchstaben_Nein.IsChecked = false;
                Kleinbuchstaben = true;


            }
        }

        //------------------------Ziffern----------------------------------------

        private void Radio_Ziffern_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Ziffern_Ja.IsChecked == true)
            {
                Radio_Ziffern_Nein.IsChecked = false;
                Ziffern = true;

            }
            else if (Radio_Ziffern_Nein.IsChecked == true)
            {
                Radio_Ziffern_Ja.IsChecked = false;
                Ziffern = false;

            }
        }

        private void Radio_Ziffern_Nein_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Ziffern_Nein.IsChecked == true)
            {
                Radio_Ziffern_Ja.IsChecked = false;
                Ziffern = false;


            }
            else if (Radio_Ziffern_Ja.IsChecked == true)
            {
                Radio_Ziffern_Nein.IsChecked = false;
                Ziffern = true;


            }
        }


        //------------------------Sonderzeichen---------------------------------------

        private void Radio_Sonderzeichen_Ja_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Sonderzeichen_Ja.IsChecked == true)
            {
                Radio_Sonderzeichen_Nein.IsChecked = false;
                Sonderzeichen = true;

            }
            else if (Radio_Sonderzeichen_Nein.IsChecked == true)
            {
                Radio_Sonderzeichen_Ja.IsChecked = false;
                Sonderzeichen = false;

            }
        }

        private void Radio_Sonderzeichen_Nein_Checked(object sender, RoutedEventArgs e)
        {
            if (Radio_Sonderzeichen_Nein.IsChecked == true)
            {
                Radio_Sonderzeichen_Ja.IsChecked = false;
                Sonderzeichen = false;


            }
            else if (Radio_Sonderzeichen_Ja.IsChecked == true)
            {
                Radio_Sonderzeichen_Nein.IsChecked = false;
                Sonderzeichen = true;


            }
        }





        //------------------------------------------Generieren--------------------------------------------------------

        private void Button_PW_generieren_Click(object sender, RoutedEventArgs e)
        {
            
           
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
                if (Länge_passwort <= 0)
                {
                    MessageBox.Show("Die Länge des Passworts muss positiv sein"); 
                }
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
                    MessageBox.Show("Sie müssen etwas auswählen");
                        
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
            




        }

        
//------------------------------------------------In zwischenablage Speichern-----------------------------


        private void Button_Speichern_Click(object sender, RoutedEventArgs e)
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

        #endregion

        #region TAB4

        //_______________________________________________Tab4__________________________________________________________

        private void Button_Acc_löschen_Click(object sender, RoutedEventArgs e)
        {
            string passwortentschlüsselt = AesOperation.DecryptString(key, aktiv.MasterPW);
            

            if (aktiv.ErstesMalAnmelden == false)
            {
                if (PasswordBox_Acc_löschen.Password == passwortentschlüsselt)
                {
                    if (PasswordBox_Acc_löschen_WH.Password == passwortentschlüsselt)
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


                            ListeRegUser.Remove(aktiv); 


                            //File löschen
                            File.Delete(path);

                            //File schreiben
                            string JsonSchreiben = JsonConvert.SerializeObject(ListeRegUser);
                            using (StreamWriter sw = new StreamWriter(path))
                            {
                                sw.WriteLine(JsonSchreiben);
                            }


                            AnmeldenEinblenden();
                            RegistrierenEinblenden();
                            TabItem_Anmelden_Reg.Visibility = Visibility.Visible;
                            TabControl1.SelectedItem = TabItem_Anmelden_Reg; 
                            TabItemsAusblenden(); 
                            


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


        #endregion


        #region Fenster Schließen
        private void Passwort_manager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Sicherheit.EncryptFile(path, path2);
            File.Delete(path);
        }

        #endregion


        


    }


}