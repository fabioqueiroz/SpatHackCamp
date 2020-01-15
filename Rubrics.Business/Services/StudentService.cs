using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
namespace Rubrics.Business.Services
{
    public class StudentService : IStudentService
    {
        private IStudentRepository _repository;
        public StudentService(IStudentRepository repository)
        {
            _repository = repository;
        }

        public List<StudentFormModel> GetAllTheStudents()
        {
            var std = _repository.GetAllStudents();

            return std.Select(x => new StudentFormModel
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.Score

            }).ToList();
        }

        public List<JoinModel> GetTestJoinsUsingLinq()
        {
            var join = _repository.GetJoinsUsingLinq();

            ; return join.Select(x => new JoinModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.Score

            }).ToList();
        }
        public async Task<IEnumerable<JoinModel>> GetTestJoinsUsingDapper()
        {
            var result = await _repository.GetJoinsUsingDapper();

            return result.Select(x => new JoinModel
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Score = x.Score

            }).ToList();
        }

        public string CreateRandomPassord(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToLower();
            }

            return builder.ToString();
        }

        public void CreateNewStudent(StudentFormModel studentFormModel)
        {
            var student = new Student
            {
                FirstName = studentFormModel.FirstName,
                LastName = studentFormModel.LastName,
                Email = studentFormModel.Email,
                DOB = studentFormModel.DOB,
                Password = studentFormModel.Password,
                Address = studentFormModel.Address
            };

            _repository.RegisterNewStudent(student);
        }

        //public bool FindStudentLoginDetails(string email, string password)
        //{
        //    // Get the details from the db
        //    var loginDetails = _repository.GetStudentLoginDetailsByEmail(email);

        //    if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
        //    {
        //        if (loginDetails.Contains(email) && loginDetails.Contains(password))
        //        {
        //            return true;
        //        }
        //    }

        //    return false;
        //}

        public bool FindStudentLoginDetails(string email, string password)
        {
            // create a salt
            var saltPwd = CreatePasswordSalt(password);
            var sHA512ComputeHash = SHA512ComputeHash(password, saltPwd);

            // TODO: create method to hash the password 
            byte[] salt = new byte[64];

            var hashedPassword = Hash(password, salt);

            var conversion = Convert.ToBase64String(hashedPassword);

            var x = "";

            // Get the details from the db
            var loginDetails = _repository.GetStudentLoginDetailsByEmail(email);
   
            if (!string.IsNullOrWhiteSpace(email) && !string.IsNullOrWhiteSpace(password))
            {
                if (loginDetails.Contains(email) && loginDetails.Contains(password)) // change to loginDetails.Contains(hashedPassword)
                {
                    return true;
                } 
            }

            return false;
        }

        // encrypt password
        public byte[] Hash(string passwordToHash, byte[] salt)
        {
            byte[] hashString;

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                hmac.Key = salt;
                hashString = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwordToHash));

            }

            return hashString;
        }

        // other version 
        public string SHA512ComputeHash(string password, string saltString)
        {
            var hash = new StringBuilder(); 
            byte[] secretkeyBytes = Encoding.UTF8.GetBytes(saltString);
            byte[] inputBytes = Encoding.UTF8.GetBytes(password);
            using (var hmac = new System.Security.Cryptography.HMACSHA512(secretkeyBytes))
            {
                byte[] hashValue = hmac.ComputeHash(inputBytes);
                foreach (var theByte in hashValue)
                {
                    hash.Append(theByte.ToString("x2"));
                }
            }

            return hash.ToString();
        }

        // create a salt
        public string CreatePasswordSalt(string password)
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] buf = new byte[64];
            rng.GetBytes(buf);
            string salt = Convert.ToBase64String(buf);

            Rfc2898DeriveBytes deriver2898 = new Rfc2898DeriveBytes(password.Trim(), buf, 1000);
            string hash = Convert.ToBase64String(deriver2898.GetBytes(16));
            return salt + ':' + hash;
        }

        // check if the ecrypted value matches the input


    }
}
