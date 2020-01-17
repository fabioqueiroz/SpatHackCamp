using Rubrics.Data;
using Rubrics.Data.Access.RepositoryInterfaces;
using Rubrics.General.Business.Interfaces;
using Rubrics.General.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Business.Services
{
    public class TableGroupService : ITableGroupService
    {
        private readonly ITableGroupRepository _tableGroupRepository;
        public TableGroupService(ITableGroupRepository tableGroupRepository)
        {
            _tableGroupRepository = tableGroupRepository;
        }
        public void CreateNewTableGroup(TableGroupInDb newTableGroup)
        {
            var tableGroup = new TableGroup
            {
                Name = newTableGroup.Name,
                TeacherId = newTableGroup.TeacherId
            };

            _tableGroupRepository.AddNewTableGroup(tableGroup);
        }

        public List<Student> GetStudentsFromGroupId(int id)
        {
            //merge student data modal into view data
            List<Student> dataStudents = _tableGroupRepository.GetStudentsFromGroup(id);
           
            return dataStudents;
        }
    }
}
