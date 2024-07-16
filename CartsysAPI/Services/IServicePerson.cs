using CartSysAPI.Data.DTO;

namespace CartSysAPI.Services
{
    public interface IServicePerson
    {
        Task<IEnumerable<PersonDTO>> GetAll();
        Task<PersonDTO> GetById(long id);
        Task<PersonDTO> Create(PersonDTO person);
        Task<PersonDTO> Update(PersonDTO person);
        Task<bool> Delete(long id);
    }
}
