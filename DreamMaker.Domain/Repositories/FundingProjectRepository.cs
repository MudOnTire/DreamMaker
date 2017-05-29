using System.Collections.Generic;
using System.Linq;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.InputModels;
using DreamMaker.UI.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web;
using System;
using DreamMaker.Domain.ModelMapper;

namespace DreamMaker.Domain.Repositories
{
    public class FundingProjectRepository : IFundingProjectRepository
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();
        private IModelMapper _modelMapper;

        public FundingProjectRepository(IModelMapper modelMapper)
        {
            _modelMapper = modelMapper;
        }

        public IEnumerable<FundingProject> FundingProjects
        {
            get { return _appContext.FundingProjects; }
        }

        /// <summary>
        /// 创建一个新的众筹项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public int Create(CreateFundingProjectInputModel model)
        {
            var newProject = new FundingProject
            {
                CreatorId = HttpContext.Current.User.Identity.GetUserId(),
                ProjectName = model.ProjectName,
                ProjectDescription = model.ProjectDescription,
                CreateTime = DateTime.Now
            };
            var addedProject = _appContext.FundingProjects.Add(newProject);
            _appContext.SaveChanges();
            return addedProject.ProjectId;
        }

        /// <summary>
        /// 获取众筹项目的ViewModel
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public FundingProjectViewModel GetViewModel(int projectId)
        {
            var dbModel = FundingProjects.FirstOrDefault(p => p.ProjectId == projectId);
            return _modelMapper.GetFundingProjectViewModelFromEntity(dbModel);
        }

        /// <summary>
        /// 获取最新的项目
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<FundingProjectViewModel> LatestProjects(int pageSize)
        {
            var dbModels = FundingProjects.OrderByDescending(p => p.CreateTime).Take(pageSize);
            var viewModels = dbModels.Select(m => _modelMapper.GetFundingProjectViewModelFromEntity(m));
            return viewModels;
        }
    }
}
