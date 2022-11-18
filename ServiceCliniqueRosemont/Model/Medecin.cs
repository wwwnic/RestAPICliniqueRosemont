using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ServiceCliniqueRosemont.Model
{
    public class Medecin
    {

        public int Id { get; set; }

        public string Nom { get; set; } = "no name";

        public string Prenom { get; set; } = "no first name";

        [JsonIgnore]
        public string Password { get; set; }

        public string Email { get; set; } = "no email";

    }
}
