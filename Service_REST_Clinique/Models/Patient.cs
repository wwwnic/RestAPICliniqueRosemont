using System.Runtime.Serialization;

namespace WCF_REST_Clinique
{
    [DataContract]
    public class Patient
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
        public string ddn { get; set; }
        [DataMember]
        public string adresse { get; set; }
        [DataMember]
        public int age { get; set; }
        [DataMember]
        public string sexe { get; set; }
        [DataMember]
        public string allergies { get; set; }
        [DataMember]
        public string password { get; set; }

    }
}