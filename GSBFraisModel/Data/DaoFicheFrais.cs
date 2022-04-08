using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBFraisModel.Business;
using System.Data;
using System.Globalization;

namespace GSBFraisModel.Data
{
    public class DaoFicheFrais
    {
        private Dbal _dbal;
        private DaoVisiteurs _daoVisiteur;
        private DaoEtat _daoEtat;
        private DaoLigneFraisForfait _daoLigneFraitForfait;
        private DaoLigneFraisHorsForfait _daoLigneFraisHorsForfait;

        public DaoFicheFrais(Dbal unDbal, DaoVisiteurs unDaoVisiteurs, DaoEtat unDaoEtat, DaoLigneFraisForfait unDaoLigneFraisForfait, DaoLigneFraisHorsForfait unDaoLigneFraisHorsForfait)
        {
            this._dbal = unDbal;
            this._daoVisiteur = unDaoVisiteurs;
            this._daoEtat = unDaoEtat;
            this._daoLigneFraitForfait = unDaoLigneFraisForfait;
            this._daoLigneFraisHorsForfait = unDaoLigneFraisHorsForfait;
        }

        public void Insert(FicheFrais uneFicheFrais)
        {
            string query = "fichefrais (idVisiteur, mois, nbJustificatifs, montantValide, dateModif) VALUES ('" + uneFicheFrais.UnVisiteur.Id + "', '" + uneFicheFrais.Mois + "', " + uneFicheFrais.Nbjustificatif + ", " + uneFicheFrais.MontantValide.ToString(CultureInfo.GetCultureInfo("en-GB")) + ", '" + uneFicheFrais.DateModif.Date.ToString("yyyy-MM-dd") + "')";
            this._dbal.Insert(query);
        }
        public void Delete(FicheFrais uneFicheFrais)
        {
            string query = "fichefrais where idVisiteur = '" + uneFicheFrais.UnVisiteur.Id + "' and mois = '" + uneFicheFrais.Mois + "'";
            this._dbal.Delete(query);
        }
        public void Update(FicheFrais uneFicheFrais)
        {
            string query = "fichefrais SET " + "idVisiteur = '" + uneFicheFrais.UnVisiteur.Id + "' , mois = '" + uneFicheFrais.Mois + "' , nbJustificatifs = '" + uneFicheFrais.Nbjustificatif + "' , montantValide = '" + uneFicheFrais.MontantValide + "' , idEtat = '" + uneFicheFrais.UnEtat.Id + "'WHERE idVisiteur = '" + uneFicheFrais.UnVisiteur.Id + "' AND mois = '" + uneFicheFrais.Mois + "'";
            this._dbal.Update(query);
        }
        public List<FicheFrais> SelectAll()
        {
            List<FicheFrais> listeFicheFrais = new List<FicheFrais>();
            DataTable maTable = this._dbal.SelectAll("fichefrais");
            foreach (DataRow r in maTable.Rows)
            {
                
                Visiteurs leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                Etat unEtat = _daoEtat.SelectByIdEtat((string)r["idEtat"]);
                FicheFrais uneFicheFrais = new FicheFrais((string)r["mois"], (int)r["nbJustificatifs"], (decimal)r["montantvalide"], (DateTime)r["dateModif"], leVisiteur, unEtat);
                List<LigneFraisForfait> lesLignesFraisForfait = new List<LigneFraisForfait>(this._daoLigneFraitForfait.SelectByFicheFrais(uneFicheFrais));
                List<LigneFraisHorsForfait> lesLignesFraisHorsForfait = new List<LigneFraisHorsForfait>(this._daoLigneFraisHorsForfait.selectbyFicheFrais(uneFicheFrais));
                uneFicheFrais.LesLignesFraisForfait = lesLignesFraisForfait;
                uneFicheFrais.LesLignesFraisHorsForfait = lesLignesFraisHorsForfait;
                listeFicheFrais.Add(uneFicheFrais);
            }
            return listeFicheFrais;
        }
        
        public FicheFrais SelectByIdVisiteur(string idVisiteur)
        {
            DataTable resultat = this._dbal.SelectByField("fichefrais", "idVisiteur = '" + idVisiteur + "'");
            DataRow dataRow = resultat.Rows[0];
            DaoVisiteurs daoVisiteur = new DaoVisiteurs(_dbal);
            DaoEtat daoEtat = new DaoEtat(_dbal);
            string idThing = (string)dataRow["idVisiteur"];
            return new FicheFrais((string)dataRow["mois"], (int)dataRow["nbjustificatifs"], (decimal)dataRow["montantValide"], (DateTime)dataRow["dateModif"], daoVisiteur.SelectById(idThing), daoEtat.SelectByIdEtat(idThing));
        }
        public List<FicheFrais> SelectByMonth(string moisFiche)
        {
            List<FicheFrais> listeFicheFrais = new List<FicheFrais>();
            DataTable maTable = this._dbal.SelectByField("fichefrais", "mois = '" + moisFiche + "'");
            foreach (DataRow r in maTable.Rows)
            {

                Visiteurs leVisiteur = _daoVisiteur.SelectById((string)r["idVisiteur"]);
                Etat unEtat = _daoEtat.SelectByIdEtat((string)r["idEtat"]);
                FicheFrais uneFicheFrais = new FicheFrais((string)r["mois"], (int)r["nbJustificatifs"], (decimal)r["montantvalide"], (DateTime)r["dateModif"], leVisiteur, unEtat);
                List<LigneFraisForfait> lesLignesFraisForfait = new List<LigneFraisForfait>(this._daoLigneFraitForfait.SelectByFicheFrais(uneFicheFrais));
                List<LigneFraisHorsForfait> lesLignesFraisHorsForfait = new List<LigneFraisHorsForfait>(this._daoLigneFraisHorsForfait.selectbyFicheFrais(uneFicheFrais));
                uneFicheFrais.LesLignesFraisForfait = lesLignesFraisForfait;
                uneFicheFrais.LesLignesFraisHorsForfait = lesLignesFraisHorsForfait;
                listeFicheFrais.Add(uneFicheFrais);
            }
            return listeFicheFrais;
        }

        public FicheFrais SelectByVisiteurMois(Visiteurs unVisiteur, string unMois)
        {
            DataRow r = _dbal.SelectByComposedPK2("fichefrais", "idVisiteur", unVisiteur.Id, "mois", unMois);
            if(r != null)
            { 
                Etat unEtat = _daoEtat.SelectByIdEtat((string)r["idEtat"]);
                FicheFrais uneFicheFrais = new FicheFrais((string)r["mois"], (int)r["nbJustificatifs"], (decimal)r["montantvalide"], (DateTime)r["dateModif"], unVisiteur, unEtat);
                return uneFicheFrais;
            }
            else
            {
                return null;
            }
        }
        public List<string> SelectListMonth()
        {
            List<string> ListMonth = new List<string>();
            
            DataTable maTable = this._dbal.SelectDistinctByField("mois", "fichefrais", "DESC");
            foreach(DataRow r in maTable.Rows)
            {
                ListMonth.Add((string)r["mois"]);
            }
            return ListMonth;
        }
    }
}
