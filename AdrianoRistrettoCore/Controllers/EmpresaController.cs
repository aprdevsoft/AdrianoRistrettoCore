using AdrianoRistrettoCore.Models;
using AdrianoRistrettoCore.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdrianoRistrettoCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController(EmpresaService service) : ControllerBase
    {
        private readonly EmpresaService _service = service;


        // GET: api/<EmpresaController>
        [HttpGet]
        public async Task<List<Empresa>> Get() => await _service.GetAsync();
    

        // GET api/<EmpresaController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> Get(string id)
        {
            var empresa = await _service.GetAsync(id);

            if (empresa is null)
                return NotFound();

            return empresa;
        }

        // POST api/<EmpresaController>
        [HttpPost]
        public async Task<IActionResult> Post(Empresa empresa)
        {
            if(!ModelState.IsValid)
                return UnprocessableEntity();

            await _service.CreateAsync(empresa);

            return CreatedAtAction(nameof(Get), new { id = empresa.Id }, empresa);
        }

        // PUT api/<EmpresaController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Empresa empresa)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity();

            var e = await _service.GetAsync(id);

            if (e is null)
                return NotFound();

            empresa.Id = e.Id;

            await _service.UpdateAsync(id, empresa);

            return Ok();
        }

        // DELETE api/<EmpresaController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var empresa = await _service.GetAsync(id);

            if (empresa is null)
                return NotFound();

            await _service.RemoveAsync(id);

            return Ok();
        }
    }
}
