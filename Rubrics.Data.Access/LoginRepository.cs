using Microsoft.Data.SqlClient;
using Rubrics.Data.Access.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Rubrics.Data.Access
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IRubricsRepository _repository;
        public LoginRepository(IRubricsRepository repository)
        {
            _repository = repository;
        }

        public List<string> CheckAdminDetails(string email)
        {
            var adminInfo = new List<string>();

            try
            {          
                var adminInIDb = _repository.GetSingle<Admin>(x => x.Email == email);

                if (adminInIDb != null)
                {
                    adminInfo.Add(adminInIDb.Email);
                    adminInfo.Add(adminInIDb.Password); 
                }
               
            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return adminInfo;
        }

        public Admin GetAdminByEmail(string email)
        {
            var admin = new Admin();

            try
            {
                var adminInIDb = _repository.GetSingle<Admin>(x => x.Email == email);

                if (adminInIDb != null)
                {
                    admin.Id = adminInIDb.Id;
                    admin.FirstName = adminInIDb.FirstName;
                    admin.LastName = adminInIDb.LastName;
                    admin.Email = adminInIDb.Email;
                    admin.Password = adminInIDb.Password;

                }

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return admin;
        }

        public List<string> CheckTeacherDetails(string email)
        {
            var teacherInfo = new List<string>();

            try
            {
                var teacherInIDb = _repository.GetSingle<Teacher>(x => x.Email == email);

                if (teacherInIDb != null)
                {
                    teacherInfo.Add(teacherInIDb.Email);
                    teacherInfo.Add(teacherInIDb.Password);
                }

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return teacherInfo;
        }

        public Teacher GetTeacherByEmail(string email)
        {
            var teacher = new Teacher();

            try
            {
                var teacherInIDb = _repository.GetSingle<Teacher>(x => x.Email == email);

                if (teacherInIDb != null)
                {
                    teacher.Id = teacherInIDb.Id;
                    teacher.FirstName = teacherInIDb.FirstName;
                    teacher.LastName = teacherInIDb.LastName;
                    teacher.Email = teacherInIDb.Email;
                    teacher.Password = teacherInIDb.Password;
                    teacher.ClassId = teacherInIDb.ClassId;
                }

            }
            catch (SqlException ex)
            {

                throw new Exception(ex.Message);
            }

            return teacher;
        }

    }
}
