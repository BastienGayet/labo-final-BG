using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CLGestionBibliotheque;
[Serializable]
public  class Livres : INotifyPropertyChanged
{
    
    #region Variables Membre et priopriétés

    private string _titre;
    public string Titre
    {
        get => _titre;
        set
        {
            _titre = value;
            OnPropertyChanged();
        }
    }

    private string _editeur;
    public string Editeur
    {
        get => _editeur;
        set
        {
            _editeur = value;
            OnPropertyChanged();
        }
    }

    private int _annéePublication;
    public int AnnéePublication
    {
        get => _annéePublication;
        set
        {
            _annéePublication = value;
            OnPropertyChanged();
        }
    }

    private string _nomAuteurs;
    public string nomAuteurs
    {
        get => _nomAuteurs;
        set
        {
            _nomAuteurs = value;
            OnPropertyChanged();
        }
    }

    private double _prix;
    public double Prix
    {
        get => _prix;
        set
        {
            _prix = value;
            OnPropertyChanged();
        }
    }

    private long _isbn;
    public long ISBN
    {
        get => _isbn;
        set
        {
            _isbn = value;
            OnPropertyChanged();
        }
    }

    private bool _disponible;
    public bool Disponible
    {
        get => _disponible;
        set
        {
            _disponible = value;
            OnPropertyChanged();
        }
    }



    #endregion

    #region Constructeurs
    // const init
    public Livres(string titre, string nomAuteur,string editeur,int annéePublication,long isbn, double prix, bool disponible)
    {
        this.Titre = titre;
        this.AnnéePublication = annéePublication;
        this.nomAuteurs = nomAuteur;
        this.Prix = prix;
        this.ISBN = isbn;
        this.Disponible = disponible;
        this.Editeur = editeur;
    }

    public Livres()
    {
            
    }
    

    #endregion

    #region Méthodes

    public  void Affiche()
    {
        Console.WriteLine(this);
    }
    public override string ToString()
    {
        string disponibilite = this.Disponible ? "Disponible" : "Indisponible";

        return $" ISBN : {ISBN} Livre : {Titre}, écrit par {nomAuteurs}, publié en {AnnéePublication}, Disponibilité : {disponibilite}";
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