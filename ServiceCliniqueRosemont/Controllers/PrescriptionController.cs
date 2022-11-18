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
