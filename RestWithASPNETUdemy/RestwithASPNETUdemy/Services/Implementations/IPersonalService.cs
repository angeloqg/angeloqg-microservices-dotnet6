using RestwithASPNETUdemy.Models;

namespace RestwithASPNETUdemy.Services.Implementations
{
    public interface IPersonalService
    {
        PersonModel Create(PersonRequest person);
        PersonModel FirstById(long id);
        List<PersonModel> FindAll();
        PersonModel Update(PersonModel person);
        void Delete(long id);
    }
}
