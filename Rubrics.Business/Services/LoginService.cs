using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Business.Services
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IStudentRepository _studentRepository;
        public LoginService(ILoginRepository loginRepository, IStudentRepository studentRepository)
        {
            _loginRepository = loginRepository;
            _studentRepository = studentRepository;
        }

        public bool LoginValidation(string email, string password)
        {
            // Check if is an admin
            var adminDetails = _loginRepository.CheckAdminDetails(email);
            if (adminDetails.Count > 0)
            {
                return DetailsChecker(email, password, adminDetails);
            }

            else
            {
                // Check if is a teacher
                // TODO

                // Check if is a student
                var studentDetails = _studentRepository.GetStudentLoginDetailsByEmail(email);
                if (studentDetails.Count > 0)
                {
                    return DetailsChecker(email, password, studentDetails);
                }
            }

            return false;
        }

        public bool DetailsChecker(string email, string password, List<string> detailsInDb)
        {
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                if (detailsInDb.Contains(email) && detailsInDb.Contains(password))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
