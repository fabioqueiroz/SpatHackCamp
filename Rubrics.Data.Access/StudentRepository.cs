using Microsoft.EntityFrameworkCore;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.Data.JoinModels;
using Rubrics.General.Business.Models;
using System;
using System.Collections;
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

        // To be removed, just for testing
        public List<Student> GetAllStudents()
        {
            var students = _repository.RubricsContext.Students.FromSqlRaw("SELECT * FROM dbo.Students").ToList();

            var x = GetJoinsUsingLinq();

            return students;

        }

        // To be removed, just for testing
        // Example of a sql operation LINQ syntax
        public List<Join> GetJoinsUsingLinq()
        {

            var output = new List<Join>();

            var db = _repository.RubricsContext;

            var result = (from s in db.Students
                join t in db.Tests on s.ClassId equals t.Score
                select new {s.FirstName, s.LastName}).ToList();

            foreach (var item in result)
            {
                output.Add(new Join {FirstName = item.FirstName, LastName = item.LastName});
            }

            return output;
        }

        // To be removed, just for testing
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

        // This method inserts a new student in the db
        public void RegisterNewStudent(Student newStudent)
        {
            //working
            _repository.Add<Student>(newStudent);
            _repository.Commit();
        }

        public Student GetStudentById(int studentId)
        {
            var student = new Student();

            try
            {
                var studentInIDb = _repository.GetSingle<Student>(x => x.Id == studentId);

                if (studentInIDb != null)
                {
                    student.Id = studentInIDb.Id;
                    student.FirstName = studentInIDb.FirstName;
                    student.LastName = studentInIDb.LastName;
                    student.Email = studentInIDb.Email;
                    student.Password = studentInIDb.Password;
                    student.DOB = studentInIDb.DOB;
                    student.Address = studentInIDb.Address;
                    student.ClassId = studentInIDb.ClassId;
                }

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return student;
        }


        public List<string> GetStudentLoginDetailsByEmail(string email)
        {
            var stdDetails = new List<string>();
            try
            {
                var studentInIDb = _repository.GetSingle<Student>(x => x.Email == email);

                if (studentInIDb != null)
                {
                    stdDetails.Add(studentInIDb.Email);
                    stdDetails.Add(studentInIDb.Password);
                }

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return stdDetails;
        }

        public Student GetStudentByEmail(string email)
        {
            var student = new Student();

            try
            {
                var studentInIDb = _repository.GetSingle<Student>(x => x.Email == email);

                if (studentInIDb != null)
                {
                    student.Id = studentInIDb.Id;
                    student.FirstName = studentInIDb.FirstName;
                    student.LastName = studentInIDb.LastName;
                    student.Email = studentInIDb.Email;
                    student.Password = studentInIDb.Password;
                    student.DOB = studentInIDb.DOB;
                    student.Address = studentInIDb.Address;
                    student.ClassId = studentInIDb.ClassId;
                }

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return student;
        }

        //public Student GetStudentById(int id)
        //{
        //    var studentInIDb = _repository.GetSingle<Student>(x => x.Id == id);
        //    return studentInIDb;
        //}


        public async Task<IEnumerable<Student>> GetStudentsBySchoolClass(int teacherClassId)
        {
            var query = new CommandDefinition(@"SELECT * from dbo.Students s
              INNER JOIN dbo.SchoolClasses sc on s.ClassId = sc.Id
              INNER JOIN dbo.TableGroupStudents tgs on tgs.StudentId = s.Id
              INNER JOIN dbo.TableGroups t on t.Id = tgs.TableGroupId
              WHERE sc.Id = @ClassId", new {ClassId = teacherClassId});
            using (var conn = new SqlConnection(_connectionString.Value))
            {
                try
                {
                    var result = await conn.QueryAsync<Student>(query);
                    var data = result.FirstOrDefault();
                    return result;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw new Exception(ex.Message);
                }
            }
        }
        

        public bool DeleteStudentByEmail(string email)
        {
            Student toDelete =  _repository.GetSingle<Student>(x=> x.Email.Equals(email));
            if (toDelete == null)
            {
                return false;
            }
            else
            {
                try
                {
                    _repository.Delete<Student>(toDelete);
                    _repository.Commit();

                    return true;
                }
                catch (SqlException ex)
                {

                    throw new Exception(ex.Message);
                }
            }
        }

        public SchoolClass GetClassNameById(int id)
        {
            SchoolClass schoolClass = _repository.GetSingle<SchoolClass>(x => x.Id == id);
            return schoolClass;

        }
        public void UpdateStudentInDb(Student student)
        {
            var stdInDb = GetStudentByEmail(student.Email);

            stdInDb.FirstName = student.FirstName;
            stdInDb.LastName = student.LastName;
            stdInDb.Email = student.Email;
            stdInDb.Password = student.Password;
            stdInDb.DOB = student.DOB;
            stdInDb.Address = student.Address;
            stdInDb.ClassId = student.ClassId;

            try
            {
                _repository.Update<Student>(stdInDb);
                _repository.Commit();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public void UpdateStudentPassword(Student student)
        {
            var query = new CommandDefinition(
                          @"UPDATE dbo.Students
                          SET Password = @Password
                          WHERE Id = @Id", 
                          new { student.Id , student.Password});

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                try
                {
                    var result =  conn.Query<Student>(query);
                    var data = result.FirstOrDefault();

                }
                catch (SqlException ex)
                {

                    throw new Exception(ex.Message);
                }

            }
        }

        public void ChangeStudentClass(Student student, int classId)
        {
            var query = new CommandDefinition(
                          @"UPDATE dbo.Students
                          SET ClassId = @ClassId
                          WHERE Id = @Id", 
                          new { student.Id, ClassId = classId });

            using (var conn = new SqlConnection(_connectionString.Value))
            {
                try
                {
                    var result = conn.Query<Student>(query);
                    var data = result.FirstOrDefault();

                }
                catch (SqlException ex)
                {

                    throw new Exception(ex.Message);
                }

            }
        }
    }
}
