using System.Runtime.Serialization;

namespace WCF_REST_Clinique
{
    [DataContract]
    public class Medecin
    {
        [DataMember]
        public int id { get; set; }
        [DataMember]
        public string nom { get; set; }
        [DataMember]
        public string prenom { get; set; }
        [DataMember]
        public string email { get; set; }
        [DataMember]
        public string password { get; set; }

    }
}