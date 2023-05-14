using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CLGestionBibliotheque;
[Serializable]
public class LivresFiction : Livres //,  INotifyPropertyChanged
{
    
    #region Variables Membre et propriétés

    private string _genre;

    public string Genre
    {
        get => _genre;
        set
        {
            _genre = value;
            OnPropertyChanged();
        }
    }

    #endregion

        #region Constructeur

        // init
    public LivresFiction(string titre, string nomAuteurs, string editeur, int annéePublication, long isbn,
        double prix, bool disponible, string genre)
        : base(titre,nomAuteurs, editeur, annéePublication, isbn, prix, disponible)
    {
        Genre = genre;
    }

    public LivresFiction() : base()
    {
        Genre = "";
    }

    #endregion

    #region Méthode

    public override string ToString()
    {
        return base.ToString() +" , " +   $"Genre : {Genre}";
    }

    #endregion

    
}