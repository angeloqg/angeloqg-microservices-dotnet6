using System.Text.Json.Serialization;

namespace RestwithASPNETUdemy.Models
{
    public class PersonModel
    {
        public long Id { get; set; }
        public string? Firstname { get; set; }
        public string? Lastname { get; set; }
        public string? Address { get; set; }
        public string? Gender { get; set; }

    }
}
