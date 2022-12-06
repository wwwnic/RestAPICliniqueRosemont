using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;
using System.Net;
using System.Web.Http.ModelBinding;

namespace ServiceCliniqueRosemont.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class MedecinController : ControllerBase
    {
        private readonly MedecinDAO DAO = new MedecinDAO();

        [HttpGet]
        public List<Medecin> GetAll()
        {
            return DAO.AvoirTousLesMedecins();
        }

        [HttpPost]
        public void PostAdd(string nom, string prenom, string password, string email)
        {
            DAO.AjouterUnMedecin(prenom, nom, password, email);
        }

        [HttpDelete]
        public void DeleteRemove(int id)
        {
            DAO.SupprimerUnMedecin(id);
        }

        [HttpPut]
        public void PutModify([FromBody] Medecin medecin)
        {
            DAO.ModifierUnMedecin(medecin);
        }
    }
}
