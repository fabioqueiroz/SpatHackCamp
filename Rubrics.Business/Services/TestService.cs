using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rubrics.Business.Services
{
    public class TestService : ITestService
    {
        private IRubricsRepository _repository;

        public TestService(IRubricsRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TestModel>> GetStudents()
        {
            List<TestModel> students = new List<TestModel>();

            var studentsInDb = _repository.All<Student>();

            foreach (var student in studentsInDb)
            {
                var result = new TestModel()
                {
                    Id = student.Id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Score = student.ClassId
                };

                students.Add(result);
            }

            return students;
        }
    }
}
