using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace CLGestionBibliotheque;
[Serializable]
public class MyData : INotifyPropertyChanged
{

    #region Variables Membres et propriétés

    public ObservableCollection<LivresFiction> LivresFiction { get; set; }
    public ObservableCollection<LivresNonFiction> LivresNonFictions { get; set; }
    public ObservableCollection<MembrePremium> MembrePremiums { get; set; }
    public ObservableCollection<MembreRegular> MembreRegulars { get; set; }
    public ObservableCollection<Loan> Emprunts { get; set; }
    public ObservableCollection<Auteurs> Auteurs { get; set; }

    private LivresFiction _currentLivresFiction;
    public LivresFiction CurrentLivresFiction
    {
        get => _currentLivresFiction;
        set
        {
            _currentLivresFiction = value;
            OnPropertyChanged();
        }
    }

    private LivresNonFiction _currentLivresNonFiction;
    public LivresNonFiction CurrentLivresNonFiction
    {
        get => _currentLivresNonFiction;
        set
        {
            _currentLivresNonFiction = value;
            OnPropertyChanged();
        }
    }

    private MembrePremium _currentMembrePremium;
    public MembrePremium CurrentMembrePremium
    {
        get => _currentMembrePremium;
        set
        {
            _currentMembrePremium = value;
            OnPropertyChanged();
        }
    }

    private MembreRegular _currentMembreRegular;
    public MembreRegular CurrentMembreRegular
    {
        get => _currentMembreRegular;
        set
        {
            _currentMembreRegular = value;
            OnPropertyChanged();
        }
    }

    private Loan _currentEmprunt;
    public Loan CurrentEmprunt
    {
        get => _currentEmprunt;
        set
        {
            _currentEmprunt = value;
            OnPropertyChanged();
        }
    }

    private Auteurs _currentAuteur;
    public Auteurs CurrentAuteur
    {
        get => _currentAuteur;
        set
        {
            _currentAuteur = value;
            OnPropertyChanged();
        }
    }


    #endregion


    #region INotifyPropertyChanged

    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    #endregion

    public MyData()
    {
        LivresFiction = new ObservableCollection<LivresFiction>();
        LivresFiction.Add(new LivresFiction("Seigneurs des Anneaux","Gayet","Petit Navire",1996,12345678,12.25,true,"SF"));
        LivresFiction.Add(new LivresFiction("Harry Potter à l'école des sorciers", "J.K. Rowling", "Bloomsbury", 1997, 987654321, 10.99, true, "Fantasy"));
        LivresFiction.Add(new LivresFiction("Dune", "Frank Herbert", "Chilton Books", 1965, 23456789, 14.99, true, "SF"));
        LivresFiction.Add(new LivresFiction("1984", "George Orwell", "Secker & Warburg", 1949, 34567890, 9.99, false, "Dystopie"));
        LivresFiction.Add(new LivresFiction("Le Guide du voyageur galactique", "Douglas Adams", "Pan Books", 1979, 45678901, 11.99, false, "SF"));

        Auteurs = new ObservableCollection<Auteurs>();
        Auteurs.Add(new Auteurs("J.K.", "Rowling", new DateTime(1965, 7, 31), "Britannique"));
        Auteurs.Add(new Auteurs("George", "Orwell", new DateTime(1903, 6, 25), "Britannique"));
        Auteurs.Add(new Auteurs("Frank", "Herbert", new DateTime(1920, 10, 8), "Américain"));
        Auteurs.Add(new Auteurs("Douglas", "Adams", new DateTime(1952, 3, 11), "Britannique"));
        Auteurs.Add(new Auteurs("J.R.R.", "Tolkien", new DateTime(1892, 1, 3), "Britannique"));

        MembreRegulars = new ObservableCollection<MembreRegular>();
        MembreRegulars.Add(new MembreRegular("Gayet", "Rue de la Chapelle 11 4347 Fexhe le Haut Clocher", 57897, new DateTime(2022, 5, 7), 3));
        MembreRegulars.Add(new MembreRegular("Durant", "Rue du Lac 2 4000 Liège", 89057, new DateTime(2023, 6, 15), 2));
        MembreRegulars.Add(new MembreRegular("Dupont", "Avenue des Fleurs 12 1000 Bruxelles", 34521, new DateTime(2022, 9, 30), 1));
        MembreRegulars.Add(new MembreRegular("Leblanc", "Place du Marché 7 5000 Namur", 23456, new DateTime(2023, 12, 31), 4));
        MembreRegulars.Add(new MembreRegular("Martin", "Rue de la Gare 3 7000 Mons", 45678, new DateTime(2022, 10, 15), 1));

        Emprunts = new ObservableCollection<Loan>();
        Emprunts.Add(new Loan(LivresFiction[0], MembreRegulars[0], new DateTime(2023, 5, 6)));
        Emprunts.Add(new Loan(LivresFiction[1], MembreRegulars[1], new DateTime(2023, 5, 6)));
        Emprunts.Add(new Loan(LivresFiction[2], MembreRegulars[2], new DateTime(2023, 5, 6)));
        Emprunts.Add(new Loan(LivresFiction[3], MembreRegulars[3], new DateTime(2023, 5, 6)));
        Emprunts.Add(new Loan(LivresFiction[4], MembreRegulars[4], new DateTime(2023, 5, 6)));

    }

    public void AjouterLivreFiction(LivresFiction LivreF)
    {
        LivresFiction.Add(LivreF);
    }

    public void SupprimerLivreFiction(LivresFiction livreF)
    {
        LivresFiction.Remove(livreF);
    }
    public void AjouterAuteur(Auteurs auteurs)
    {
        Auteurs.Add(auteurs);
    }

    public void SupprimerAuteur(Auteurs auteurs)
    {
        Auteurs.Remove(auteurs);
    }

    public void AjouterMembre(MembreRegular membre)
    {
        MembreRegulars.Add(membre);
    }

    public void SupprimerMembre(MembreRegular membre)
    {
        MembreRegulars.Remove(membre);
    }

    public void AjouterPret(Loan emprunt)
    {
        Emprunts.Add(emprunt);
    }

    public void Supprimer(Loan emprunt)
    {
        Emprunts.Remove(emprunt);
    }
}