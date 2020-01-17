using Rubrics.Data;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.General.Business.Interfaces
{
    public interface ILoginService
    {
        int LoginValidation(string email, string password);
        bool DetailsChecker(string email, string password, List<string> detailsInDb);
        string SHA512ComputeHash(string password);

        AdminModel GetAdminByEmail(string email);
        TeacherModel GetTeacherByEmail(string email);

    }
}
