using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.InputModels;
using DreamMaker.UI.ViewModels;

namespace DreamMaker.Domain.Abstract
{
    public interface IFundingProjectRepository
    {
        IEnumerable<FundingProject> FundingProjects { get; }

        int Create(CreateFundingProjectInputModel model);

        FundingProjectViewModel GetViewModel(int projectId);
    }
}
