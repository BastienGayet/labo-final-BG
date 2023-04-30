using CLGestionBibliotheque;
using CLSerializer;
using OptionFenetre;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace GestionBibliotheque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MyData myData = null;
        private OptionFenetre.MainWindow OptionsFenetres = new();
        public MainWindow()
        {
            InitializeComponent();
            OptionsFenetres.ParamComplet += OptionsFenetres_ParamComplet;

            if (File.Exists("Donner.bin"))
            {
                myData = Serializer.DeserializeJson("Donner.bin");
            }
            else
                myData = new MyData();

            DataContext = myData;
        }
        private void OptionsFenetres_ParamComplet(object sender, OptionEventArg e)
        {

            Background = new SolidColorBrush(System.Windows.Media.Color.FromArgb(e.Couleur.A, e.Couleur.R, e.Couleur.G, e.Couleur.B));
            FontSize = e.Taille;
        }
        private void BtnQui_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnPara_Click(object sender, RoutedEventArgs e)
        {
            OptionsFenetres.Show();
            OptionsFenetres.Focus();
            OptionsFenetres.Activate();

        }

        private void bSauvegarderLivre_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            Serializer.SerializeJson(myData, "Donner.bin");
            DataContext = myData;
        }
    }
}
