using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WCF_REST_Clinique
{
    public class PatientsDao 
    {
        static List<Patient> patients;

        public static void Remplir()
        {
            if (patients == null)
            {
                patients = new List<Patient>();
                patients.Add(new Patient
                {
                    id = 1,
                    nom = "Price",
                    prenom = "John",
                    email = "johnprice@gmail.com",
                    ddn = "15/04/2001",
                    age = 21,
                    sexe = "Homme",
                    allergies = "Maladie du sérum",
                    password = "testPrice"
                });

                patients.Add(new Patient
                {
                    id = 2,
                    nom = "Beaudoin",
                    prenom = "Samuel",
                    email = "sambeaudoin@hotmail.com",
                    ddn = "24/08/1998",
                    age = 24,
                    sexe = "Homme",
                    allergies = "Pénicilline",
                    password = "Sam123!"
                });

                patients.Add(new Patient
                {
                    id = 3,
                    nom = "Lussier",
                    prenom = "Chloe",
                    email = "chloelussier2004@hotmail.com",
                    ddn = "09/02/2004",
                    age = 18,
                    sexe = "Femme",
                    allergies = "Ibuprofène, Codéine",
                    password = "Chloe%204"
                });

            }

        }

        public static List<Patient> FindAll()
        {
            return patients;

        }

        public static Patient FindById(int id)
        {
            return patients.Where(x => x.id == id).FirstOrDefault();

        }
        public static List<Patient> FindByNom(string nom)
        {
            return patients.Where(x => x.nom == nom).ToList();
        }


        public static void Ajouter(Patient id)
        {
            patients.Add(id);
        }

        public static bool ModifierPatient(Patient patient)
        {
            foreach (Patient info in patients)
            {
                if (info.id == patient.id)
                {
                    info.prenom = patient.prenom;
                    info.nom = patient.nom;
                    info.email = patient.email;
                    return true;
                }
            }

            return false;

        }

        public static bool ModifierMotDePassePatient(Patient patient)
        {
            foreach (Patient p in patients)
            {
                if (patient.id == p.id)
                {
                    patient.password = p.password;
                    return true;
                }
            }

            return false;

        }

        public static bool Supprimer(int idPatient)
        {
            Patient id = FindById(idPatient);
            if (id != null)
                return patients.Remove(id);
            return false;
        }
    }
}