using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Business
{
    public class LigneFraisForfait
    {
        private decimal quantite;
        private FicheFrais _ficheFrais;
        private FraisForfait _fraisForfait;

        public LigneFraisForfait(decimal uneQuantite, FicheFrais uneFicheFrais, FraisForfait unFraisForfait)
        {
            this.quantite = uneQuantite;
            this._ficheFrais = uneFicheFrais;
            this.FraisForfait = unFraisForfait;
        }

        public decimal Quantite
        {
            get
            {
                return quantite;
            }

            set
            {
                quantite = value;
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

        public FraisForfait FraisForfait
        {
            get
            {
                return _fraisForfait;
            }

            set
            {
                _fraisForfait = value;
            }
        }
    }
}
