using Rubrics.Data.JoinModels;
using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface IStudentRepository
    {
        List<Student> GetAllStudents();
        void AddStudent(StudentFormModel student);
        void UpdateStudent(StudentFormModel student);
        List<Join> GetJoinsUsingLinq();
        Task<IEnumerable<Join>> GetJoinsUsingDapper();
        void RegisterNewStudent(Student newStudent);
       
    }
}
