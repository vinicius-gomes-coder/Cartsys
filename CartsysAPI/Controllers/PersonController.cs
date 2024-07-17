using CartSysAPI.Data.DTO;
using CartSysAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CartSysAPI.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private IServicePerson _personService;

        public PersonController(IServicePerson personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonDTO>>> GetAll()
        {
            IEnumerable<PersonDTO> data_task = await _personService.GetAll();

            if (data_task == null)
            {
                return NotFound();
            }

            return Ok(data_task);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PersonDTO>> Get(long id)
        {
            PersonDTO data_task = await _personService.GetById(id);

            if (data_task == null)
            {
                return NotFound();
            }

            return Ok(data_task);
        }

        [HttpPost]
        public async Task<ActionResult<PersonDTO>> Create(PersonDTO dto)
        {
            try
            {
                if (dto == null)
                {
                    return BadRequest();
                }

                PersonDTO data_task = await _personService.Create(dto);

                if (data_task == null)
                {
                    return NotFound();
                }

                return Ok(data_task);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<PersonDTO>> Update(PersonDTO dto)
        {
            if (dto == null)
            {
                return BadRequest();
            }

            PersonDTO data_task = await _personService.Update(dto);

            if (data_task == null)
            {
                return NotFound();
            }

            return Ok(data_task);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            bool status = await _personService.Delete(id);

            if (status == false)
            {
                return BadRequest();
            }

            return Ok();
        }
    }
}