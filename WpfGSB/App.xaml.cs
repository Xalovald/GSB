using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using GSBFraisModel.Data;
using System.Globalization;
using System.Threading;

namespace WpfGSB
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {
        private Dbal thedbal;
        private DaoEtat theDaoEtat;
        private DaoVisiteurs theDaoVisiteur;
        private DaoFraisForfait theDaoFraisForfait;
        private DaoFicheFrais theDaoFichefrais;
        private DaoLigneFraisForfait theDaoLigneFraisForfait;
        private DaoLigneFraisHorsForfait theDaoLigneFraisHorsForfait;
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
            thedbal = new Dbal("gsb_gestfrais");
            theDaoEtat = new DaoEtat(thedbal);
            theDaoVisiteur = new DaoVisiteurs(thedbal);
            theDaoFraisForfait = new DaoFraisForfait(thedbal);
            theDaoLigneFraisForfait = new DaoLigneFraisForfait(thedbal, theDaoFraisForfait);
            theDaoLigneFraisHorsForfait = new DaoLigneFraisHorsForfait(thedbal, theDaoFraisForfait);
            theDaoFichefrais = new DaoFicheFrais(thedbal, theDaoVisiteur, theDaoEtat, theDaoLigneFraisForfait, theDaoLigneFraisHorsForfait);

            // Create the startup window
            WpfVeriFrais wnd = new WpfVeriFrais(theDaoFichefrais, theDaoEtat, theDaoLigneFraisHorsForfait, theDaoLigneFraisForfait);
            //MainWindow wnd = new MainWindow(thedaopays, thedaofromage);
            wnd.Show();

        }
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show("An unhandled exception just occurred: " + e.Exception.Message, "Exception Sample", MessageBoxButton.OK, MessageBoxImage.Warning);
            e.Handled = true;
        }
    }
    


}
