using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CLGestionBibliotheque
{
    [Serializable]
    public class Auteurs : INotifyPropertyChanged
    {
        #region Variables Membres et prorpiétés
        private string _nom;
        public string Nom
        {
            get => _nom;
            set
            {
                _nom = value;
                OnPropertyChanged();
            }
        }

        private string _prenom;
        public string Prenom
        {
            get => _prenom;
            set
            {
                _prenom = value;
                OnPropertyChanged();
            }
        }

        private string _nationalite;
        public string Nationalite
        {
            get => _nationalite;
            set
            {
                _nationalite = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateNaissance;
        public DateTime DateNaissance
        {
            get => _dateNaissance;
            set
            {
                _dateNaissance = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constrcuteur
        // const init
        public Auteurs(string nom, string prenom, DateTime dateNaissance, string nationalite)
        {
            this.Nom = nom;
            this.Prenom = prenom;
            this.Nationalite =nationalite;
            this.DateNaissance = dateNaissance;
        }

        public Auteurs()
        {
        }

        #endregion

        #region Méthodes

        public void Affiche()
        {
            Console.WriteLine(this);
        }
        public override string ToString()
        {
            string date = DateNaissance.ToString("M/d/yy");
            return $"Auteur : {Nom} {Prenom}, né(e) en {date}, de Nationnalité {Nationalite}";
        }

        #endregion


        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        #endregion


    }
}