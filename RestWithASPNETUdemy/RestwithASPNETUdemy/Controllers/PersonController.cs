using Microsoft.AspNetCore.Mvc;
using RestwithASPNETUdemy.Models;
using RestwithASPNETUdemy.Services.Implementations;

namespace RestwithASPNETUdemy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        
        private readonly ILogger<CalculatorController> _logger;
        private readonly IPersonalService _personService;


        public PersonController(ILogger<CalculatorController> logger, IPersonalService personService)
        {            
            _logger = logger;
            _personService = personService;
        }

        [HttpGet("GetAll")]
        public IActionResult Get()
        {
            if(_personService.FindAll().Count == 0)
                return NotFound("Nenhum resultado encontrado");
            return Ok(_personService.FindAll());
        }

        [HttpGet("FindById/{id}")]
        public IActionResult Get(long id)
        {
            var busca = _personService.FirstById(id);
            if (busca.Id == 0)
                return NotFound("Nenhum resultado encontrado");
            return Ok(_personService.FirstById(id));
        }

        [HttpPost("Create")]
        public IActionResult Create([FromBody]PersonRequest personal)
        {
            return Ok(_personService.Create(personal));
        }

        [HttpPut("Update")]
        public IActionResult Update([FromBody] PersonModel personal)
        {
            var busca = _personService.FirstById(personal.Id);
            if (busca.Id == 0)
                return NotFound("Nenhum resultado encontrado");
            return Ok(_personService.Update(personal));
        }

        [HttpDelete("Delete/{id}")]
        public IActionResult Delete(long id)
        {
            var busca = _personService.FirstById(id);
            if (busca.Id == 0)
                return NotFound("Nenhum resultado encontrado");

            _personService.Delete(id);
            return Ok("Registro excluído com sucesso!");
        }
    }
}
