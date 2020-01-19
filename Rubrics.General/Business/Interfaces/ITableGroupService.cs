using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Rubrics.Data;

namespace Rubrics.General.Business.Interfaces
{
    public interface ITableGroupService
    {
        void CreateNewTableGroup(TableGroupInDb newTableGroup);
        List<Student> GetStudentsFromGroupId(int id);
    }
}
