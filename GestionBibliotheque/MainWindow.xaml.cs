using CLGestionBibliotheque;
using CLSerializer;
using OptionFenetre;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Media.Converters;
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
      /*  public ObservableCollection<Auteurs> Auteurs { get; set; }
        public ObservableCollection<LivresFiction> LivresFiction { get; set; }
        
        public ObservableCollection<MembreRegular> MembreRegulars { get; set; }
        public ObservableCollection<Loan> Emprunts { get; set; }*/
     

        public MainWindow()
        {
            InitializeComponent();
            OptionsFenetres.ParamComplet += OptionsFenetres_ParamComplet;

            if (File.Exists("data.json"))
            {
                myData = Serializer.DeserializeJson("data.json");
            }
            else
                myData = new MyData();

            DataContext = myData;
            

            this.Left = MyRegistryParamManager.PositionX;
            this.Top = MyRegistryParamManager.PositionY;

            /*  Auteurs = new ObservableCollection<Auteurs>();
              Auteurs.Add(new Auteurs("J.K.", "Rowling", new DateTime(1965, 7, 31), "Britannique"));
              Auteurs.Add(new Auteurs("George", "Orwell", new DateTime(1903, 6, 25), "Britannique"));
              Auteurs.Add(new Auteurs("Frank", "Herbert", new DateTime(1920, 10, 8), "Américain"));
              Auteurs.Add(new Auteurs("Douglas", "Adams", new DateTime(1952, 3, 11), "Britannique"));
              Auteurs.Add(new Auteurs("J.R.R.", "Tolkien", new DateTime(1892, 1, 3), "Britannique"));

              LivresFiction = new ObservableCollection<LivresFiction>();
              LivresFiction.Add(new LivresFiction("Seigneurs des Anneaux", "Gayet", "Petit Navire", 1996, 12345678, 12.25, true, "SF"));
              LivresFiction.Add(new LivresFiction("Harry Potter à l'école des sorciers", "J.K. Rowling", "Bloomsbury", 1997, 987654321, 10.99, true, "Fantasy"));
              LivresFiction.Add(new LivresFiction("Dune", "Frank Herbert", "Chilton Books", 1965, 23456789, 14.99, true, "SF"));
              LivresFiction.Add(new LivresFiction("1984", "George Orwell", "Secker & Warburg", 1949, 34567890, 9.99, false, "Dystopie"));
              LivresFiction.Add(new LivresFiction("Le Guide du voyageur galactique", "Douglas Adams", "Pan Books", 1979, 45678901, 11.99, false, "SF"));
              DataContext = this;*/


        }

        private void OptionsFenetres_ParamComplet(object sender, OptionEventArg e)
        {

            Background =
                new SolidColorBrush(
                    System.Windows.Media.Color.FromArgb(e.Couleur.A, e.Couleur.R, e.Couleur.G, e.Couleur.B));
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
            Serializer.SerializeJson(myData, "data.json");
            DataContext = myData;
        }
        private void BSauvegarderAuteur_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            Serializer.SerializeJson(myData, "data.json");
            DataContext = myData;
        }

        private void bSauvegarderMembre_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            Serializer.SerializeJson(myData, "data.json");
            DataContext = myData;
        }

        private void bSauvegarderPret_Click(object sender, RoutedEventArgs e)
        {
            DataContext = null;
            Serializer.SerializeJson(myData, "data.json");
            DataContext = myData;
        }


        private void BnAjoutAuteur_Click(object sender, RoutedEventArgs e)
        {

            string Nom = NomTB.Text;
            string Prenom = PrenomTB.Text;
            string Nationalite = NationaliteTB.Text;
            DateTime DateNaissance = DateNaissanceDP.SelectedDate.Value;
            

             myData.Auteurs.Add(new Auteurs(Nom,Prenom,DateNaissance,Nationalite));

            

            NomTB.Text = "";
            PrenomTB.Text = "";
            NationaliteTB.Text = "";
            DateNaissanceDP.SelectedDate = null;

        }
        private void BNSupprimerAuteur_Click(object sender, RoutedEventArgs e)
        {
            if (myData.CurrentAuteur != null)
            {
                myData.Auteurs.Remove(myData.CurrentAuteur);
            }

        }


     

        private void BNAjouterLivre_Click(object sender, RoutedEventArgs e)
        {
            string titre = TITRETB.Text;
            string editeur = EditeurTB.Text;
            int annéePublic = Int32.Parse(AnneePubliTB.Text);
            string nomAuteur = NOMAUTEURTB.Text;
            double prix = Double.Parse(PRIXTB.Text);
            long isbn = Int64.Parse(ISBNTB.Text);
            bool disponible = DispoTB.IsChecked ?? false;
            string genre = GenreTB.Text;

            myData.LivresFiction.Add(new LivresFiction(titre,nomAuteur,editeur,annéePublic,isbn,prix,disponible,genre));

            TITRETB.Text = "";
            EditeurTB.Text = "";
            AnneePubliTB.Text = "";
            NOMAUTEURTB.Text = "";
            PRIXTB.Text = "";
            ISBNTB.Text = "";
            DispoTB.IsChecked = false;
            GenreTB.Text = "";

        }
        private void BNSupprimerLivre_Click(object sender, RoutedEventArgs e)
        {
            if (myData.CurrentLivresFiction != null)
            {
                myData.LivresFiction.Remove(myData.CurrentLivresFiction);
            }

        }

        private void BNAjouterPret_Click(object sender, RoutedEventArgs e)
        {
           /* string titreLivre = myData.CurrentLivresFiction.Titre;

            LivresFiction livreEmprunter = myData.LivresFiction.FirstOrDefault(l => l.Titre == titreLivre);

            int numMembre = myData.CurrentMembreRegular.NumeroMembre;

            MembreRegular NumMembre = myData.MembreRegulars.FirstOrDefault(n => n.NumeroMembre == numMembre);


            if (livreEmprunter != null && numMembre != null)
            {
                myData.Emprunts.Add(new Loan(livreEmprunter, NumMembre, DateTime.Now));
                livreEmprunter.Disponible = false;
                NumMembre.NbreLivreMax++;
            }*/
             if (myData.CurrentLivresFiction != null || myData.CurrentMembreRegular != null)
             {
                 

                 if (myData.CurrentMembreRegular.NbreLivreMax >= 5)
                 {
                     MessageBox.Show("Le membre a atteint son nombre maximum de prêts autorisés.");
                     return;
                 }


                 myData.Emprunts.Add(new Loan(myData.CurrentLivresFiction ,myData.CurrentMembreRegular,DateTime.Now));
                 myData.CurrentLivresFiction.Disponible = false;
                 myData.CurrentMembreRegular.NbreLivreMax++;

             }
             

        }

        private void BNSupprimerPret_Click(object sender, RoutedEventArgs e)
        {
            if (myData.CurrentEmprunt != null)
            { // JE DOIS STOCKER LE NUM D emprunt 
                myData.Emprunts.Remove(myData.CurrentEmprunt);
                myData.CurrentMembreRegular.NbreLivreMax--;
            }

        }

        private void BNAjouterMembre_Click(object sender, RoutedEventArgs e)
        {
            string nom = NomMembreTB.Text;
            string adresse = AdresseTB.Text;
            int numeroMembre= Int32.Parse(NumTB.Text);
            DateTime dateInscription = DateINSTB.SelectedDate.Value;
            int NbreLivreMax = Int32.Parse(NbreLivreTB.Text);

            myData.MembreRegulars.Add(new MembreRegular(nom,adresse,numeroMembre,dateInscription,NbreLivreMax));

            NomMembreTB.Text = "";
            AdresseTB.Text = "";
            NumTB.Text = "";
            DateINSTB.SelectedDate = null;
            NbreLivreTB.Text = "";

        }

        private void BNSupprimerMembre_Click(object sender, RoutedEventArgs e)
        {
            if (myData.MembreRegulars != null)
            {
                myData.MembreRegulars.Remove(myData.CurrentMembreRegular);
            }
        }

        private void clo_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MyRegistryParamManager.PositionX = (int)this.Left;
            MyRegistryParamManager.PositionY = (int)this.Top;
        }
    }
}
