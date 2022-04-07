using GSBFraisModel.Business;
using GSBFraisModel.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Data
{
    public class DaoLigneFraisForfait
    {
        private Dbal unDbal;
        private DaoFraisForfait _daoFraisForfait;

        public DaoLigneFraisForfait(Dbal myDbal, DaoFraisForfait monDaoFraisForfait)
        {
            this.unDbal = myDbal;
            this._daoFraisForfait = monDaoFraisForfait;
        }

        public void Insert(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = "ligneFraisForfait (idVisiteur, mois, idFraitForfait, quentite) VALUES ('" + uneLigneFraisForfait.FicheFrais + "','" + uneLigneFraisForfait.FicheFrais + "','" + uneLigneFraisForfait.FicheFrais + "','" + uneLigneFraisForfait.Quantite + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = "ligneFraisForfait SET idVisiteur = '" + uneLigneFraisForfait.FicheFrais.UnVisiteur.Id + "', mois = '" + uneLigneFraisForfait.FicheFrais.Mois + "', idFraisForfait = '" + uneLigneFraisForfait.FraisForfait.Id + "', quantite = " + uneLigneFraisForfait.Quantite + " WHERE idVisiteur = '" + uneLigneFraisForfait.FicheFrais.UnVisiteur.Id + "' AND mois = '" + uneLigneFraisForfait.FicheFrais.Mois + "' AND idFraisForfait = '" + uneLigneFraisForfait.FraisForfait.Id + "'";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisForfait uneLigneFraisForfait)
        {
            string query = " visiteur WHERE idVisiteur ='" + uneLigneFraisForfait.FicheFrais + "'AND idFraitForfait ='"+ uneLigneFraisForfait.FicheFrais + "'";
            this.unDbal.Delete(query);
        }
        /*
        public List<LigneFraisForfait> SelectAll()
        {
            List<LigneFraisForfait> listLigneFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligneFraisForfait");

            foreach (DataRow r in myTable.Rows)
            {
                listLigneFraisForfait.Add(new LigneFraisForfait((string)r["idVisiteur"], (DateTime)r["mois"], (string)r["idFraisForfait"], (decimal)r["quentite"]));
            }
            return listLigneFraisForfait;
        }
        */
        public List<LigneFraisForfait> SelectByFicheFrais(FicheFrais uneFicheFrais)
        {
            List<LigneFraisForfait> listesLignesFraisForfait = new List<LigneFraisForfait>();
            DataTable myTable = this.unDbal.SelectByComposedFK2("lignefraisforfait", "idVisiteur", uneFicheFrais.UnVisiteur.Id, "mois", uneFicheFrais.Mois);
            foreach(DataRow r in myTable.Rows)
            {
                FraisForfait leFraisForfait = this._daoFraisForfait.SelectById((string)r["idFraisForfait"]);
                listesLignesFraisForfait.Add(new LigneFraisForfait((int)r["quantite"], uneFicheFrais, leFraisForfait));
            }
            return listesLignesFraisForfait;
        }
    }
}
