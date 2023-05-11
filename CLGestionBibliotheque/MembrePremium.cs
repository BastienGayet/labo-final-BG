using System.ComponentModel;

namespace CLGestionBibliotheque;
[Serializable]
public class MembrePremium : Membre , INotifyPropertyChanged
{
    
    #region Variables Membres et Propriétés

    private double _prixabo;
    public double PrixAbo
    {
        get => _prixabo;
        set
        {
            _prixabo = value;
            OnPropertyChanged();
        }
    }

    #endregion

    #region Constructeur


    // Si la classe Membre a un constructeur avec des paramètres, vous pouvez également les inclure, par exemple :
    public MembrePremium(string nom, string adresse, int numeroMembre, DateTime dateInscription, double prixabo) : base(nom, adresse, numeroMembre, dateInscription)
    {
        PrixAbo = prixabo;
    }

    public MembrePremium() : base()
    {
        PrixAbo = 0;
    }



    #endregion

    #region Méthode

    public override string ToString()
    {
        return base.ToString() + ", " + $"Prix abonnement : {PrixAbo}";
    }

    #endregion
}