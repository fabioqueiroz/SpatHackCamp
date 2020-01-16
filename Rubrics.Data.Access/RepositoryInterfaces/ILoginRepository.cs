using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface ILoginRepository
    {
        List<string> CheckAdminDetails(string email);
    }
}
