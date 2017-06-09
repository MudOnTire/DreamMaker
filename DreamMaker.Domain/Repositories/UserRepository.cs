using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.DBContext;
using DreamMaker.Domain.Entities;
using DreamMaker.Domain.ModelMapper;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DreamMaker.Domain.Repositories
{
    public class UserRepository: IUserRepository
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();

        private IModelMapper _modelMapper;

        public UserRepository(IModelMapper modelMapper)
        {
            _modelMapper = modelMapper;
        }

        public IEnumerable<ApplicationUser> Users
        {
            get
            {
                return _appContext.Users;
            }
        }

        /// <summary>
        /// 获取当前登录用户
        /// </summary>
        /// <returns></returns>
        public ApplicationUser GetCurrentUser()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var currentUser = _appContext.Users.FirstOrDefault(u => u.Id == currentUserId);
            return currentUser;
        }
    }
}
