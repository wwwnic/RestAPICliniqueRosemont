using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;
using System.Reflection.PortableExecutable;

namespace ServiceCliniqueRosemont.Source
{
    public class PrescriptionDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM prescription;";

        const string SQL_SELECT_BY_ID = "SELECT * FROM `prescription` WHERE id = @id";

        const string SQL_SELECT_BY_ID_MEDECIN = "SELECT * FROM `prescription` WHERE id_medecin = @id";

        const string SQL_SELECT_BY_ID_PATIENT = "SELECT * FROM `prescription` WHERE id_patient = @id";

        const string SQL_CREATE = "INSERT INTO `prescription` (`id_medecin`, `id_patient`, `prescription`, `notes`, `references` ) VALUES (@idMed, @idPat, @prescription, @notes, @references);";

        const string SQL_UPDATE = "UPDATE `prescription` SET `id_medecin`=@idMed, `id_patient`=@idPat, `prescription`=@prescription, `notes`=@notes, `references`=@references WHERE `prescription`.`id` = @id;";

        const string SQL_DELETE = "DELETE FROM `prescription` WHERE (id=?";

        public List<Prescription> AvoirLesPrescriptions()
        {
            var conn = new Connecteur();

            using (var command = conn.connection.CreateCommand())
            {

                conn.Connect();
                command.CommandText = SQL_SELECT_ALL;
                var reader = command.ExecuteReader();
                var lstPres = new List<Prescription>();
                while (reader.Read())
                {
                    var pres = new Prescription
                    {
                        Id = reader.GetInt32("id"),
                        Id_medecin = reader.GetInt32("id_medecin"),
                        Id_patient = reader.GetInt32("id_patient"),
                        Description = reader.GetString("prescription"),
                        Notes = reader.GetString("notes"),
                        References = reader.GetString("references")

                    };
                    lstPres.Add(pres);
                }
                conn.Disconnect();
                return lstPres;
            }
        }

        public bool AjouterUnePrescription(Prescription pres)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                command.CommandText = SQL_CREATE;
                command.Parameters.AddWithValue("@idMed", pres.Id_medecin);
                command.Parameters.AddWithValue("@idPat", pres.Id_patient);
                command.Parameters.AddWithValue("@prescription", pres.Description);
                command.Parameters.AddWithValue("@notes", pres.Notes);
                command.Parameters.AddWithValue("@references", pres.References);
                var reader = command.ExecuteReader();
                var isSuccess = reader != null;
                conn.Disconnect();
                return isSuccess;
            }
        }

        public List<Prescription> AvoirLesPrescriptionsParIdMedecin(int id)
        {
            var conn = new Connecteur();
            using (var command = conn.connection.CreateCommand())
            {
                conn.connection.Open();
                command.CommandText = SQL_SELECT_BY_ID_MEDECIN;
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var listPres = new List<Prescription>();

                while (reader.Read())
                {
                    var pres = new Prescription
                    {
                        Id = reader.GetInt32("id"),
                        Id_medecin = reader.GetInt32("id_medecin"),
                        Id_patient = reader.GetInt32("id_patient"),
                        Description = reader.GetString("prescription"),
                        Notes = reader.GetString("notes"),
                        References = reader.GetString("references")
                    };
                    listPres.Add(pres);
                }
                conn.Disconnect();
                return listPres;
            }
        }

        public List<Prescription> AvoirLesPrescriptionsParIdPatient(int id)
        {
            var conn = new Connecteur();
            try
            {
                using (var command = conn.connection.CreateCommand())
                {
                    command.Connection.Open();
                    command.CommandText = SQL_SELECT_BY_ID_PATIENT;
                    command.Parameters.AddWithValue("@id", id); 
                    var reader = command.ExecuteReader();
                    var listPres = new List<Prescription>();

                    while (reader.Read())
                    {
                        var pres = new Prescription
                        {
                            Id = reader.GetInt32("id"),
                            Id_medecin = reader.GetInt32("id_medecin"),
                            Id_patient = reader.GetInt32("id_patient"),
                            Description = reader.GetString("prescription"),
                            Notes = reader.GetString("notes"),
                            References = reader.GetString("references")
                        };
                        listPres.Add(pres);
                    }
                    command.Connection.Close();
                    return listPres;
                }
            }
            finally
            {
                conn.connection.Close();
            }
        }
        public Prescription AvoirUnePrescription(int id)
        {

            var conn = new Connecteur();

            conn.Connect();
            using (var command = conn.connection.CreateCommand())
            {
                command.CommandText = SQL_SELECT_BY_ID;
                command.Parameters.AddWithValue("@id", id);
                var reader = command.ExecuteReader();
                var pres = new Prescription();
                if (reader.Read())
                {
                    pres = new Prescription
                    {
                        Id = reader.GetInt32("id"),
                        Id_medecin = reader.GetInt32("id_medecin"),
                        Id_patient = reader.GetInt32("id_patient"),
                        Description = reader.GetString("prescription"),
                        Notes = reader.GetString("notes"),
                        References = reader.GetString("references")
                    };
                    conn.Disconnect();
                }
                return pres;
            }
        }

        public bool ModifierUnePrescription(Prescription pres)
        {
            var conn = new Connecteur();

            using (var command = conn.connection.CreateCommand())
            {
                conn.Connect();
                command.CommandText = SQL_UPDATE;
                command.Parameters.AddWithValue("@id", pres.Id);
                command.Parameters.AddWithValue("@idMed", pres.Id_medecin);
                command.Parameters.AddWithValue("@idPat", pres.Id_patient);
                command.Parameters.AddWithValue("@prescription", pres.Description);
                command.Parameters.AddWithValue("@notes", pres.Notes);
                command.Parameters.AddWithValue("@references", pres.References);
                var reader = command.ExecuteReader();
                var isSucces = reader != null;
                conn.Disconnect();
                return isSucces;
            }
        }


        public bool SupprimerUnePrescription(int id)
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

    }
}
