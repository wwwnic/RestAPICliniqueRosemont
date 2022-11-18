using Microsoft.AspNetCore.Mvc;
using ServiceCliniqueRosemont.Model;
using ServiceCliniqueRosemont.Source;

namespace ServiceCliniqueRosemont.Controllers
{

    [Route("[controller]")]
    public class PatientController : ControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public void GetAll()
        {

        }
    }
}
