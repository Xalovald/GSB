using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GSBFraisModel.Business;

namespace GSBFraisModel.Data
{
    public class DaoEtat
    {
        private Dbal _dbal;
        public DaoEtat (Dbal leDbal)
        {
            this._dbal = leDbal;
        }

        public List<Etat> SelectAll()
        {
            List<Etat> listeEtats = new List<Etat>();
            DataTable maTable = this._dbal.SelectAll("etat");
            foreach (DataRow r in maTable.Rows)
            {
                listeEtats.Add(new Etat((string)r["id"], (string)r["libelle"]));
            }
            return listeEtats;
        }

        public Etat SelectByIdEtat(string idEtat)
        {
            DataTable resultat = this._dbal.SelectByField("etat", "id = '" + idEtat + "'");
            DataRow dataRow = resultat.Rows[0];
            Etat trouverEtat = new Etat((string)dataRow["id"], (string)dataRow["libelle"]);
            return trouverEtat;
        }
    }
}
