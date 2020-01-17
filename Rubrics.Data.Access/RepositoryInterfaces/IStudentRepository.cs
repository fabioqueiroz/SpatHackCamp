using Rubrics.Data.JoinModels;
using Rubrics.General.Business.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        Student GetStudentById(int id);
        Task<IEnumerable> GetStudentsBySchoolClass(int teacherClassId);
        public bool DeleteStudentByEmail(string email);
        SchoolClass GetClassNameById(int id);
    }
}
