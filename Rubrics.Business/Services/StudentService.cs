using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Business.Models;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

        public List<StudentFormModel> GetAllTheStudents()
        {
            var std = _repository.GetAllStudents();

            return std.Select(x => new StudentFormModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.ClassId

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


        // Create a default password for the student
        public string CreateRandomPassword(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }

            return builder.ToString();
        }

        public void CreateNewStudent(StudentFormModel studentFormModel)
        {
            var student = new Student
            {
                FirstName = studentFormModel.FirstName,
                LastName = studentFormModel.LastName,
                Email = studentFormModel.Email,
                DOB = studentFormModel.DOB,
                Password = studentFormModel.Password,
                Address = studentFormModel.Address
            };

            _repository.RegisterNewStudent(student);
        }

        public StudentInDbModel GetStudentByEmail(string email)
        {
            var studentInDb = _repository.GetStudentByEmail(email);

            return new StudentInDbModel
            {
                Id = studentInDb.Id,
                FirstName = studentInDb.FirstName,
                LastName = studentInDb.LastName,
                Email = studentInDb.Email,
                Password = studentInDb.Password,
                DOB = studentInDb.DOB,
                Address = studentInDb.Address,
                ClassId = studentInDb.ClassId
            };
        }

        public async Task<List<StudentInDbModel>> AllStudentsInTheClass(int teacherClassId)
        {
            var listOfStudents = new List<StudentInDbModel>();

            var students = await _repository.GetStudentsBySchoolClass(teacherClassId);

            foreach (var std in students)
            {
                listOfStudents.Add(new StudentInDbModel { Id = std.Id, FirstName = std.FirstName, LastName = std.LastName});
            }

            return listOfStudents;
        }

        public void UpdateStudentPassword(StudentInDbModel studentInDb, string hashedPassword)
        {
            var updateStudent = new Student
            {
                Id = studentInDb.Id,
                FirstName = studentInDb.FirstName,
                LastName = studentInDb.LastName,
                Email = studentInDb.Email,
                Password = hashedPassword,
                Address = studentInDb.Address,
                DOB = studentInDb.DOB,
                ClassId = studentInDb.ClassId
            };

            _repository.UpdateStudentPassword(updateStudent);
        }
    }
}
