using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class PrescriptionController : ControllerBase
    {
        private readonly PrescriptionDAO DAO = new PrescriptionDAO();


        [HttpGet]
        public List<Prescription> GetAll()
        {
            var lstPres = DAO.AvoirLesPrescriptions();
            return lstPres;
        }

        [HttpGet]
        [Route("{id}")]
        public Prescription GetById(int id)
        {
            var pres = DAO.AvoirUnePrescription(id);
            return pres;
        }


        [HttpGet]
        [Route("ByPatientId/{id}")]
        public List<Prescription> GetByPatientId(int id)
        {
            var pres = DAO.AvoirLesPrescriptionsParIdPatient(id);
            return pres;
        }

        [HttpGet]
        [Route("ByDoctorId/{id}")]
        public List<Prescription> GetByDoctorId(int id)
        {
            var pres = DAO.AvoirLesPrescriptionsParIdMedecin(id);
            return pres;
        }

        [HttpPost]
        public void PostAdd([FromBody] Prescription pres)
        {
            DAO.AjouterUnePrescription(pres);
        }

        [HttpPut]
        public void PutModify([FromBody] Prescription pres)
        {
            DAO.ModifierUnePrescription(pres);
        }

        [HttpDelete]
        public void DeleteRemove(int id)
        {
            DAO.SupprimerUnePrescription(id);
        }
    }
}
