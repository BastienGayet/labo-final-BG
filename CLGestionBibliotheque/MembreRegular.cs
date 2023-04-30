using System.ComponentModel;

namespace CLGestionBibliotheque;
[Serializable]
public class MembreRegular : Membre, INotifyPropertyChanged
{
   
    #region Variables et propriétes

    private int _nbreLivreMax;
    public int NbreLivreMax
    {
        get => _nbreLivreMax;
        set
        {
            _nbreLivreMax = value;
            OnPropertyChanged();
        }
    }
    #endregion

    #region Constrcuteur

    public MembreRegular(string nom, string adresse, int numeroMembre, DateTime dateInscription, int nbreLivreMax)
        : base(nom, adresse, numeroMembre, dateInscription)
    {
        this.NbreLivreMax=nbreLivreMax;
    }


    #endregion

    #region Methodes
    public override string ToString()
    {
        return base.ToString() + ", " + $"Nombre livre maximum : {NbreLivreMax}";
    }



    #endregion
}