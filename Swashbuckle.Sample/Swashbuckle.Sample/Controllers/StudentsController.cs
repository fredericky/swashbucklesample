using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.OData;
using Swashbuckle.Sample.Models;

namespace Swashbuckle.Sample.Controllers
{
    /// <summary>
    /// Students controller.
    /// </summary>
    public class StudentsController : ODataController
    {
        private static List<Student> _students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                Name = "Alice",
                Gender = Gender.Female
            },
            new Student()
            {
                Id = 2,
                Name = "Bob",
                Gender = Gender.Male
            }
        };

        /// <summary>
        /// Query student entities.
        /// </summary>
        [EnableQuery]
        public IQueryable<Student> Get()
        {
            Console.WriteLine("Get");
            return _students.AsQueryable();
        }

        /// <summary>
        /// Query a student entity by ID.
        /// </summary>
        /// <param name="key">The student ID.</param>
        /// <response code="200">OK</response>
        /// <response code="404">Not Found.</response>
        public Student Get([FromODataUri] int key)
        {
            Console.WriteLine("Get:key={0}", key);

            var res = _students.FirstOrDefault(p => p.Id == key);
            if (res == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return res;
        }

        /// <summary>
        /// Create a student entity.
        /// </summary>
        /// <param name="key">The student ID.</param>
        /// <param name="entity">The student entity.</param>
        public IHttpActionResult Put([FromODataUri] int key, Student entity)
        {
            Console.WriteLine("Put:key={0}", key);
            var product = _students.FirstOrDefault(p => p.Id == key);
            if (product != null)
            {
                _students.Remove(product);
                _students.Add(entity);
                return Updated(entity);
            }
            _students.Add(entity);
            return Created(entity);
        }

        /// <summary>
        /// Delete a student entity by ID.
        /// </summary>
        /// <param name="key">The student ID.</param>
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Console.WriteLine("Delete:key={0}", key);
            var product = _students.FirstOrDefault(p => p.Id == key);
            if (product == null)
            {
                return NotFound();;
            }
            _students.Remove(product);
            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Get student entities by gender.
        /// </summary>
        /// <param name="gender">The gender.</param>
        [HttpGet]
        public List<Student> GetByGender([FromODataUri] Gender gender)
        {
            Console.WriteLine("GetByGender:gender={0}", gender);
            return _students.Where(s => s.Gender == gender).ToList();
        }
    }
}
