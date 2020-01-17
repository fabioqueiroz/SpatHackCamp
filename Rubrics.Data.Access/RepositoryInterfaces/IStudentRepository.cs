using Rubrics.Data.JoinModels;
using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Rubrics.General.Models;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        List<Join> GetJoinsUsingLinq();
        Task<IEnumerable<Join>> GetJoinsUsingDapper();
        void RegisterNewStudent(Student newStudent);
        List<string> GetStudentLoginDetailsByEmail(string email);
        Student GetStudentByEmail(string email);
        Task<IEnumerable<Student>> GetStudentsBySchoolClasses(int teacherClassId);
        Student GetStudentById(int id);
        string GetSchoolNameById(int id);
        bool DeleteStudentByEmail(string email);
    }
}
