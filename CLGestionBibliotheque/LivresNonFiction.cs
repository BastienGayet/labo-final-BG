using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CLGestionBibliotheque;
[Serializable]
public class LivresNonFiction : Livres , INotifyPropertyChanged
{
    
    #region Variables Membres et Propriétés

    private string _domaine;
    public string Domaine
    {
        get => _domaine;
        set
        {
            _domaine = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Constructeur

    public LivresNonFiction(string titre, string nomAuteur, string editeur, int annéePublication, long isbn, 
        double prix, bool disponible, string domaine)
        : base(titre, nomAuteur, editeur, annéePublication, isbn, prix, disponible)
    {
        Domaine = domaine;
    }
    #endregion

    public LivresNonFiction() : base()
    {
        Domaine = "";
    }


    #region Methodes

    public override string ToString()
    {
        return base.ToString() + " ," + $"Domaine : {Domaine}";
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