using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;

namespace ServiceCliniqueRosemont.Source
{
    public class MedecinDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM Medecins;";

        const string SQL_BY_ID = "SELECT * FROM Medecins WHERE `id` = @id;";

        const string SQL_CREATE = "INSERT INTO `Medecins` (`nom`, `prenom`, `password`, `email`) VALUES (@nom, @prenom, @password, @email);";

        const string SQL_DELETE = "DELETE FROM `Medecins` WHERE (id=?";

        const string SQL_UPDATE = "UPDATE `Medecins` SET `id`=@id, `nom`=@nom, `prenom`=@prenom, `password`=@password, `email`=@email";

        public List<Medecin> AvoirTousLesMedecins()
        {
            var conn = new Connecteur();
            try
            {
                using (var command = conn.connection.CreateCommand())
                {
                    conn.connection.Open();
                    var lstMed = new List<Medecin>();
                    command.CommandText = SQL_SELECT_ALL;
                    var reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var med = new Medecin
                        {
                            Id = reader.GetInt32("id"),
                            Nom = reader.GetString("nom"),
                            Prenom = reader.GetString("prenom"),
                            Password = reader.GetString("password"),
                            Email = reader.GetString("email")
                        };
                        lstMed.Add(med);
                    }
                    conn.connection.Close();
                    return lstMed;
                }
            }
            finally
            {
                conn.connection.Close();
            }

        }

        public bool AjouterUnMedecin(string nom, string prenom, string password, string email)
        {
            var conn = new Connecteur();
            try
            {
                using (var command = conn.connection.CreateCommand())
                {
                    conn.connection.Open();
                    command.CommandText = SQL_CREATE;
                    command.Parameters.AddWithValue("@nom", nom);
                    command.Parameters.AddWithValue("@prenom", prenom);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);

                    var reader = command.ExecuteReader();
                    var isSucces = reader != null;
                    conn.Disconnect();
                    return isSucces;
                }
            }
            finally
            {
                conn.connection.Close();
            }
        }

        public bool SupprimerUnMedecin(int id)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                conn.connection.Open();
                command.CommandText = SQL_DELETE;
                command.Parameters.Remove(id);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.connection.Close();
                return isSucces;
            }
        }

        public bool ModifierUnMedecin(Medecin medecin)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                conn.connection.Open();
                command.CommandText = SQL_UPDATE;
                command.Parameters.AddWithValue("@id", medecin.Id);
                command.Parameters.AddWithValue("@nom", medecin.Nom);
                command.Parameters.AddWithValue("@prenom", medecin.Prenom);
                command.Parameters.AddWithValue("@password", medecin.Password);
                command.Parameters.AddWithValue("@email", medecin.Email);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.connection.Close();
                return isSucces;
            }
        }

        public Medecin AvoirUnMedecinParId(int id)
        {
            var conn = new Connecteur();
            try
            {
                using (var command = conn.connection.CreateCommand())
                {
                    command.Connection.Open();
                    var medecin = new Medecin();
                    command.CommandText = SQL_BY_ID;
                    command.Parameters.AddWithValue("@id", id);
                    var reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        medecin = new Medecin
                        {
                            Id = reader.GetInt32("id"),
                            Nom = reader.GetString("nom"),
                            Prenom = reader.GetString("prenom"),
                            Password = reader.GetString("password"),
                            Email = reader.GetString("email")
                        };
                    }
                    command.Connection.Close();
                    return medecin;
                }
            }
            finally
            {
                conn.Disconnect();
            }
        }
    }
}
