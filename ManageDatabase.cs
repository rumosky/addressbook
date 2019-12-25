using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace WindowsFormsApp1
{
    class ManageDatabase
    {
        private MySqlConnection conn = null;
        private static class ManageDatabaseHolder
        {
            public static ManageDatabase INSTANCE = new ManageDatabase();
        }
        private ManageDatabase() { }
        public static ManageDatabase getInstance()
        {
            return ManageDatabaseHolder.INSTANCE;
        }
        public MySqlConnection getConnection()
        {
            if (conn == null)
            {
                ConnectDb();
            }
            return conn;
        }
        private void ConnectDb()
        {
            String url = "server=127.0.0.1;port=3306;user=root;password=test@1234; database=classofc;Charset=utf8;";
            try
            {
                conn = new MySqlConnection(url);
            }
            catch (MySqlException)
            {
                conn = null;
            }
        }
    }
}
