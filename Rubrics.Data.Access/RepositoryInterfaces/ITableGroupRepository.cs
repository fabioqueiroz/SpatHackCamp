using System;
using System.Collections.Generic;
using System.Text;
using Rubrics.General.Models;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface ITableGroupRepository
    {
        void AddNewTableGroup(TableGroup tableGroup);
        List<Student> GetStudentsFromGroup(int id);
    }
}
