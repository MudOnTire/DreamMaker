using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DreamMaker.Domain.Abstract;
using DreamMaker.UI.InputModels;

namespace DreamMaker.Web.Controllers
{
    public class FundingProjectController : Controller
    {
        private IFundingProjectRepository _fundingProjectRepository;

        public FundingProjectController(IFundingProjectRepository fundingProjectRepository)
        {
            _fundingProjectRepository = fundingProjectRepository;
        }

        /// <summary>
        /// 创建众筹项目
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult CreateFundingProject(CreateFundingProjectInputModel model)
        {
            int newProjectId = _fundingProjectRepository.Create(model);
            return RedirectToAction("Detail");
        }

        public ActionResult Detail(int projectId)
        {
            var vm = _fundingProjectRepository.GetViewModel(projectId);
            return View(vm);
        }
    }
}