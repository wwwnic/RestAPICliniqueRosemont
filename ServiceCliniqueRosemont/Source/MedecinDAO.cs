using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;

namespace ServiceCliniqueRosemont.Source
{
    public class MedecinDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM Medecins;";

        const string SQL_CREATE = "INSERT INTO `Medecins` (`nom`, `prenom`, `password`, `email`) VALUES (@nom, @prenom, @password, @email);";

        const string SQL_DELETE = "DELETE FROM `Medecins` WHERE (id=?";

        const string SQL_UPDATE = "UPDATE `Medecins` SET `id`=@id, `nom`=@nom, `prenom`=@prenom, `password`=@password, `email`=@email";

        public List<Medecin> AvoirTousLesMedecins()
        {
            Connecteur.Connect();
            var lstMed = new List<Medecin>();
            using (var command = Connecteur.connection.CreateCommand())
            {
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
                Connecteur.Disconnect();
                return lstMed;
            }
        }

        public bool AjouterUnMedecin(string nom, string prenom, string password, string email)
        {
            Connecteur.Connect();
            using (var command = Connecteur.connection.CreateCommand())
            {
                command.CommandText = SQL_CREATE;
                command.Parameters.AddWithValue("@nom", nom);
                command.Parameters.AddWithValue("@prenom", prenom);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@email", email);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                Connecteur.Disconnect();
                return isSucces;
            }
        }

        public bool SupprimerUnMedecin(int id)
        {
            Connecteur.Connect();
            using (var command = Connecteur.connection.CreateCommand())
            {
                command.CommandText = SQL_DELETE;
                command.Parameters.Remove(id);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                Connecteur.Disconnect();
                return isSucces;
            }
        }

        public bool ModifierUnMedecin(Medecin medecin)
        {
            Connecteur.Connect();
            using (var command = Connecteur.connection.CreateCommand())
            {
                command.CommandText = SQL_UPDATE;
                command.Parameters.AddWithValue("@id", medecin.Id);
                command.Parameters.AddWithValue("@nom", medecin.Nom);
                command.Parameters.AddWithValue("@prenom", medecin.Prenom);
                command.Parameters.AddWithValue("@password", medecin.Password);
                command.Parameters.AddWithValue("@email", medecin.Email);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                Connecteur.Disconnect();
                return isSucces;
            }
        }

    }
}
