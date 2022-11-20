using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;
using System.Data.SqlClient;

namespace ServiceCliniqueRosemont.Source
{
    public class PatientDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM PATIENTS;";

        const string SQL_CREATE = "INSERT INTO `PATIENTS` (`nom`, `prenom`, `password`, `email`, `ddn`, `age`, `sexe`, `allergies`) VALUES (@nom, @prenom, @password, @email, @ddn, @age, @sexe, @allergies);";

        const string SQL_DELETE = "DELETE FROM `PATIENTS` WHERE (id=?";

        const string SQL_BY_ID = "SELECT * FROM PATIENTS WHERE `id`=@id";

        public List<Patient> AvoirTousLesPatients()
        {
            Connecteur.Connect();
            var lstpatients = new List<Patient>();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_SELECT_ALL;
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                var patient = new Patient
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("nom"),
                    Prenom = reader.GetString("prenom"),
                    Password = reader.GetString("password"),
                    Email = reader.GetString("email"),
                    Ddn = reader.GetString("ddn"),
                    Age = reader.GetString("age"),
                    Sexe = reader.GetString("sexe"),
                    Allergies = reader.GetString("allergies")
                };
                lstpatients.Add(patient);
            }
            Connecteur.Disconnect();
            return lstpatients;
        }

        public bool AjouterUnPatient(string nom, string prenom, string password, string email, string ddn, string age, string sexe, string allergies)
        {
            Connecteur.Connect();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_CREATE;
            command.Parameters.AddWithValue("@nom", nom);
            command.Parameters.AddWithValue("@prenom", prenom);
            command.Parameters.AddWithValue("@password", password);
            command.Parameters.AddWithValue("@email", email);
            command.Parameters.AddWithValue("@ddn", ddn);
            command.Parameters.AddWithValue("@age", age);
            command.Parameters.AddWithValue("@sexe", sexe);
            command.Parameters.AddWithValue("@allergies", allergies);

            var reader = command.ExecuteReader();
            var isSucces = reader != null;
            Connecteur.Disconnect();
            return isSucces;
        }

        public bool SupprimerUnPatient(int id)
        {
            Connecteur.Connect();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_DELETE;
            command.Parameters.Remove(id);

            var reader = command.ExecuteReader();
            var isSucces = reader != null;
            Connecteur.Disconnect();
            return isSucces;
        }

        public Patient listerUnPatientParID(int id)
        {
            Connecteur.Connect();
            var patient = new Patient();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_BY_ID;
            command.Parameters.AddWithValue("@id", id);
            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                patient = new Patient
                {
                    Id = reader.GetInt32("id"),
                    Nom = reader.GetString("nom"),
                    Prenom = reader.GetString("prenom"),
                    Password = reader.GetString("password"),
                    Email = reader.GetString("email"),
                    Ddn = reader.GetString("ddn"),
                    Age = reader.GetString("age"),
                    Sexe = reader.GetString("sexe"),
                    Allergies = reader.GetString("allergies")
                };
            }
            Connecteur.Disconnect();
            return patient;
        }


    }
}
