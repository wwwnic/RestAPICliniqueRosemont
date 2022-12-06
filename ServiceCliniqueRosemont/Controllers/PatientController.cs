using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly PatientDAO DAO = new PatientDAO();

        [HttpGet]
        public List<Patient> GetAll() => DAO.AvoirTousLesPatients();

        [HttpGet]
        [Route("{idOrName}")]
        public List<Patient> GetSearch(String idOrName)
        {
            int entier;
            var RecherchEstUnEntier = int.TryParse(idOrName, out entier);

            if (RecherchEstUnEntier)
            {
                var lstPatient = new List<Patient>();
                var patient = DAO.listerUnPatientParID(entier);
                lstPatient.Add(patient);
                return lstPatient;
            }
            else
            {
                return DAO.RechercherDesPatientsParNom(idOrName);

            }
        }

        [HttpPost]
        public void PostAdd([FromBody] Patient patient) => DAO.AjouterUnPatient(patient);

        [HttpDelete]
        public void DeleteRemove(int id) => DAO.SupprimerUnPatient(id);

        [HttpPut]
        public void PutModify([FromBody] Patient patient) => DAO.ModifierUnPatient(patient);

        [HttpPut]
        [Route("MedicalInfo")]
        public void PutModifyMedicalInfo([FromBody] Patient patient) => DAO.ModifierInfoMedicalPatient(patient);
    }
}
