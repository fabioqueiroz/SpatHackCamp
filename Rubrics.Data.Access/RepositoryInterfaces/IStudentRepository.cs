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
        void AddStudent(StudentModel student);
        void UpdateStudent(StudentModel student);
        List<Join> GetJoinsUsingLinq();
        Task<IEnumerable<Join>> GetJoinsUsingDapper();
    }
}
