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
        public List<Patient> GetAll() => DAO.AvoirTousLesPatients();

        [HttpGet]
        [Route("GetById")]
        public Patient GetById(int id) => DAO.listerUnPatientParID(id);

        [HttpGet]
        [Route("GetByNom")]
        public Patient GetByNom(String nom) => DAO.listerUnPatientParNom(nom);

        [HttpPut]
        [Route("Add")]
        public void Add([FromBody] Patient patient) => DAO.AjouterUnPatient(patient);

        [HttpDelete]
        [Route("Remove")]
        public void Remove(int id) => DAO.SupprimerUnPatient(id);

        [HttpPatch]
        [Route("Modify")]
        public void Modify([FromBody] Patient patient) => DAO.ModifierUnPatient(patient);

        [HttpGet]
        [Route("Search")]
        public List<Patient> Search(String searchString)
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
