using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace CLGestionBibliotheque
{
    [Serializable]
    public class Loan : INotifyPropertyChanged
    {
        #region Variables Membres et Propriétés

        private Livres _borrowedLivres;
        public Livres BorrowedLivres
        {
            get => _borrowedLivres;
            set
            {
                _borrowedLivres = value;
                OnPropertyChanged();
            }
        }

        private Membre _borrowingMembre;
        public Membre BorrowingMembre
        {
            get => _borrowingMembre;
            set
            {
                _borrowingMembre = value;
                OnPropertyChanged();
            }
        }

        private DateTime _borrowDate;
        public DateTime BorrowDate
        {
            get => _borrowDate;
            set
            {
                _borrowDate = value;
                OnPropertyChanged();
            }
        }

        private DateTime _returnDate;
        public DateTime ReturnDate
        {
            get => _returnDate;
            set
            {
                _returnDate = value;
                OnPropertyChanged();
            }
        }

        private bool _isReturned;
        public bool IsReturned
        {
            get => _isReturned;
            set
            {
                _isReturned = value;
                OnPropertyChanged();
            }
        }




        #endregion

        #region Constructeur
        // const init
        public Loan(Livres borrowedLivres, Membre borrowingMembre, DateTime borrowDate)
        {
            this.BorrowedLivres = borrowedLivres;
            this.BorrowingMembre = borrowingMembre;
            this.BorrowDate = borrowDate;
            IsReturned = false;
        }

        #endregion

        #region Méthodes

        public void ReturnLivres(DateTime returnDate)
        {
            ReturnDate = returnDate;
            IsReturned = true;
        }

        public void Affiche()
        {
            Console.WriteLine(this);
        }
        public  override string ToString()
        {
            return "Emprunt : " + BorrowedLivres.Titre  + " emprunté par " + BorrowingMembre.Nom + " le " + BorrowDate.ToString("dd/MM/yyyy") + " et à rendre avant le " + ReturnDate.ToString("dd/MM/yyyy");
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

