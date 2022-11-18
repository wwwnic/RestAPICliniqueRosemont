using MySql.Data.MySqlClient;
using System.Data;

namespace ExamBiblio.Source
{
    public class Connecteur
    {
        public static MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder
        {
            Server = "127.0.0.1",
            UserID = "root",
            Password = "",
            Database = "clinique"
        };

        public static MySqlConnection connection = new MySqlConnection(builder.ConnectionString);

        public static void Connect()
        {
            {
                if (connection.State.Equals(ConnectionState.Closed))
                {
                    connection.Open();
                }
            }
        }

        public static void Disconnect()
        {
            {
                if (connection.State.Equals(ConnectionState.Open))
                {
                    connection.Close();
                }
            }
        }
    }
}