using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Patient> GetAll()
        {
            var dao = new PatientDAO();
            var lstMed = dao.AvoirTousLesPatients();
            return lstMed;
        }

        [HttpPut]
        [Route("Add")]
        public void Add(string nom, string prenom, string password, string email, string ddn, string age, string sexe, string allergies)
        {
            var dao = new PatientDAO();
            var lstPatient = dao.AjouterUnPatient(prenom, nom, password, email, ddn, age, sexe, allergies);
        }

        [HttpPut]
        [Route("Remove")]
        public void Remove(int id)
        {
            var dao = new PatientDAO();
            var lstPatient = dao.SupprimerUnPatient(id);
        }
    }
}
