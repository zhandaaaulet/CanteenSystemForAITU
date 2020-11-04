using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Domain.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectForAITUCanteen.DataTransfer.DTO.Auth;
using ProjectForAITUCanteen.Domain.Models.Auth;

namespace CanteenSystemForAITU.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IEntityRepository<Student> _entityRepository;

        public StudentsController(IEntityRepository<Student> entityRepository)
        {
            _entityRepository = entityRepository;
        }

        [Authorize(Roles = Role.ADMIN)]
        [HttpGet]
        public async Task<ActionResult<ICollection<StudentDto>>> GetStudents()
        {
            IEnumerable<Student> innerStudents = await _entityRepository.GetStudents();
            ICollection<StudentDto> students = new LinkedList<StudentDto>();

            foreach (Student s in innerStudents)
            {
                students.Add(new StudentDto()
                {
                    Name = s.Name,
                    Surname = s.Surname,
                    Birthday = s.Birthday,
                    GroupId = s.GroupId
                });
            }
            return Ok(students);
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(StudentDto s)
        {
            Student st = new Student(s);
            if (await _entityRepository.AddStudent(st))
            {
                return Ok("A new user was added successfully!");
            }

            return BadRequest("Oops, something wrong happened!");
        }
    }
}
