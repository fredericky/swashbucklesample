using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.OData;
using Swashbuckle.Sample.Models;

namespace Swashbuckle.Sample.Controllers
{
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
        /// <returns>The student entities.</returns>
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
        /// <returns>The student entity.</returns>
        [EnableQuery]
        public SingleResult<Student> Get([FromODataUri] int key)
        {
            Console.WriteLine("Get:key={0}", key);
            var res = _students.Where(p => p.Id == key).AsQueryable();
            return SingleResult.Create(res);
        }

        /// <summary>
        /// Create a student entity.
        /// </summary>
        /// <param name="key">The student ID.</param>
        /// <param name="entity">The student entity.</param>
        /// <returns>The created student entity.</returns>
        [ResponseType(typeof(Student))]
        public IHttpActionResult Put([FromODataUri] int key, Student entity)
        {
            Console.WriteLine("Put:key={0}", key);
            var product = _students.FirstOrDefault(p => p.Id == key);
            if (product != null)
            {
                _students.Remove(product);
            }
            _students.Add(entity);
            return Created(entity);
        }

        /// <summary>
        /// Delete a student entity by ID.
        /// </summary>
        /// <param name="key">The student ID.</param>
        /// <returns>The deletion result.</returns>
        [ResponseType(typeof(void))]
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
        /// <returns>The student entities with the specified gender.</returns>
        [HttpGet]
        [EnableQuery]
        public IQueryable<Student> GetByGender([FromODataUri] Gender gender)
        {
            Console.WriteLine("GetByGender:gender={0}", gender);
            return _students.Where(s => s.Gender == gender).AsQueryable();
        }

        /// <summary>
        /// Get student entities by IDs.
        /// </summary>
        /// <param name="ids">The student IDs.</param>
        /// <returns>The student entities with the specified IDs.</returns>
        [HttpGet]
        public IQueryable<Student> GetByIds([FromODataUri] int[] ids)
        {
            Console.WriteLine("GetByIds:Ids={0}", string.Join(",", ids));
            return _students.Where(s => ids.Contains(s.Id)).AsQueryable();
        }
    }
}
