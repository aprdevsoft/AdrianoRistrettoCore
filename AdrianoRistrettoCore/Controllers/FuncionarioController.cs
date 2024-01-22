using AdrianoRistrettoCore.Models;
using AdrianoRistrettoCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdrianoRistrettoCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController(FuncionarioService service) : ControllerBase
    {
        private readonly FuncionarioService _service = service;

        // GET: api/<FuncionarioController>
        [HttpGet]
        public async Task<List<Funcionario>> Get() => await _service.GetAsync();

        // GET api/<FuncionarioController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Funcionario>> Get(string id)
        {
            var funcionario = await _service.GetAsync(id);

            if (funcionario is null)
                return NotFound();

            return funcionario;
        }

        // POST api/<FuncionarioController>
        [HttpPost]
        public async Task<IActionResult> Post(Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            await _service.CreateAsync(funcionario);

            return CreatedAtAction(nameof(Get), new { id = funcionario.Id }, funcionario);
        }

        // PUT api/<FuncionarioController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Funcionario funcionario)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var e = await _service.GetAsync(id);

            if (e is null)
                return NotFound();

            funcionario.Id = e.Id;

            await _service.UpdateAsync(id, funcionario);

            return Ok();
        }

        // DELETE api/<FuncionarioController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var funcionario = await _service.GetAsync(id);

            if (funcionario is null)
                return NotFound();

            await _service.RemoveAsync(id);

            return Ok();
        }
    }
}
