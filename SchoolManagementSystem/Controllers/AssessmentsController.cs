using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssessmentsController : ControllerBase
    {
        private readonly AssessmentsService _assessmentsService;
        public AssessmentsController(AssessmentsService assessmentsService) => _assessmentsService = assessmentsService;


        [HttpGet]
        public async Task<List<Assessment>> Get() =>
            await _assessmentsService.GetAsync();



        [HttpGet("{id:length(24)}")]

        public async Task<ActionResult<Assessment>> Get(string id)
        {
            var assessment = await _assessmentsService.GetAsync(id);

            if (assessment is null)
            {
                return NotFound();
            }
            return assessment;
        }



        [HttpPost]
        public async Task<IActionResult> Post(Assessment newAssessment)
        {
            await _assessmentsService.CreateAsync(newAssessment);
            return CreatedAtAction(nameof(Get), new { id = newAssessment.Id }, newAssessment);
        }



        [HttpPut("{id:length(24)}")]

        public async Task<IActionResult> Update(string id, Assessment updateAssessment)
        {
            var assessment = await _assessmentsService.GetAsync(id);

            if (assessment is null)
            {
                return NotFound();
            }
            updateAssessment.Id = assessment.Id;
            await _assessmentsService.UpdateAsync(id, updateAssessment);
            return NoContent();
        }



        [HttpDelete("{id:length(24)}")]

        public async Task<IActionResult> Delete(string id)
        {
            var assessment = await _assessmentsService.GetAsync(id);

            if (assessment is null)
            {
                return NotFound();
            }
            await _assessmentsService.RemoveAsync(id);
            return NoContent();
        }

    }
}
