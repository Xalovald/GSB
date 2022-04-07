using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Business
{
    public class LigneFraisHorsForfait
    {
        private int id;
        private DateTime date;
        private decimal montant;
        private string libelle;
        private FicheFrais _ficheFrais;

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
        public decimal Montant
        {
            get
            {
                return montant;
            }

            set
            {
                montant = value;
            }
        }

        public string Libelle
        {
            get
            {
                return libelle;
            }

            set
            {
                libelle = value;
            }
        }

        public FicheFrais FicheFrais
        {
            get
            {
                return _ficheFrais;
            }

            set
            {
                _ficheFrais = value;
            }
        }

        public LigneFraisHorsForfait(int unId, string unLibelle, DateTime uneDate, decimal unMontant, FicheFrais uneFicheFrais)
        {
            this.Id = unId;
            this.Libelle = unLibelle;
            this.Date = uneDate;
            this.Montant = unMontant;
            this._ficheFrais = uneFicheFrais;
        }
     
    }
}
