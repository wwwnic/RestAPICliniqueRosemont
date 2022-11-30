using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{
    public class AuthentificationController : Controller
    {

        private readonly PatientDAO PatDAO = new PatientDAO();

        private readonly MedecinDAO MeDDAO = new MedecinDAO();


        [HttpPost]
        [Route("Patient/Login")]
        public bool Login([FromBody] Utilisateur utilisateurPotentiel)
        {
            var patient = PatDAO.listerUnPatientParID(utilisateurPotentiel.Id);
            var estMdpValide = patient.Password == utilisateurPotentiel.Password;
            return estMdpValide;
        }


        [HttpPost]
        [Route("Medecin/Login")]
        public bool LoginAppMedecin([FromBody] Utilisateur utilisateurPotentiel)
        {
            var medecin = MeDDAO.AvoirUnMedecinParId(utilisateurPotentiel.Id);
            var estMdpValide = medecin.Password == utilisateurPotentiel.Password;
            return estMdpValide;
        }
    }
}
