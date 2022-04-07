using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Business
{
    public class LigneFraisForfait
    {
        private int _quantite;
        private FicheFrais _ficheFrais;
        private FraisForfait _fraisForfait;

        public LigneFraisForfait(int uneQuantite, FicheFrais uneFicheFrais, FraisForfait unFraisForfait)
        {
            this._quantite = uneQuantite;
            this._ficheFrais = uneFicheFrais;
            this.FraisForfait = unFraisForfait;
        }

        public int Quantite
        {
            get
            {
                return _quantite;
            }

            set
            {
                _quantite = value;
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
