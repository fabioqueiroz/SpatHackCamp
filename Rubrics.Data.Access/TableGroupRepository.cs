using Rubrics.Data.Access.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data.Access
{
    public class TableGroupRepository : ITableGroupRepository
    {
        private readonly IRubricsRepository _repository;
        public TableGroupRepository(IRubricsRepository repository)
        {
            _repository = repository;
        }

        public void AddNewTableGroup(TableGroup tableGroup)
        {
            _repository.Add<TableGroup>(tableGroup);
            _repository.Commit();
        }
    }
}
