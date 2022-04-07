using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Business
{
    public class Visiteurs
    {
        //Mes attributs
        private string _id;
        private string _nom;
        private string _login;
        private string _prenom;
        private string _mdp;
        private string _adress;
        private string _cp;
        private string _ville;
        private DateTime _dateEmbauche;

        public Visiteurs(string unId, string unNom, string unPrenom , string unLogin, string unMdp, string uneAdress, string unCp, string uneVille, DateTime uneDateEmbauche)
        {
            this._id = unId;
            this._nom = unNom;
            this._prenom = unPrenom;
            this._login = unLogin;
            this._mdp = unMdp;
            this._adress = uneAdress;
            this._cp = unCp;
            this._ville = uneVille;
            this._dateEmbauche = uneDateEmbauche;

        }
        //Propriétées
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

        public string Nom
        {
            get
            {
                return _nom;
            }

            set
            {
                _nom = value;
            }
        }

        public string Login
        {
            get
            {
                return _login;
            }

            set
            {
                _login = value;
            }
        }

        public string Prenom
        {
            get
            {
                return _prenom;
            }

            set
            {
                _prenom = value;
            }
        }

        public string Mdp
        {
            get
            {
                return _mdp;
            }

            set
            {
                _mdp = value;
            }
        }

        public string Adress
        {
            get
            {
                return _adress;
            }

            set
            {
                _adress = value;
            }
        }

        public string Cp
        {
            get
            {
                return _cp;
            }

            set
            {
                _cp = value;
            }
        }

        public string Ville
        {
            get
            {
                return _ville;
            }

            set
            {
                _ville = value;
            }
        }

        public DateTime DateEmbauche
        {
            get
            {
                return _dateEmbauche;
            }

            set
            {
                _dateEmbauche = value;
            }
        }
    }
}
