using AdrianoRistrettoCore.Models;
using AdrianoRistrettoCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdrianoRistrettoCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ContratoController(ContratoService service) : ControllerBase
    {
        private readonly ContratoService _service = service;

        // GET: api/<ContratoController>
        [HttpGet]
        public async Task<List<Contrato>> Get() => await _service.GetAsync();

        // GET api/<ContratoController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Contrato>> Get(string id)
        {
            var contrato = await _service.GetAsync(id);

            if (contrato is null)
                return NotFound();

            return contrato;
        }

        // POST api/<ContratoController>
        [HttpPost]
        public async Task<IActionResult> Post(Contrato contrato)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            await _service.CreateAsync(contrato);

            return CreatedAtAction(nameof(Get), new { id = contrato.Id }, contrato);
        }

        // PUT api/<ContratoController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Contrato contrato)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var e = await _service.GetAsync(id);

            if (e is null)
                return NotFound();

            contrato.Id = e.Id;

            await _service.UpdateAsync(id, contrato);

            return Ok();
        }

        // DELETE api/<ContratoController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var contrato = await _service.GetAsync(id);

            if (contrato is null)
                return NotFound();

            await _service.RemoveAsync(id);

            return Ok();
        }
    }
}
