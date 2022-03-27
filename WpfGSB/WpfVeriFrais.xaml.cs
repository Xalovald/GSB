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
using GSBFraisModel.Data;

namespace WpfGSB
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class WpfVeriFrais : Window
    {
        public WpfVeriFrais(DaoFicheFrais uneDaoFicheFrais)
        {
            InitializeComponent();
            mainGrid.DataContext = new ViewModel.ViewModelGestionFrais(uneDaoFicheFrais);
        }
    }
}
