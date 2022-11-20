using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [Route("[controller]")]
    public class PrescriptionController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public List<Prescription> GetAll()
        {
            var dao = new PrescriptionDAO();
            var lstPres = dao.AvoirLesPrescriptions();
            return lstPres;
        }

        [HttpGet]
        [Route("GetById")]
        public Prescription GetById(int id)
        {
            var dao = new PrescriptionDAO();
            var pres = dao.AvoirUnePrescription(id);
            return pres;
        }


        [HttpGet]
        [Route("GetByPatientId")]
        public List<Prescription> GetByPatientId(int id)
        {
            var dao = new PrescriptionDAO();
            var pres = dao.AvoirLesPrescriptionsParIdPatient(id);
            return pres;
        }

        [HttpGet]
        [Route("GetByDoctorId")]
        public List<Prescription> GetByDoctorId(int id)
        {
            var dao = new PrescriptionDAO();
            var pres = dao.AvoirLesPrescriptionsParIdMedecin(id);
            return pres;
        }

        [HttpPut]
        [Route("Add")]
        public void Add(int idMed, int idPat, string prescription, string note, string reference)
        {
            var dao = new PrescriptionDAO();
            dao.AjouterUnePrescription(idMed, idPat, prescription, note, reference);
        }

        [HttpPatch]
        [Route("Modify")]
        public void Modify(int id, int idMed, int idPat, string prescription, string note, string reference)
        {
            var dao = new PrescriptionDAO();
            dao.ModifierUnePrescription(id, idMed, idPat, prescription, note, reference);
        }
    }
}
