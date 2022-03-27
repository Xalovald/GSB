using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Business
{
    public class FicheFrais
    {
        private Visiteurs _visiteurs;
        private string _mois;
        private Etat _etat;
        private decimal _montantValide;
        private int _nbjustificatif;
        private DateTime _dateModif;
        private List<LigneFraisForfait> LesLignesFraisForfait;
        private List<LigneFraisHorsForfait> lesLignesFraisHorsForfait; 

        
        public FicheFrais(string unMois, int unNbJustificatifs, decimal unMontantValide, DateTime uneDateModif, Visiteurs unVisiteur, Etat unEtat)
        {
            this._visiteurs = unVisiteur;
            this._mois = unMois;
            this._etat = unEtat;
            this._nbjustificatif = unNbJustificatifs;
            this._montantValide = unMontantValide;
            this._dateModif = uneDateModif;

        }

        public string Mois
        {
            get
            {
                return _mois;
            }

            set
            {
                _mois = value;
            }
        }

        public Visiteurs UnVisiteur
        {
            get
            {
                return _visiteurs;
            }

            set
            {
                _visiteurs = value;
            }
        }

        public Etat UnEtat
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

        public decimal MontantValide
        {
            get
            {
                return _montantValide;
            }

            set
            {
                _montantValide = value;
            }
        }

        public int Nbjustificatif
        {
            get
            {
                return _nbjustificatif;
            }

            set
            {
                _nbjustificatif = value;
            }
        }

        public DateTime DateModif
        {
            get
            {
                return _dateModif;
            }

            set
            {
                _dateModif = value;
            }
        }

        public List<LigneFraisForfait> LesLignesFraisForfait1
        {
            get
            {
                return LesLignesFraisForfait;
            }

            set
            {
                LesLignesFraisForfait = value;
            }
        }

        public List<LigneFraisHorsForfait> LesLignesFraisHorsForfait
        {
            get
            {
                return lesLignesFraisHorsForfait;
            }

            set
            {
                lesLignesFraisHorsForfait = value;
            }
        }

        public override string ToString()
        {
            return "Fiche frais" + Mois + "-" + UnVisiteur.Id + "-" + "-" + UnVisiteur.Nom;
        }
    }
}
