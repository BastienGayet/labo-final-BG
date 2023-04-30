using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CLGestionBibliotheque
{
    [Serializable]
    public class Membre : INotifyPropertyChanged
    {
        #region Variables Membres et Propriétés

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

        private string _adresse;
        public string Adresse
        {
            get => _adresse;
            set
            {
                _adresse = value;
                OnPropertyChanged();
            }
        }

        private int _numeroMembre;
        public int NumeroMembre
        {
            get => _numeroMembre;
            set
            {
                _numeroMembre = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateInscription;
        public DateTime DateInscription
        {
            get => _dateInscription;
            set
            {
                _dateInscription = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructeur
        //const init
        public Membre(string nom, string adresse, int numeroMembre, DateTime dateInscription)
        {
            this.Nom = nom;
            this.Adresse = adresse;
            this.NumeroMembre = numeroMembre;
            this.DateInscription = dateInscription;
        }


        #endregion

        #region Méthodes

        public void Affiche()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            return $"Membre : {Nom} (n°{NumeroMembre}), inscrit le {DateInscription}";
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
