using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace Course
{
    public static class GetRole
    {
        public static string loginUser;
        public static int GetID()
        {
            DB db = new DB();
            db.openConnection();
            MySqlCommand com = new MySqlCommand("SELECT code_role FROM users WHERE login = '" + loginUser + "'", db.getConnection());
            MySqlDataReader reader = com.ExecuteReader();
            reader.Read();
            int numId = Convert.ToInt32(reader[0]);
            reader.Close();
            db.closeConnection();
            return numId;
        }
        
    }
}
