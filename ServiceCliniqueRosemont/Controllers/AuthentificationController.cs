using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{
    public class AuthentificationController : Controller
    {

        private readonly PatientDAO PatDAO = new PatientDAO();

        [HttpPost]
        [Route("Patient/Login")]
        public bool Login([FromBody] Utilisateur utilisateurPotentiel)
        {
            var patient = PatDAO.listerUnPatientParID(utilisateurPotentiel.Id);
            var estMdpValide = patient.Password == utilisateurPotentiel.Password;
            return estMdpValide;
        }
    }
}
