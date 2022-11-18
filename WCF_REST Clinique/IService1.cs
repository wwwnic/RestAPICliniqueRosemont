using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_REST_Clinique
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom d'interface "IService1" à la fois dans le code et le fichier de configuration.
    [ServiceContract]
    public interface IService1
    {
       


        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "Patients/")]
        IEnumerable<Patient> GetAll();

        [OperationContract]
        [WebInvoke(Method = "GET",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json
                )]
        Patient FindById(int id);


        [OperationContract]
        [WebInvoke(Method = "POST",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "AddPatient")]
        void Add(Patient patients);

        [OperationContract]
        [WebInvoke(Method = "PUT",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json,
                UriTemplate = "UpdatePatients")]
        void Put(Patient patients);

        [OperationContract]
        [WebInvoke(Method = "DELETE",
                RequestFormat = WebMessageFormat.Json,
                ResponseFormat = WebMessageFormat.Json
                )]
        bool Delete(int id);

    }


}
