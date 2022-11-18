using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;

namespace ServiceCliniqueRosemont.Source
{
    public class MedecinDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM Medecins;";

        const string SQL_CREATE = "INSERT INTO `Medecins` (`nom`, `prenom`, `password`, `email`) VALUES (@nom, @prenom, @password, @email);";

        public List<Medecin> AvoirTousLesMedecins()
        {
            Connecteur.Connect();
            var lstMed = new List<Medecin>();
            var command = Connecteur.connection.CreateCommand();
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

        public bool AjouterUnMedecin(string nom, string prenom, string password, string email)
        {
            Connecteur.Connect();
            var command = Connecteur.connection.CreateCommand();
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
}
