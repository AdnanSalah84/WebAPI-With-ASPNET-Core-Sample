using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ASPNet_WebAPI.Data;
using ASPNet_WebAPI.Models;

namespace ASPNet_WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Student")]
    public class StudentController : Controller
    {
        private readonly StudentDbContext _context;

        public StudentController(StudentDbContext context)
        {
            _context = context;
        }

        // GET: api/Student
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return _context.Students;
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student student = await _context.Students.SingleOrDefaultAsync(m => m.StudentId == id);

            if (student == null)
            {
                return NotFound();
            }

            return Ok(student);
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudent([FromRoute] int id, [FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != student.StudentId)
            {
                return BadRequest();
            }

            _context.Entry(student).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> PostStudent([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Students.Add(student);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StudentExists(student.StudentId))
                {
                    return new StatusCodeResult(StatusCodes.Status409Conflict);
                }
                else
                {
                    throw;
                }
            }

            return Ok(student);
        }

        // DELETE: api/Student/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Student student = await _context.Students.SingleOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();

            return Json(new { Message = "Deleted!" });
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Any(e => e.StudentId == id);
        }
    }
}