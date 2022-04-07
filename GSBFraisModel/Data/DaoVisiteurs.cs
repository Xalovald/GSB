using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBFraisModel.Business;
using System.Data;

namespace GSBFraisModel.Data
{
    public class DaoVisiteurs
    {
        private Dbal _dbal;
        
        public DaoVisiteurs(Dbal unDbal)
        {
            this._dbal = unDbal;
        }

        public void Insert(Visiteurs leVisiteur)
        {
            string query = "visiteur (id, nom, prenom, login) VALUES ('" + leVisiteur.Id + "', '" + leVisiteur.Nom.Replace("'","''") + "', '" + leVisiteur.Prenom.Replace("'","''") + "', '" + leVisiteur.Login + "')";
            this._dbal.Insert(query);
        }
        public void Delete(Visiteurs leVisiteur)
        {
            string query = "visiteur where id = " + leVisiteur.Id;
            this._dbal.Delete(query);
        }
        public void Update(Visiteurs leVisiteur)
        {
            string query = "visiteur SET " + "nom = '" + leVisiteur.Nom.Replace("'","''") + "' , prenom = '" + leVisiteur.Prenom.Replace("'","''") + "' , login = '" + leVisiteur.Login + "' where id = " + leVisiteur.Id;
            this._dbal.Update(query);
        }
        public List<Visiteurs> SelectAll()
        {
            List<Visiteurs> listeVisiteurs = new List<Visiteurs>();
            DataTable maTable = this._dbal.SelectAll("visiteur");
            foreach(DataRow r in maTable.Rows)
            {
                listeVisiteurs.Add(new Visiteurs((string)r["id"], (string)r["nom"], (string)r["prenom"], (string)r["login"], (string)r["mdp"], (string)r["adresse"], (string)r["cp"], (string)r["ville"], (DateTime)r["dateEmvbauche"]));
            }
            return listeVisiteurs;
        }
        public Visiteurs SelectByName(string nomVisiteur)
        {
            DataTable resultat = new DataTable();
            resultat = this._dbal.SelectByField("visiteur", "nom = '" + nomVisiteur.Replace("'", "''") + "'");
            Visiteurs trouverVisiteur = new Visiteurs((string)resultat.Rows[0]["id"], (string)resultat.Rows[0]["nom"], (string)resultat.Rows[0]["prenom"], (string)resultat.Rows[0]["login"], (string)resultat.Rows[0]["mdp"], (string)resultat.Rows[0]["adresse"], (string)resultat.Rows[0]["cp"], (string)resultat.Rows[0]["ville"], (DateTime)resultat.Rows[0]["DateEmbauche"]);
            return trouverVisiteur;
        }
        public Visiteurs SelectById(string idVisiteur)
        {
            DataRow resultat = this._dbal.SelectById("visiteur", idVisiteur);
            return new Visiteurs((string)resultat["id"], (string)resultat["nom"], (string)resultat["prenom"], (string)resultat["login"], (string)resultat["mdp"], (string)resultat["adresse"], (string)resultat["cp"], (string)resultat["ville"], (DateTime)resultat["dateEmbauche"]);
        }
    }
}
