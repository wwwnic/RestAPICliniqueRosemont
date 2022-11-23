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

        public MySqlConnection connection { get; private set; } = new MySqlConnection(builder.ConnectionString);

        public void Connect()
        {
        connection.Open();
        }

        public void Disconnect()
        {
        connection.Close();
        }
    }
}