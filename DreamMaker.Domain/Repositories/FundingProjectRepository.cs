using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Concrete;
using DreamMaker.Domain.Entities;

namespace DreamMaker.Domain.Repositories
{
    public class FundingProjectRepository : IFundingProjectRepository
    {
        private EfDbContext _context = new EfDbContext();

        IEnumerable<FundingProject> IFundingProjectRepository.FundingProjects
        {
            get
            {
                return _context.FundingProjects;
            }
        }
    }
}
