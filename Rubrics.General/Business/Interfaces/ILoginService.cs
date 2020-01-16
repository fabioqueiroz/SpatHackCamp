using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.General.Business.Interfaces
{
    public interface ILoginService
    {
        bool LoginValidation(string email, string password);
        bool DetailsChecker(string email, string password, List<string> detailsInDb);

    }
}
