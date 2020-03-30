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

namespace Affichage_LED
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string MessageAEnvoyer = "<ID00><L1><PA><FE><MA><WC><FE>";
        string my_com;
        string couleur;
        string test = "coucou!";
        public MainWindow()
        {
            InitializeComponent();         
           
        }

        private string checksum(string s)
        {
            int xor1, xor2;
            int valeur1 = Convert.ToInt32((s[6]));
            int valeur2 = Convert.ToInt32((s[7]));
            xor1 = valeur1 ^ valeur2;
            for (int i = 8; i < s.Length; i++)
            {
                xor2 = Convert.ToInt32((s[i]));
                xor1 = xor1 ^ xor2;
            }

            string res=Convert.ToString(xor1,16);

            return res;
        }

        private void Button_SetCOM_Click(object sender, RoutedEventArgs e)
        {
            WindowChoixDuPort fenetre = new WindowChoixDuPort();
            fenetre.Owner = this;
            fenetre.Show();
            my_com = fenetre.get_my_com().Substring(38);
        }

       
        private void Button_SendMessage_Click(object sender, RoutedEventArgs e)
        {
            // My_Textbox.Selection(0);
           // My_Textbox.AppendText(MessageAEnvoyer + test);
            //My_Textbox.AppendText(couleur);
            //My_Textbox.AppendText(checksum(MessageAEnvoyer + test).ToUpperInvariant());
            //My_Textbox.AppendText("<E>");
            // TextRange textRange2 = new TextRange(My_Textbox.Document.ContentStart, My_Textbox.Document.ContentEnd);
            // MessageAEnvoyer = textRange2.Text;
             string test2 = MessageAEnvoyer + couleur + test + checksum(MessageAEnvoyer +couleur + test).ToUpperInvariant() + "<E>";
            My_Textbox.AppendText(test2);
            envoyer_message(test2,my_com);

        }

        private void envoyer_message(string s, string com)
        {
            System.IO.Ports.SerialPort sport = new System.IO.Ports.SerialPort("COM2", 9600, System.IO.Ports.Parity.None, 8, System.IO.Ports.StopBits.One);

            try
            {
                sport.Open();
                sport.Write(s);
                MessageBox.Show("Message envoyé.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            
            //sport.Close;
        }
        private void Button_Rouge_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Rouge>");
            couleur = "<CB>";
        }
        private void Button_Vert_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Vert>");
            couleur = "<CE>";
        }

        private void Button_Orange_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Orange>");
            couleur = "<CH>";
        }        

        private void Button_Rouge_inverse_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Rouge Inversé>");
            couleur = "<CL>";
        }

        private void Button_Vert_inverse_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Vert Inversé>");
            couleur = "<CM>";
        }

        private void Button_Orange_inverse_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Orange Inversé>");
            couleur = "<CN>";
        }

        private void Button_Rouge_dans_vert_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Rouge Dans Vert>");
            couleur = "<CP>";
        }

        private void Button_Vert_dans_Rouge_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Vert dans Rouge>");
            couleur = "<CQ>";
        }

        private void Button_RYG_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<RYG>");
            couleur = "<CR>";
        }

        private void Button_Arc_en_ciel_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Arc-en-ciel>");
            couleur = "<CS>";
        }

        private void Button_Date_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Date>");

        }

        private void Button_Heure_Click(object sender, RoutedEventArgs e)
        {
            My_Textbox.AppendText("<Heure>");
        }

        private void Button_Ouvrir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
