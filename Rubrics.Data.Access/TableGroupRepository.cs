using Rubrics.Data.Access.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Rubrics.General.Models;

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

        //public List<Student> GetStudentsFromGroup(int id)
        //{
        //    var students = _repository.RubricsContext.Students.FromSqlRaw("SELECT * FROM dbo.Students WHERE GroupId = @id", 
        //        new SqlParameter("id",id)).ToList();
        //    return students;
        //}

        public List<Student> GetStudentsFromGroup(int id)
        {
            var students = _repository.All<Student>().Where(x => x.ClassId == id).ToList();
          
            return students;
        }
    }
}
