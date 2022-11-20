﻿using ExamBiblio.Source;
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

        public List<Patient> AvoirTousLesPatients()
        {
            Connecteur.Connect();
            var lstpatients = new List<Patient>();
            using (var command = Connecteur.connection.CreateCommand())
            {
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
                Connecteur.Disconnect();
                return lstpatients;
            }
        }

        public bool AjouterUnPatient(string nom, string prenom, string password, string email, DateTime ddn, int age, string sexe, string allergies)
        {
            Connecteur.Connect();
            using (var command = Connecteur.connection.CreateCommand())
            {
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
        }

        public bool SupprimerUnPatient(int id)
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

        public Patient listerUnPatientParID(int id)
        {
            Connecteur.Connect();
            var patient = new Patient();
            using (var command = Connecteur.connection.CreateCommand())
            {
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
                Connecteur.Disconnect();
                return patient;
            }
        }

        public Patient listerUnPatientParNom(string nom)
        {
            Connecteur.Connect();
            var patient = new Patient();
            using (var command = Connecteur.connection.CreateCommand())
            {
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
                Connecteur.Disconnect();
                return patient;
            }
        }

        public bool ModifierUnPatient(Patient patient)
        {
            Connecteur.Connect();
            using (var command = Connecteur.connection.CreateCommand())
            {
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
                Connecteur.Disconnect();
                return isSucces;
            }
        }


    }
}
