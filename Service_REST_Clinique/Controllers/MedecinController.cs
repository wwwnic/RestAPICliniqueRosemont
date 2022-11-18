using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WCF_REST_Clinique;

namespace Service_REST_Clinique.Controllers
{
#pragma warning disable CS0246 // Le nom de type ou d'espace de noms 'ApiController' est introuvable (vous manque-t-il une directive using ou une référence d'assembly ?)
    public class MedecinController : ApiController
    {

        public MedecinController()
        {
            MedecinDao.Remplir();
        }


        //Avoir la liste de tous les patients 
        // GET api/<controller>
        public List<Patient> Get()
        {
            //Demande de tous les produits
            return PatientsDao.FindAll();
        }

        //Produit par Code :
        // GET api/<controller>/5125878
        //public Produit Get(int id)
        //{
        //    //Demande du Produit code = id
        //    return ProduitDao.find(id);

        //}
        //OU :        
        public IHttpActionResult Get(int id)
        {
            Patient prod = PatientsDao.FindById(id);
            if (prod != null)
            {
                return this.Ok(prod);
            }
            else
            {
                return this.NotFound();
            }
        }
        //Ajouter Patient :
        // POST: api/Patient
        public void Post(Patient p)
        {
            //Ajout d'un patient code = p
            PatientsDao.Ajouter(p);
        }

        //Modification des informations du patient :
        // PUT: api/Patient/5
        public void Put(int id, Patient p)
        {
            p.id = id;
            PatientsDao.ModifierPatient(p);
        }


        public void ModifierPwd(int id, Patient p)
        {
            p.id = id;
            PatientsDao.ModifierMotDePassePatient(p);
        }

        //Suppression du patient :
        // DELETE: api/Patient/5
        public void Delete(int id)
        {
            //Suppressin du Produit code = id
            PatientsDao.Supprimer(id);
        }
    }
}