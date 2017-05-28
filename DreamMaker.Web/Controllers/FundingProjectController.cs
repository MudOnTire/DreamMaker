using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamMaker.Domain.Abstract;
using DreamMaker.UI.InputModels;
using DreamMaker.UI.ViewModels;

namespace DreamMaker.Web.Controllers
{
    public class FundingProjectController : Controller
    {
        private IFundingProjectRepository _fundingProjectRepository;

        public FundingProjectController(IFundingProjectRepository fundingProjectRepository)
        {
            _fundingProjectRepository = fundingProjectRepository;
        }

        [HttpGet]
        public ActionResult CreateFundingProject()
        {
            return View();
        }

        /// <summary>
        /// 创建众筹项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public ActionResult CreateFundingProject(CreateFundingProjectInputModel model)
        {
            int newProjectId = _fundingProjectRepository.Create(model);
            return RedirectToAction("Detail", new { projectId = newProjectId });
        }

        /// <summary>
        /// 项目详情
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public ActionResult Detail(int projectId)
        {
            var vm = _fundingProjectRepository.GetViewModel(projectId);
            return View(vm);
        }
        
        /// <summary>
        /// 首页的最新众筹项目
        /// </summary>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public ActionResult IndexLatestProjects(int pageSize)
        {
            var models = _fundingProjectRepository.LatestProjects(pageSize);
            return PartialView(models);
        }
    }
}