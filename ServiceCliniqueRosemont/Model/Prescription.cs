using System.Diagnostics.CodeAnalysis;

namespace ServiceCliniqueRosemont.Model
{
    public class Prescription
    {

        public int Id { get; set; }

        public int Id_medecin { get; set; }

        public int Id_patient { get; set; }

        public string Description { get; set; } = "";

        public string Notes { get; set; } = "";

        public string References { get; set; } = "";

    }
}
