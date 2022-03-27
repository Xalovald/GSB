using GSBFraisModel.Data;
using GSBFraisModel.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSB
{
    class Program
    {
        static void Main(string[] args)
        {
            Dbal myDbal = new Dbal();
            DaoVisiteurs leDaoVisiteur = new DaoVisiteurs(myDbal);
            DaoEtat leDaoEtat = new DaoEtat(myDbal);
            //DaoFicheFrais unDaoFichefrais = new DaoFicheFrais(myDbal, leDaoVisiteur, leDaoEtat);
            //List<FicheFrais> listFiche = unDaoFichefrais.SelectByMonth("202108");
        }
    }
}
