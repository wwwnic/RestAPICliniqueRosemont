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
        [HttpGet]
        [Route("GetAll")]
        public List<Medecin> GetAll()
        {
            var dao = new MedecinDAO();
            var lstMed = dao.AvoirTousLesMedecins();
            return lstMed;
        }

        [HttpPut]
        [Route("Add")]
        public void Add(string nom, string prenom, string password, string email)
        {
            var dao = new MedecinDAO();
            var lstMed = dao.AjouterUnMedecin(prenom, nom, password, email);
        }
    }
}
