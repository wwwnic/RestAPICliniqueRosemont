using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_REST_Clinique
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1
    {
        public Service1()
        {
            PatientsDao.Remplir();
        }

        void IService1.Add(Patient patients)
        {
            PatientsDao.Ajouter(patients);
        }

        bool IService1.Delete(int id)
        {
            return PatientsDao.Supprimer(id);
        }

        IEnumerable<Patient> IService1.GetAll()
        {
            return PatientsDao.FindAll();
        }

       

        Patient IService1.FindById(int id)
        {
            return PatientsDao.FindById(id);
        }

        void IService1.Put(Patient patients)
        {
            PatientsDao.Modifier(patients);
        }


    }
  
}
