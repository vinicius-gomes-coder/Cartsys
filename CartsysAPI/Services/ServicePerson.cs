using CartSysAPI.Data.DTO;
using CartSysAPI.Repository;

namespace CartSysAPI.Services
{
    public class ServicePerson : IServicePerson
    {
        private IPersonRepository _personRepository;

        public ServicePerson(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDTO> GetById(long id)
        {
            PersonDTO person = await _personRepository.GetById(id);

            return person;
        }

        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            IEnumerable<PersonDTO> person = await _personRepository.GetAll();

            return person;
        }

        public async Task<PersonDTO> Create(PersonDTO person)
        {
            PersonDTO dto = await _personRepository.Create(person);

            return dto;
        }

        public async Task<PersonDTO> Update(PersonDTO person)
        {
            PersonDTO dto = await _personRepository.Update(person);

            return dto;
        }

        public async Task<bool> Delete(long id)
        {
            bool status = await _personRepository.Delete(id);

            return status;
        }        
    }
}
