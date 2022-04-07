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
    public class DaoLigneFraisHorsForfait
    {
        private Dbal unDbal;
        private DaoFraisForfait _daoFraisForfait;

        public DaoLigneFraisHorsForfait(Dbal myDbal, DaoFraisForfait monDaoFraisForfait)
        {
            this.unDbal = myDbal;
            this._daoFraisForfait = monDaoFraisForfait;
        }

        public void Insert(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = "ligneFraisHorsForfait (idVisiteur, mois, libelle, date, montant) VALUES ('" + LigneFraisHorsForfait.FicheFrais.UnVisiteur.Id + "',' " + LigneFraisHorsForfait.FicheFrais.Mois + "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = "ligneFraisHorsForfait SET id = " + LigneFraisHorsForfait.Id + ", idVisiteur = '" + LigneFraisHorsForfait.FicheFrais.UnVisiteur.Id + "', mois = '" + LigneFraisHorsForfait.FicheFrais.Mois + "' , libelle ='" + LigneFraisHorsForfait.Libelle + "', montant = " + LigneFraisHorsForfait.Montant + " WHERE id = " + LigneFraisHorsForfait.Id + "";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = "ligneFraisHorsForfait WHERE id ='" + LigneFraisHorsForfait.Id + "'AND id ='" + LigneFraisHorsForfait.Id + "'";
            this.unDbal.Delete(query);
        }
/*
        public List<LigneFraisHorsForfait> SelectAll()
        {
            List<LigneFraisHorsForfait> listLigneFraisForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectAll("ligneFraisHorsForfait");

            foreach (DataRow r in myTable.Rows)
            {
                listLigneFraisForfait.Add(new LigneFraisHorsForfait((int)r["id"], (string)r["idVisiteur"],(DateTime)r["mois"], (string)r["libelle"], (DateTime)r["date"], (decimal)r["montant"]));
            }
            return listLigneFraisForfait;
        }
*/
        public LigneFraisHorsForfait SelectById(string idFraisHorsForfait, FicheFrais uneFicheFrais)
        {
            DataRow result = this.unDbal.SelectById("ligneFraisHorsForfait", "id = " + idFraisHorsForfait);
            return new LigneFraisHorsForfait((int)result["id"], (string)result["libelle"], (DateTime)result["date"], (decimal)result["montant"], uneFicheFrais);
        }
        public List<LigneFraisHorsForfait> selectbyFicheFrais(FicheFrais uneFicheFrais)
        {
            List<LigneFraisHorsForfait> listLigneFraisHorsForfait = new List<LigneFraisHorsForfait>();
            DataTable myTable = this.unDbal.SelectByComposedFK2("lignefraishorsforfait", "idVisiteur", uneFicheFrais.UnVisiteur.Id, "mois", uneFicheFrais.Mois);
            foreach(DataRow r in myTable.Rows)
            {
                listLigneFraisHorsForfait.Add(new LigneFraisHorsForfait((int)r["id"], (string)r["libelle"], (DateTime)r["date"], (decimal)r["montant"], uneFicheFrais));
            }
            return listLigneFraisHorsForfait;
        }

    }
}
