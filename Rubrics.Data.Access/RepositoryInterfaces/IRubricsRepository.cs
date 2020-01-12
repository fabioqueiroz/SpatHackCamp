using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data.Access.RepositoryInterfaces
{
    public interface IRubricsRepository : IGenericRepository
    {
        Context RubricsContext { get; }
    }
}
