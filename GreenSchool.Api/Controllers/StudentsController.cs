using System.Collections.Generic;
using System.Threading.Tasks;
using GreenSchool.Core.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace GreenSchool.Api.Controllers
{
    [Route("api/[controller]")]
    public class StudentsController : Controller
    {
        private readonly IStudentRepository _studentRepository; 

        public StudentsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET api/students
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/students/5
        [HttpGet("{id}")]
        public async Task<string> Get(int id)
        {
            var value = await _studentRepository.GetById(id);

            return $"{value.FirstName} {value.LastName} {value.StudentId}";
        }

        // POST api/students
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/students/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/students/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
