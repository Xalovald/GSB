using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GSBFraisModel.Business;
using GSBFraisModel.Data;
using WpfGSB.ViewModel;

namespace WpfGSB.ViewModel
{
    class ViewModelGestionFrais : ViewModelBase
    {
        private DaoFicheFrais _daoFicheFrais;
        private DaoLigneFraisHorsForfait _daoLigneFraisHorsForfait;
        private DaoEtat _daoEtat;
        private DaoLigneFraisForfait _daoLigneFraisForfait;

        private ObservableCollection<Etat> _etat;
        private ObservableCollection<FicheFrais> _listFicheFrais;
        private ObservableCollection<LigneFraisHorsForfait> _listFraisHorsForfait;
        private ObservableCollection<string> _listMois;

        private string _selectedMois;
        private int _fraisKm;
        private int _forfait;
        private int _nuitees;
        private int _repas;

        private LigneFraisHorsForfait _selectedligneFraisHorsForfait;
        private FicheFrais _selectedFicheFrais;
        private Etat _selectedEtat;

        private ICommand _updateCommand;
        private ICommand _deleteCommand;
        private ICommand _reporterCommand;
        public ObservableCollection<FicheFrais> ListFicheFrais
        {
            get
            {
                return _listFicheFrais;
            }

            set
            {
                this._listFicheFrais = value;
                OnPropertyChanged("ListFicheFrais");

            }
        }

        public ObservableCollection<string> ListMois
        {
            get
            {
                return _listMois;
            }

            set
            {
                _listMois = value;
            }
        }

        public string SelectedMois
        {
            get
            {
                return _selectedMois;
            }

            set
            {
                _selectedMois = value;
                this.ListFicheFrais = new ObservableCollection<FicheFrais>(_daoFicheFrais.SelectByMonth(_selectedMois));
            }
        }

        public FicheFrais SelectedFicheFrais
        {
            get
            {
                return this._selectedFicheFrais;
            }
            set
            {
                this._selectedFicheFrais = value;
                if (this._selectedFicheFrais != null)
                {

                    foreach (LigneFraisForfait lesLignesFraisForfait in this._selectedFicheFrais.LesLignesFraisForfait)
                    {
                        switch (lesLignesFraisForfait.FraisForfait.Id)
                        {
                            case "ETP":
                                Forfait = lesLignesFraisForfait.Quantite;
                                break;
                            case "KM":
                                FraisKm = lesLignesFraisForfait.Quantite;
                                break;
                            case "NUI":
                                Nuitees = lesLignesFraisForfait.Quantite;
                                break;
                            case "REP":
                                Repas = lesLignesFraisForfait.Quantite;
                                break;
                        }
                    }
                    ListFraisHorsForfait = new ObservableCollection<LigneFraisHorsForfait>(_selectedFicheFrais.LesLignesFraisHorsForfait);
                    SelectedEtat = ParcoursListEtat(_selectedFicheFrais.UnEtat);
                    OnPropertyChanged("SelectedFicheFrais");
                }
            }
        }
        public LigneFraisHorsForfait SelectedFraisHorsForfait
        {
            get
            {
                return _selectedligneFraisHorsForfait;
            }

            set
            {
                _selectedligneFraisHorsForfait = value;
                OnPropertyChanged("SelectedFraisHorsForfait");
            }
        }

        public int FraisKm
        {
            get
            {
                return _fraisKm;
            }

            set
            {
                _fraisKm = value;
                OnPropertyChanged("FraisKm");
            }
        }

        public int Forfait
        {
            get
            {
                return _forfait;
            }

            set
            {
                _forfait = value;
                OnPropertyChanged("Forfait");
            }
        }

        public int Nuitees
        {
            get
            {
                return _nuitees;
            }

            set
            {
                _nuitees = value;
                OnPropertyChanged("Nuitees");
            }
        }

        public int Repas
        {
            get
            {
                return _repas;
            }

            set
            {
                _repas = value;
                OnPropertyChanged("Repas");
            }
        }

        public ObservableCollection<Etat> Etat
        {
            get
            {
                return _etat;
            }

            set
            {
                _etat = value;

            }
        }
        public Etat SelectedEtat
        {
            get
            {
                return _selectedEtat;
            }

            set
            {
                _selectedEtat = value;
                OnPropertyChanged("SelectedEtat");
            }
        }

        public ObservableCollection<LigneFraisHorsForfait> ListFraisHorsForfait
        {
            get
            {
                return _listFraisHorsForfait;
            }

            set
            {
                this._listFraisHorsForfait = value;
                OnPropertyChanged("ListFraisHorsForfait");
            }
        }
        public Etat ParcoursListEtat(Etat unEtat)
        {
            Etat ChooseEtat = unEtat;
            foreach (Etat listEtat in _etat)
            {
                if (unEtat.Id == listEtat.Id)
                {
                    ChooseEtat = listEtat;
                }
            }
            return ChooseEtat;
        }

        public ICommand UpdateCommand
        {
            get
            {
                return _updateCommand = new RelayCommand(() => UpdateFicheFrais(), () => true);
            }
        }
        public ICommand DeleteCommande
        {
            get
            {
                return _deleteCommand = new RelayCommand(() => DeleteFicheFrais(), () => true);
            }
        }

        public ICommand ReporterCommand
        {
            get
            {
                return _reporterCommand = new RelayCommand(() => ReporterLigneFraisHorsForfait(), () => true); ;
            }
        }


        /// Delimitations avec les méthodes
        public ViewModelGestionFrais(DaoFicheFrais uneDaoFicheFrais, DaoEtat leDaoEtat, DaoLigneFraisHorsForfait uneDaoligneFraisHorsForfait, DaoLigneFraisForfait uneDaoLigneFraisForfait)
        {
            this._daoLigneFraisForfait = uneDaoLigneFraisForfait;
            this._daoFicheFrais = uneDaoFicheFrais;
            this._daoLigneFraisHorsForfait = uneDaoligneFraisHorsForfait;
            _listFicheFrais = new ObservableCollection<FicheFrais>(_daoFicheFrais.SelectAll());
            ListMois = new ObservableCollection<string>(_daoFicheFrais.SelectListMonth());
            Etat = new ObservableCollection<Etat>(leDaoEtat.SelectAll());

        }
        public void UpdateFicheFrais()
        {
            _selectedFicheFrais.UnEtat = SelectedEtat;
            _daoFicheFrais.Update(_selectedFicheFrais);

            foreach (LigneFraisForfait laLigneFraisForfait in SelectedFicheFrais.LesLignesFraisForfait)
            {
                switch (laLigneFraisForfait.FraisForfait.Id)
                {
                    case "ETP":
                        laLigneFraisForfait.Quantite = Forfait;
                        break;
                    case "KM":
                        laLigneFraisForfait.Quantite = FraisKm;
                        break;
                    case "NUI":
                        laLigneFraisForfait.Quantite = Nuitees;
                        break;
                    case "REP":
                        laLigneFraisForfait.Quantite = Repas;
                        break;
                }
                _daoLigneFraisForfait.Update(laLigneFraisForfait);
            }
            foreach (LigneFraisHorsForfait laLigneFraisHorsForfait in SelectedFicheFrais.LesLignesFraisHorsForfait)
            {
                _daoLigneFraisHorsForfait.Update(laLigneFraisHorsForfait);
            }
        }

        private void DeleteFicheFrais()
        {
            _daoLigneFraisHorsForfait.Delete(_selectedligneFraisHorsForfait);
            ListFraisHorsForfait.Remove(_selectedligneFraisHorsForfait);
        }
        private void ReporterLigneFraisHorsForfait()
        {
            
        }
    }
}
