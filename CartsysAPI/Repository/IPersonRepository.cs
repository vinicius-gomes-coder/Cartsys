using CartSysAPI.Data.DTO;

namespace CartSysAPI.Repository
{
    public interface IPersonRepository
    {
        Task<IEnumerable<PersonDTO>> GetAll();
        Task<PersonDTO> GetById(long id);
        Task<PersonDTO> Create(PersonDTO task);
        Task<PersonDTO> Update(PersonDTO task);
        Task<bool> Delete(long id);
    }
}
