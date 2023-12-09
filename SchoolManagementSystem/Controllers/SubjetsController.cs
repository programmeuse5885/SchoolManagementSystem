using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubjetsController : ControllerBase
    {
        private readonly SubjetsService _subjetsService;
        public SubjetsController(SubjetsService subjetsService) => _subjetsService = subjetsService;

        [HttpGet]

        public async Task<List<Subject>> Get() =>
            await _subjetsService.GetAsync();

        [HttpGet("{id:length(24)}")]

        public async Task<ActionResult<Subject>> Get(string id)
        {
            var subject = await _subjetsService.GetAsync(id);

            if (subject is null)
            {
                return NotFound();
            }
            return subject;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Subject newSubject)
        {
            await _subjetsService.CreateAsync(newSubject);
            return CreatedAtAction(nameof(Get), new { id = newSubject.Id }, newSubject);
        }

        [HttpPut("{id:length(24)}")]

        public async Task<IActionResult> Update(string id, Subject updateSubject)
        {
            var subject = await _subjetsService.GetAsync(id);

            if (subject is null)
            {
                return NotFound();
            }
            updateSubject.Id = subject.Id;
            await _subjetsService.UpdateAsync(id, updateSubject);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]

        public async Task<IActionResult> Delete(string id)
        {
            var subject = await _subjetsService.GetAsync(id);

            if (subject is null)
            {
                return NotFound();
            }
            await _subjetsService.RemoveAsync(id);
            return NoContent();
        }


    }
}
