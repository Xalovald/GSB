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
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quentite) VALUES ('" + LigneFraisHorsForfait.Id + "',' " + LigneFraisHorsForfait.FicheFrais + "','" + LigneFraisHorsForfait.FicheFrais + "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "')";
            this.unDbal.Insert(query);
        }

        public void Update(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " ligneFraisForfait (idVisiteur, mois, idFraitForfait, quentite) SET '" + LigneFraisHorsForfait.FicheFrais + "','" + LigneFraisHorsForfait.Libelle + "','" + LigneFraisHorsForfait.Date + "','" + LigneFraisHorsForfait.Montant + "'";
            this.unDbal.Update(query);
        }

        public void Delete(LigneFraisHorsForfait LigneFraisHorsForfait)
        {
            string query = " visiteur WHERE idVisiteur ='" + LigneFraisHorsForfait.FicheFrais + "'AND id ='" + LigneFraisHorsForfait.Id + "'";
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
            List<LigneFraisHorsForfait> listLigneFraisForfait = new List<LigneFraisHorsForfait>();
            DataRow myTable = this.unDbal.SelectByComposedPK2("lignefraisforfait", "idVisiteur", uneFicheFrais.UnVisiteur.Id, "mois", uneFicheFrais.Mois);
            return listLigneFraisForfait;
        }

    }
}
