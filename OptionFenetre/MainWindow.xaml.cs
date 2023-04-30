using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Color = System.Drawing.Color;

namespace OptionFenetre
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void notify(object sender, OptionEventArg e);
        //je defini un delegué "notify" qui prend 2 param  OptionEventArg etant une classe perso qui contient des donneés pour l'evenement
        //
        public event notify ParamComplet;
        // je défini un evenement personnalisé il utilise le délégué . Il peut etre déclanché ou etre levé dans un methode 

        #region Explication
        /* La première commande public delegate void notify(object sender, OptionEventArgs e); définit un délégué nommé notify.
             Un délégué est un type de référence qui peut être utilisé pour encapsuler une méthode avec un ou plusieurs paramètres, 
             et qui peut être appelé de manière asynchrone.Dans ce cas, notify est un délégué qui prend deux paramètres :
         un objet sender et un objet OptionEventArgs(une classe personnalisée qui contient des données associées à l'événement).
         La méthode qui sera appelée lorsque l'événement sera déclenché devra correspondre à cette signature.

             La deuxième commande public event notify SettingCompleted; 
         définit un événement personnalisé nommé SettingCompleted.Cet événement utilise le délégué notify que nous avons défini précédemment.
             L'événement peut être levé (ou déclenché) dans une méthode en appelant simplement SettingCompleted(this, new OptionEventArgs()). 
         Cela appellera toutes les méthodes qui ont été enregistrées pour écouter cet événement. 
             Les méthodes qui sont enregistrées pour écouter l'événement doivent correspondre à la signature du délégué notify.

             En résumé, ces commandes sont utilisées pour définir et lever un événement personnalisé dans une classe C#.
         Les délégués sont utilisés pour définir la signature de la méthode qui sera appelée lorsque l'événement sera déclenché, 
         et l'événement peut être levé en appelant simplement son nom, ce qui appellera toutes les méthodes qui ont été enregistrées pour écouter cet événement.
         */

        #endregion

        public MainWindow()
        {
            InitializeComponent();

        }

        private void OnParamChanger(object sender, OptionEventArg e)
        {
            ParamComplet(sender, e);
        }
        private void ButOk_Click(object sender, RoutedEventArgs e)
        {
            if (SettingEvent())
            {
                Hide();
            }

        }

        private void ButAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ButAppliquer_Click(object sender, RoutedEventArgs e)
        {
            SettingEvent();

        }

        private bool SettingEvent()
        {

            if (ParamComplet != null)
            {
                OnParamChanger(this, new OptionEventArg(Convert.ToInt32(TBTailleFenetre.Text), Color.FromName(TBCouleur.Text)));
                return true;
            }
            else
            {
                return false;
            }



        }
    }
}
