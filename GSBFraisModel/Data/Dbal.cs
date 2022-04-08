using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GSBFraisModel.Data
{
    
    public class Dbal
    {
        
        MySqlConnection conn;

        public Dbal(string database = "gsb_gestfrais", string uid = "root", string password = "root", string server = "localhost")
        {
            Initialize(database, uid, password, server);
        }

        private void Initialize(string database, string  uid, string password, string server)
        {
            string connStr = "server="+server+";user="+uid+";database="+database+";port=3306;password="+password;
            this.conn = new MySqlConnection(connStr);
        }

        private void OpenConnection()
        {
            try
            {
                Console.WriteLine("Connecting to MySQL...");
                conn.Open();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        private void CloseConnection()
        {
            try
            {
                Console.WriteLine("Closing connection...");
                conn.Close();
                // Perform database operations
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public int CUDQuery(string query)
        {
            OpenConnection();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            int nbLignes = cmd.ExecuteNonQuery();
            CloseConnection(); //si on veut charger plus vite, enlever cette ligne
            return nbLignes;
        }
        public void Insert(string query)
        {
            query = "INSERT INTO " + query; // tablename (field1, field2) Values('value 1', 'value2')";
            CUDQuery(query);
        }
        public void Update(string query)
        {
            query = "UPDATE " + query;
            CUDQuery(query);
        }
        public void Delete(string query)
        {
            query = "DELETE FROM " + query;
            CUDQuery(query);
        }

        private DataSet RQuery(string query)
        {
            DataSet dataset = new DataSet();
            OpenConnection();
            MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn);
            adapter.Fill(dataset);
            CloseConnection();
            return dataset;
        }
        public DataTable SelectAll(string table)
        {
            string query = "SELECT * FROM " + table;
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
        }

        public DataRow SelectById(string table, string id)
        {
            string query = "SELECT * FROM " + table + " where id= '" + id + "'";
            DataSet dataset = RQuery(query);
            return dataset.Tables[0].Rows[0];
        }

        public DataTable SelectByField(string table, string fieldTestCondition)
        {
            string query = "SELECT * FROM " + table + " where " + fieldTestCondition;
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
        }

        public DataTable SelectDistinctByField(string field, string table, string order)
        {
            string query = "SELECT DISTINCT (" + field + ") FROM " + table + " ORDER BY " + field + " " + order;
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
        }
        public DataRow SelectByComposedPK2(string table, string keyname1, string keyvalue1
            , string keyname2, string keyvalue2)
        {
            string query = "SELECT * FROM " + table + " where "
                + keyname1 + "= '" + keyvalue1 + "' AND " + keyname2
                + " = '" + keyvalue2 + "'";
            DataSet dataset = RQuery(query);
            if(dataset.Tables[0].Rows.Count != 0)
            {
                return dataset.Tables[0].Rows[0];
            }
            else
            {
                return null;
            }   
        }
        public DataTable SelectByComposedFK2(string table, string keyname1, string keyvalue1
            , string keyname2, string keyvalue2)
        {
            string query = "SELECT * FROM " + table + " where " 
                + keyname1 + "= '" + keyvalue1 + "' AND " + keyname2 
                + " = '" + keyvalue2 + "'";
            DataSet dataset = RQuery(query);
            return dataset.Tables[0];
        }
    }
}
