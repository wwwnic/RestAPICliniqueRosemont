using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientDAO DAO = new PatientDAO();

        [HttpGet]
        [Route("GetAll")]
        public List<Patient> GetAll()
        {
            var dao = new PatientDAO();
            var lstMed = dao.AvoirTousLesPatients();
            return lstMed;
        }

        [HttpGet]
        [Route("GetById")]
        public Patient GetById(int id)
        {
            var dao = new PatientDAO();
            var patient = dao.listerUnPatientParID(id);
            return patient;
        }

        [HttpGet]
        [Route("GetByNom")]
        public Patient GetByNom(String nom)
        {
            var dao = new PatientDAO();
            var patient = dao.listerUnPatientParNom(nom);
            return patient;
        }


        [HttpPut]
        [Route("Add")]
        public void Add(string nom, string prenom, string password, string email, DateTime ddn, int age, string sexe, string allergies)
        {
            var dao = new PatientDAO();
            var lstPatient = dao.AjouterUnPatient(prenom, nom, password, email, ddn, age, sexe, allergies);
        }

        [HttpDelete]
        [Route("Remove")]
        public void Remove(int id)
        {
            var dao = new PatientDAO();
            var lstPatient = dao.SupprimerUnPatient(id);
        }

        [HttpPatch]
        [Route("Modify")]
        public void Modify([FromBody] Patient patient)
        {
            DAO.ModifierUnPatient(patient);
        }

        [HttpGet]
        [Route("Search")]
        public List<Patient> SEARCH(String searchString)
        {
            int entier;
            var RecherchEstUnEntier = int.TryParse(searchString, out entier);

            if (RecherchEstUnEntier)
            {
                var lstPatient = new List<Patient>();
                var patient = DAO.listerUnPatientParID(entier);
                lstPatient.Add(patient);
                return lstPatient;
            }
            else
            {
                return DAO.RechercherDesPatientsParNom(searchString);

            }
        }
    }
}
