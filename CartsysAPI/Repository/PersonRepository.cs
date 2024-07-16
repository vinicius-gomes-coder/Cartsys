using AutoMapper;
using CartSysAPI.Data.DTO;
using CartSysAPI.Model;
using CartSysAPI.Model.Context;
using Microsoft.EntityFrameworkCore;

namespace CartSysAPI.Repository
{
    public class PersonRepository : IPersonRepository
    {
        private readonly CartsysContext _context;
        private IMapper _mapper;

        public PersonRepository(CartsysContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<PersonDTO>> GetAll()
        {
            List<PersonModel> persons = await _context.Persons.ToListAsync();

            return _mapper.Map<List<PersonDTO>>(persons);
        }

        public async Task<PersonDTO> GetById(long id)
        {
            PersonModel person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();

            if(person == null)
            {
                return null;
            }

            return _mapper.Map<PersonDTO>(person);
        }

        public async Task<PersonDTO> Update(PersonDTO person)
        {
            PersonModel return_person = _mapper.Map<PersonModel>(person);
            _context.Persons.Update(return_person);
            await _context.SaveChangesAsync();

            PersonDTO updated_person = await GetById(return_person.Id);

            return_person = _mapper.Map<PersonModel>(updated_person);

            return _mapper.Map<PersonDTO>(return_person);
        }

        public async Task<PersonDTO> Create(PersonDTO person)
        {
            PersonModel return_person = _mapper.Map<PersonModel>(person);
            _context.Persons.Add(return_person);
            await _context.SaveChangesAsync();

            PersonDTO created_person = await GetById(return_person.Id);

            return_person = _mapper.Map<PersonModel>(created_person);

            return _mapper.Map<PersonDTO>(return_person);
        }

        public async Task<bool> Delete(long id)
        {
            try
            {
                PersonModel person = await _context.Persons.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (person == null)
                {
                    return false;
                }
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

