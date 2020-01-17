using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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


        public int LoginValidation(string email, string password)
        {
            // Hash the password 
            var hashedPassword = SHA512ComputeHash(password);

            // Check if is an admin
            var adminDetails = _loginRepository.CheckAdminDetails(email);
            if (adminDetails.Count > 0)
            {
               return DetailsChecker(email, hashedPassword, adminDetails) == true ? 1 : 0;
            }

            else
            {
                // Check if is a teacher
                var teacherDetails = _loginRepository.CheckTeacherDetails(email);
                if (teacherDetails.Count > 0)
                {
                    return DetailsChecker(email, hashedPassword, teacherDetails) == true ? 2 : 0;
                }

                else
                {
                    // Check if is a student
                    var studentDetails = _studentRepository.GetStudentLoginDetailsByEmail(email);
                    if (studentDetails.Count > 0)
                    {
                        return DetailsChecker(email, hashedPassword, studentDetails) == true ? 3 : 0;
                    } 
                }
            }

            return 0;
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

        // Encrypt password
        public string SHA512ComputeHash(string password)
        {
            // Create a salt
            var saltString = password.Replace(password.ElementAt(0), password.ElementAt(1));

            // Build the hashed value
            var hash = new StringBuilder();
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(saltString);
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            using (var hmac = new HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);

                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        public AdminModel GetAdminByEmail(string email)
        {
            var adminDetails = _loginRepository.GetAdminByEmail(email);

            return new AdminModel
            {
                Id = adminDetails.Id,
                FirstName = adminDetails.FirstName,
                LastName = adminDetails.LastName,
                Email = adminDetails.Email,
                Password = adminDetails.Password
            };
        }

        public TeacherModel GetTeacherByEmail(string email)
        {
            var teacherDetails = _loginRepository.GetTeacherByEmail(email);

            return new TeacherModel
            {
                Id = teacherDetails.Id,
                FirstName = teacherDetails.FirstName,
                LastName = teacherDetails.LastName,
                Email = teacherDetails.Email,
                Password = teacherDetails.Password,
                ClassId = teacherDetails.ClassId
            };
        }
    }
}
