using System.Collections.ObjectModel;
using System.ComponentModel;
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
        LivresFiction.Add(new LivresFiction("Seigneurs des Anneaux","Gayet","Petit Navire",1996,12345678,12.25,false,"SF"));

        CurrentLivresFiction = LivresFiction.ElementAt(0);
    }
}