using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace WCF_REST_Clinique
{
    public class MedecinDao
    {
        static List<Medecin> medecins;

        public static void Remplir()
        {
            if (medecins == null)
            {
                medecins = new List<Medecin>();
                medecins.Add(new Medecin
                {
                    id = 1,
                    nom = "Archambault",
                    prenom = "Sebastien",
                    email = "sebastienarchambault@gmail.com",     
                    password = "archambault1234!"
                });

                medecins.Add(new Medecin
                {
                    id = 2,
                    nom = "Dugas",
                    prenom = "Jean",
                    email = "jeandugas@yahoo.com",
                    password = "cardiologue101"
                });

                medecins.Add(new Medecin
                {
                    id = 3,
                    nom = "Fernandez",
                    prenom = "Daniela",
                    email = "danielafernandez@hotmail.com",
                    password = "test"
                });

            }

        }

        public static List<Medecin> FindAll()
        {
            return medecins;

        }

        public static Medecin FindById(int id)
        {
            return medecins.Where(x => x.id == id).FirstOrDefault();

        }
        public static List<Medecin> FindByNom(string nom)
        {
            return medecins.Where(x => x.nom == nom).ToList();
        }


        public static void Ajouter(Medecin id)
        {
            medecins.Add(id);
        }

        public static bool ModifierMotDePasse(Medecin medecin)
        {
            foreach (Medecin info in medecins)
            {
                if (info.id == medecin.id)
                {
                    info.password = medecin.password;
                    return true;
                }
            }

            return false;

        }

        public static bool SupprimerMedecin(int idMedecin)
        {
            Medecin id = FindById(idMedecin);
            if (id != null)
                return medecins.Remove(id);
            return false;
        }
    }
}