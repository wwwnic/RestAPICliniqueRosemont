using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [Route("[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly PrescriptionDAO DAO = new PrescriptionDAO();


        [HttpGet]
        [Route("GetAll")]
        public List<Prescription> GetAll()
        {
            var lstPres = DAO.AvoirLesPrescriptions();
            return lstPres;
        }

        [HttpGet]
        [Route("GetById")]
        public Prescription GetById(int id)
        {
            var pres = DAO.AvoirUnePrescription(id);
            return pres;
        }


        [HttpGet]
        [Route("GetByPatientId")]
        public List<Prescription> GetByPatientId(int id)
        {
            var pres = DAO.AvoirLesPrescriptionsParIdPatient(id);
            return pres;
        }

        [HttpGet]
        [Route("GetByDoctorId")]
        public List<Prescription> GetByDoctorId(int id)
        {
            var pres = DAO.AvoirLesPrescriptionsParIdMedecin(id);
            return pres;
        }

        [HttpPost]
        [Route("Add")]
        public void Add([FromBody] Prescription pres) {
            DAO.AjouterUnePrescription(pres);
        }

        [HttpPatch]
        [Route("Modify")]
        public void Modify([FromBody] Prescription pres)
        {
            DAO.ModifierUnePrescription(pres);
        }

        [HttpDelete]
        [Route("Remove")]
        public void Remove(int id)
        {
            DAO.SupprimerUnePrescription(id);
        }
    }
}
