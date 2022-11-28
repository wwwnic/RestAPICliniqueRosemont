using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;
using System.Data;
using System.Data.SqlClient;

namespace ServiceCliniqueRosemont.Source
{
    public class PatientDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM PATIENTS;";

        const string SQL_CREATE = "INSERT INTO `PATIENTS` (`nom`, `prenom`, `password`, `email`, `ddn`, `age`, `sexe`, `allergies`) VALUES (@nom, @prenom, @password, @email, @ddn, @age, @sexe, @allergies);";

        const string SQL_DELETE = "DELETE FROM `PATIENTS` WHERE (id=?";

        const string SQL_BY_ID = "SELECT * FROM PATIENTS WHERE `id`=@id";

        const string SQL_BY_NOM = "SELECT * FROM PATIENTS WHERE `nom`=@nom";

        const string SQL_UPDATE = "UPDATE `PATIENTS` SET `id`=@id, `nom`=@nom, `prenom`=@prenom, `password`=@password, `email`=@email, `ddn`=@ddn, `age` = @age, `sexe`=@sexe, `allergies`=@allergies";

        const string SQL_UPDATE_INFO = "UPDATE `PATIENTS` SET `ddn`=@ddn, `age` = @age, `sexe`=@sexe, `allergies`=@allergies WHERE `id`=@id";

        const string SQL_SEARCH_BY_NAME = "SELECT * FROM PATIENTS WHERE `nom` LIKE @nom OR `prenom` LIKE @nom";


        public List<Patient> AvoirTousLesPatients()
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                var lstpatients = new List<Patient>();
                conn.connection.Open();
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
                        Age = reader.GetInt32("age"),
                        Sexe = reader.GetString("sexe"),
                        Allergies = reader.GetString("allergies")
                    };
                    lstpatients.Add(patient);
                }
                conn.Disconnect();
                return lstpatients;
            }
        }

        public bool AjouterUnPatient(Patient pat)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                conn.connection.Open();
                command.CommandText = SQL_CREATE;
                command.Parameters.AddWithValue("@nom", pat.Nom);
                command.Parameters.AddWithValue("@prenom", pat.Prenom);
                command.Parameters.AddWithValue("@password", pat.Password);
                command.Parameters.AddWithValue("@email", pat.Email);
                command.Parameters.AddWithValue("@ddn", pat.Ddn);
                command.Parameters.AddWithValue("@age", pat.Age);
                command.Parameters.AddWithValue("@sexe", pat.Sexe);
                command.Parameters.AddWithValue("@allergies", pat.Allergies);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.Disconnect();
                return isSucces;
            }
        }

        public bool SupprimerUnPatient(int id)
        {
            var conn = new Connecteur();

            using (var command = conn.connection.CreateCommand())
            {
                conn.Connect();
                command.CommandText = SQL_DELETE;
                command.Parameters.Remove(id);
                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.Disconnect();
                return isSucces;
            }
        }

        public Patient listerUnPatientParID(int id)
        {
            var conn = new Connecteur();
            try
            {
                using (var command = conn.connection.CreateCommand())
                {
                    command.Connection.Open();
                    var patient = new Patient();
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
                            Age = reader.GetInt32("age"),
                            Sexe = reader.GetString("sexe"),
                            Allergies = reader.GetString("allergies")
                        };
                    }
                    command.Connection.Close();
                    return patient;
                }
            }
            finally
            {
                conn.Disconnect();
            }
        }

        public Patient listerUnPatientParNom(string nom)
        {
            var conn = new Connecteur();

            var patient = new Patient();
            using (var command = conn.connection.CreateCommand())
            {
                conn.Connect();
                command.CommandText = SQL_BY_NOM;
                command.Parameters.AddWithValue("@nom", nom);
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
                        Age = reader.GetInt32("age"),
                        Sexe = reader.GetString("sexe"),
                        Allergies = reader.GetString("allergies")
                    };
                }
                conn.Disconnect();
                return patient;
            }
        }

        public bool ModifierUnPatient(Patient patient)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                conn.Connect();
                command.CommandText = SQL_UPDATE;
                command.Parameters.AddWithValue("@id", patient.Id);
                command.Parameters.AddWithValue("@nom", patient.Nom);
                command.Parameters.AddWithValue("@prenom", patient.Prenom);
                command.Parameters.AddWithValue("@password", patient.Password);
                command.Parameters.AddWithValue("@email", patient.Email);
                command.Parameters.AddWithValue("@ddn", patient.Ddn);
                command.Parameters.AddWithValue("@age", patient.Age);
                command.Parameters.AddWithValue("@sexe", patient.Sexe);
                command.Parameters.AddWithValue("@allergies", patient.Allergies);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.Disconnect();
                return isSucces;
            }
        }

        public bool ModifierInfoMedicalPatient(Patient patient)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                conn.Connect();
                command.CommandText = SQL_UPDATE_INFO;
                command.Parameters.AddWithValue("@id", patient.Id);
                command.Parameters.AddWithValue("@ddn", patient.Ddn);
                command.Parameters.AddWithValue("@age", patient.Age);
                command.Parameters.AddWithValue("@sexe", patient.Sexe);
                command.Parameters.AddWithValue("@allergies", patient.Allergies);

                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.Disconnect();
                return isSucces;
            }
        }

        public List<Patient> RechercherDesPatientsParNom(string nom)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                var lstpatients = new List<Patient>();
                conn.connection.Open();
                command.CommandText = SQL_SEARCH_BY_NAME;
                command.Parameters.AddWithValue("@nom", nom);
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
                        Age = reader.GetInt32("age"),
                        Sexe = reader.GetString("sexe"),
                        Allergies = reader.GetString("allergies")
                    };
                    lstpatients.Add(patient);
                }
                conn.Disconnect();
                return lstpatients;
            }
        }

    }
}
