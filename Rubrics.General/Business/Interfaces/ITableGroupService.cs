using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.General.Business.Interfaces
{
    public interface ITableGroupService
    {
        void CreateNewTableGroup(TableGroupInDb newTableGroup);
    }
}
