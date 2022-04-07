using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Business
{
    public class Etat
    {
        private string _id;
        private string _libelle;

        public Etat(string unId,string unLibelle)
        {
            this._id = unId;
            this._libelle = unLibelle;
        }

        public string Id
        {
            get
            {
                return _id;
            }

            set
            {
                _id = value;
            }
        }

        public string Libelle
        {
            get
            {
                return _libelle;
            }

            set
            {
                _libelle = value;
            }
        }
        public override string ToString()
        {
            return Libelle;
        }
    }
}
