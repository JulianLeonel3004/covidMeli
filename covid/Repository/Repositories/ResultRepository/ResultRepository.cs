using Model.MasterModel;
using Persistence.Repositories.GenericRepository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.Repositories.ResultRepository
{
    public class ResultRepository : GenericRepository<Result>, IResultRepository
    {
        public ResultRepository(AplicationDbContext context) : base(context)
        {
        }
    }
}
