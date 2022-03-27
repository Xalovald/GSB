using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GSBFraisModel.Business;
using GSBFraisModel.Data;

namespace WpfGSB.ViewModel
{
    class ViewModelGestionFrais : ViewModelBase
    {
        private DaoFicheFrais _daoFicheFrais;
        private ObservableCollection<FicheFrais> listFicheFrais;
        private ObservableCollection<string> listMois;
        private string selectedMois;
        private FicheFrais selectedFicheFrais;
        public ObservableCollection<FicheFrais> ListFicheFrais
        {
            get
            {
                return listFicheFrais;
            }

            set
            {
                listFicheFrais = value;
            }
        }

        public ObservableCollection<string> ListMois
        {
            get
            {
                return listMois;
            }

            set
            {
                listMois = value;
            }
        }

        public string SelectedMois
        {
            get
            {
                return selectedMois;
            }

            set
            {
                selectedMois = value;
                listFicheFrais = new ObservableCollection<FicheFrais>(_daoFicheFrais.SelectByMonth(selectedMois));
                OnPropertyChanged("ListFicheFrais");
            }
        }

        public FicheFrais SelectedFicheFrais
        {
            get
            {
                return selectedFicheFrais;
            }
            set
            {
                selectedFicheFrais = value;
            }
        }

        public ViewModelGestionFrais(DaoFicheFrais uneDaoFicheFrais)
        {
            this._daoFicheFrais = uneDaoFicheFrais;
            listFicheFrais = new ObservableCollection<FicheFrais>(_daoFicheFrais.SelectAll());
            ListMois = new ObservableCollection<string>(_daoFicheFrais.SelectListMonth());
        }
        /// Delimitations avec les méthodes
    }
}
