using ExamBiblio.Source;
using ServiceCliniqueRosemont.Model;

namespace ServiceCliniqueRosemont.Source
{
    public class PrescriptionDAO
    {
        const string SQL_SELECT_ALL = "SELECT * FROM prescription;";

        const string SQL_SELECT_BY_ID = "SELECT * FROM `prescription` WHERE id = @id";

        const string SQL_CREATE = "INSERT INTO `prescription` (`id_medecin`, `id_patient`, `prescription`, `notes`, `references` ) VALUES (@idMed, @idPat, @prescription, @notes, @references);";

        const string SQL_UPDATE = "UPDATE `prescription` SET `id_medecin`=@idMed, `id_patient`=@idPat, `prescription`=@prescription, `notes`=@notes, `references`=@references WHERE `prescription`.`id` = @id;";

        public List<Prescription> AvoirLesPrescriptions()
        {
            Connecteur.Connect();
            var lstPres = new List<Prescription>();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_SELECT_ALL;
            var reader = command.ExecuteReader();

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
            Connecteur.Disconnect();
            return lstPres;
        }

        public bool AjouterUnePrescription(int idMed, int idPat, string prescription, string note, string reference)
        {
            Connecteur.Connect();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_CREATE;
            command.Parameters.AddWithValue("@idMed", idMed);
            command.Parameters.AddWithValue("@idPat", idPat);
            command.Parameters.AddWithValue("@prescription", prescription);
            command.Parameters.AddWithValue("@notes", note);
            command.Parameters.AddWithValue("@references", reference);
            var reader = command.ExecuteReader();
            var isSucces = reader != null;
            Connecteur.Disconnect();
            return isSucces;
        }



        public Prescription AvoirUnePrescription(int id)
        {
            Connecteur.Connect();
            var command = Connecteur.connection.CreateCommand();
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
                Connecteur.Disconnect();
            }
            return pres;
        }

        public bool ModifierUnePrescription(int idPrescription, int nouvIdMed, int nouvIdPat, string nouvPrescription, string nouvNote, string nouvRef)
        {
            Connecteur.Connect();
            var command = Connecteur.connection.CreateCommand();
            command.CommandText = SQL_UPDATE;
            command.Parameters.AddWithValue("@id", idPrescription);
            command.Parameters.AddWithValue("@idMed", nouvIdMed);
            command.Parameters.AddWithValue("@idPat", nouvIdPat);
            command.Parameters.AddWithValue("@prescription", nouvPrescription);
            command.Parameters.AddWithValue("@notes", nouvNote);
            command.Parameters.AddWithValue("@references", nouvRef);
            var reader = command.ExecuteReader();
            var isSucces = reader != null;
            Connecteur.Disconnect();
            return isSucces;
        }


    }
}
