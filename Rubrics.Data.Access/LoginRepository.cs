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

        // TODO: check teacher details

        
    }
}
