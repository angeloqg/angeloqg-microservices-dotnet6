using RestwithASPNETUdemy.Database;
using RestwithASPNETUdemy.Models;

namespace RestwithASPNETUdemy.Services.Implementations
{
    public class PersonalService : IPersonalService
    {
        private List<PersonModel> _dbPersonal { get; set; }
        public PersonalService()
        {
            _dbPersonal = new List<PersonModel>();

            if (BDPerson.DbPersonal == null)
            {
                BDPerson.InicializarDb();
            }

            if(BDPerson.DbPersonal != null)
            {
                _dbPersonal = BDPerson.DbPersonal;
            }
        }

        public PersonModel Create(PersonRequest person)
        {
            var objPerson = _dbPersonal.ToList();

            long id = 0;

            if (objPerson.Any())
            {
                id = objPerson.Last().Id + 1;
            }
            else
            {
                id = 1;
            }

            var objRequest = new PersonModel { Id = id,
                                               Firstname = person.Firstname,
                                               Lastname = person.Lastname,
                                               Address = person.Address,
                                               Gender = person.Gender};

            _dbPersonal.Add(objRequest);
            return objRequest;
        }

        public void Delete(long id)
        {
            if (_dbPersonal.Any(x => x.Id == id))
            {
                var objPerson = _dbPersonal.First(x => x.Id == id);
                _dbPersonal.Remove(objPerson);
            }
        }

        public List<PersonModel> FindAll()
        {
            return _dbPersonal.ToList();
        }

        public PersonModel FirstById(long id)
        {
            PersonModel resultPerson = new PersonModel();
            if (_dbPersonal.Any(x => x.Id == id))
            {
                resultPerson = _dbPersonal.First(x => x.Id == id);
            }

            return resultPerson;
        }

        public PersonModel Update(PersonModel person)
        {
            PersonModel resultPerson = new PersonModel();
            if (_dbPersonal.Any(x => x.Id == person.Id))
            {
                int index = _dbPersonal.IndexOf(_dbPersonal.First(x => x.Id == person.Id));

                _dbPersonal[index] = person;

                resultPerson = _dbPersonal[index];
            }

            return resultPerson;
        }


    }
}
