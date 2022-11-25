using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;
using System.Net;
using System.Web.Http.ModelBinding;

namespace ServiceCliniqueRosemont.Controllers
{

    [Route("[controller]")]
    public class MedecinController : ControllerBase
    {
        private readonly MedecinDAO DAO = new MedecinDAO();

        [HttpGet]
        [Route("GetAll")]
        public List<Medecin> GetAll()
        {
            return DAO.AvoirTousLesMedecins();
        }

        [HttpPut]
        [Route("Add")]
        public void Add(string nom, string prenom, string password, string email)
        {
            DAO.AjouterUnMedecin(prenom, nom, password, email);
        }

        [HttpDelete]
        [Route("Remove")]
        public void Remove(int id)
        {
           DAO.SupprimerUnMedecin(id);
        }

        [HttpPatch]
        [Route("Modify")]
        public void Modify([FromBody] Medecin medecin)
        {
            DAO.ModifierUnMedecin(medecin);
        }
    }
}
