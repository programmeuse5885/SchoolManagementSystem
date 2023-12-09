using SchoolManagementSystem.Models;
using SchoolManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace SchoolManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly StudentsService _studentsService;
        public StudentsController(StudentsService studentsService) => _studentsService = studentsService;

        [HttpGet]
        public async Task<List<Student>> Get() =>
            await _studentsService.GetAsync();


        [HttpGet("{id:length(24)}")]

        public async Task<ActionResult<Student>> Get(string id)
        {
            var student = await _studentsService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }
            return student;
        }


        [HttpPost]
        public async Task<IActionResult> Post(Student newStudent)
        {
            await _studentsService.CreateAsync(newStudent);
            return CreatedAtAction(nameof(Get), new { id = newStudent.Id }, newStudent);
        }


        [HttpPut("{id:length(24)}")]

        public async Task<IActionResult> Update(string id, Student updateStudent)
        {
            var student = await _studentsService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }
            updateStudent.Id = student.Id;
            await _studentsService.UpdateAsync(id, updateStudent);
            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]

        public async Task<IActionResult> Delete(string id)
        {
            var student = await _studentsService.GetAsync(id);

            if (student is null)
            {
                return NotFound();
            }
            await _studentsService.RemoveAsync(id);
            return NoContent();
        }
    }
}
