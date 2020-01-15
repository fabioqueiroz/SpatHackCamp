using Microsoft.EntityFrameworkCore;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.Data.JoinModels;
using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using Rubrics.Data.Access.ConnectionFactory;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Rubrics.Data.Access
{
    public class StudentRepository : IStudentRepository
    {
        private IRubricsRepository _repository;
        private readonly ConnectionString _connectionString;

        public StudentRepository(IRubricsRepository repository, ConnectionString connectionString)
        {
            _repository = repository;
            _connectionString = connectionString;
        }

        public void AddStudent(StudentFormModel student)
        {

        }

        public List<Student> GetAllStudents()
        {
            var students = _repository.RubricsContext.Students.FromSqlRaw("SELECT * FROM dbo.Students").ToList();

            var x = GetJoinsUsingLinq();

            return students;

        }

        // Example of a sql operation LINQ syntax
        public List<Join> GetJoinsUsingLinq()
        {

            var output = new List<Join>();

            var db = _repository.RubricsContext;

            var result = (from s in db.Students
                          join t in db.Tests on s.Score equals t.Score
                          select new { s.FirstName, s.LastName }).ToList();

            foreach (var item in result)
            {
                output.Add(new Join { FirstName = item.FirstName, LastName = item.LastName });
            }

            return output;
        }

        // Example using Dapper
        public async Task<IEnumerable<Join>> GetJoinsUsingDapper()
        {
            var query = @"SELECT s.FirstName, s.LastName
                          FROM dbo.Students s INNER JOIN dbo.Tests t on s.Score = t.Score";

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                try
                {
                    var data = await conn.QueryAsync<Join>(query);

                    return data;

                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);

                    throw new Exception(ex.Message);
                }

            }
        }


        public void UpdateStudent(StudentFormModel student)
        {
            throw new NotImplementedException();
        }

        // This method inserts a new student in the db
        public void RegisterNewStudent(Student newStudent)
        {
            _repository.Add<Student>(newStudent);
            _repository.Commit();
        }

        public List<string> GetStudentLoginDetailsByEmail(string email)
        {
            var stdDetails = new List<string>();

            var studentInIDb = _repository.GetSingle<Student>(x => x.Email == email);

            stdDetails.Add(studentInIDb.Email);
            stdDetails.Add(studentInIDb.Password);

            return stdDetails;
        }
    }
}
