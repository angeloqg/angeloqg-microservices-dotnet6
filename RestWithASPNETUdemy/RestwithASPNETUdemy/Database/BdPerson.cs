using RestwithASPNETUdemy.Models;

namespace RestwithASPNETUdemy.Database
{

    public static class BDPerson
    {
        public static List<PersonModel>? DbPersonal { get; set; }

        public static void InicializarDb() => DbPersonal = new List<PersonModel>();
    }
}
