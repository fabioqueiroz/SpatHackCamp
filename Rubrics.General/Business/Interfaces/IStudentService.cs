using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Rubrics.General.Business.Interfaces
{
    public interface IStudentService
    {
        List<StudentFormModel> GetAllTheStudents();
        List<JoinModel> GetTestJoinsUsingLinq();
        Task<IEnumerable<JoinModel>> GetTestJoinsUsingDapper();
        string CreateRandomPassord(int size, bool lowerCase);
        void CreateNewStudent(StudentFormModel studentFormModel);
        bool FindStudentLoginDetails(string email, string password);
    }
}
