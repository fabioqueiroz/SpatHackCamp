using Microsoft.Extensions.Configuration;
using Rubrics.Data.Access.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Rubrics.Data.Access
{
    public class RubricsRepository : GenericRepository<Context>, IRubricsRepository, IDisposable
    {
        public Context RubricsContext { get => this.Context; }
        public RubricsRepository() : base()
        {

        }

        public RubricsRepository(IConfiguration configuration) : base()
        {
            this.Context = new Context(configuration);
        }

        protected virtual void Dispose()
        {
            this.Context.Dispose();
        }

        ~RubricsRepository()
        {
            this.Context.Dispose();
        }
    }
}
