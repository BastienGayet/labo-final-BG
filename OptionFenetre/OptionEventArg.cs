using System;
using System.Drawing;

namespace OptionFenetre
{
    public class OptionEventArg : EventArgs
    {
        #region Variable Membre

        public int Taille { get; set; }

        public Color Couleur { get; set; }

        #endregion

        #region Constructeur
        //const init
        public OptionEventArg(int taille, Color couleur)
        {
            Taille = taille;
            Couleur = couleur;
        }
        #endregion

    }

}