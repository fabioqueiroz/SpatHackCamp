using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Rubrics.Business.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public List<StudentModel> GetAllTheStudents()
        {
            var std = _repository.GetAllStudents();

            return std.Select(x => new StudentModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.Score

            }).ToList();
        }

        public List<JoinModel> GetTestJoinsUsingLinq()
        {
            var join = _repository.GetJoinsUsingLinq();

            ; return join.Select(x => new JoinModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.Score

            }).ToList();
        }
        public async Task<IEnumerable<JoinModel>> GetTestJoinsUsingDapper()
        {
            var result = await _repository.GetJoinsUsingDapper();

            return result.Select(x => new JoinModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.Score

            }).ToList();
        }

    }
}
