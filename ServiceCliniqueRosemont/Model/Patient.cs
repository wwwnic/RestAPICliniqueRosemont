using System.Text.Json.Serialization;

namespace ServiceCliniqueRosemont.Model
{
    public class Patient
    {
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        public string Email { get; set; }

        public string Ddn { get; set; }

        public string Age { get; set; }

        public string Sexe { get; set; }

        public string Allergies { get; set; }

    }
}
