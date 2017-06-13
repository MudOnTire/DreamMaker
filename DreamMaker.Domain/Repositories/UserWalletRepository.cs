using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using DreamMaker.Domain.Abstract;
using DreamMaker.Domain.DBContext;
using DreamMaker.Domain.Entities;
using DreamMaker.Domain.ModelMapper;
using DreamMaker.UI.ViewModels;
using Microsoft.AspNet.Identity;

namespace DreamMaker.Domain.Repositories
{
    public class UserWalletRepository : IUserWalletRepository
    {
        private ApplicationDbContext _appContext = new ApplicationDbContext();

        private IModelMapper _modelMapper;
        private IUserRepository _userRepository;

        public UserWalletRepository(IModelMapper modelMapper, IUserRepository userRepository)
        {
            _modelMapper = modelMapper;
            _userRepository = userRepository;
        }

        public IEnumerable<UserWallet> UserWallets
        {
            get { return _appContext.UserWallets; }
        }

        /// <summary>
        /// 为当前用户创建钱包
        /// </summary>
        /// <returns></returns>
        public UserWallet Create()
        {
            var currentUser = _userRepository.GetCurrentUserInContext(_appContext);
            var newWallet = new UserWallet
            {
                User = currentUser,
                CurrentBalance = 0
            };
            currentUser.UserWallet = newWallet;
            _appContext.SaveChanges();
            return currentUser.UserWallet;
        }

        public UserWallet Create(string userId)
        {
            var user = _appContext.Users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                return null;
            }
            var newWallet = new UserWallet
            {
                User = user,
                CurrentBalance = 0
            };
            user.UserWallet = newWallet;
            _appContext.SaveChanges();
            return user.UserWallet;
        }

        /// <summary>
        /// 获取当前用户的钱包，如果当前用户没有钱包就创建
        /// </summary>
        /// <returns></returns>
        private UserWallet GetOrCreateWalletOfCurrentUser()
        {
            var currentUser = _userRepository.GetCurrentUserInContext(_appContext);
            var dbModel = currentUser.UserWallet;
            if (dbModel == null)
            {
                dbModel = Create();
            }
            return dbModel;
        }

        /// <summary>
        /// 获取管理员钱包
        /// </summary>
        /// <returns></returns>
        public UserWallet GetAdminWallet()
        {
            var user = _appContext.Users.FirstOrDefault(u => u.UserName == "DMAdmin");
            if (user == null)
            {
                return null;
            }
            else
            {
                var dbModel = user.UserWallet;
                if (dbModel == null)
                {
                    dbModel = Create(user.Id);
                }
                return dbModel;
            }
        }

        /// <summary>
        /// 获取当前用户钱包的entity
        /// </summary>
        /// <returns></returns>
        public UserWallet GetCurrentUserWallet()
        {
            var dbModel = GetOrCreateWalletOfCurrentUser();
            return dbModel;
        }

        /// <summary>
        /// 为当前用户的钱包充值
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Recharge(decimal amount)
        {
            var wallet = GetOrCreateWalletOfCurrentUser();
            wallet.CurrentBalance += amount;
            int result = _appContext.SaveChanges();
            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 当前用户消费
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Expense(decimal amount)
        {
            var wallet = GetOrCreateWalletOfCurrentUser();
            var adminWallet = GetAdminWallet();
            wallet.CurrentBalance -= amount;
            adminWallet.CurrentBalance += amount;
            int result = _appContext.SaveChanges();
            if (result == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 管理员向当前用户转账
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool TransferFromAdminToCurrentUser(decimal amount)
        {
            var userWallet = GetOrCreateWalletOfCurrentUser();
            var adminWallet = GetAdminWallet();
            userWallet.CurrentBalance += amount;
            adminWallet.CurrentBalance -= amount;
            int result = _appContext.SaveChanges();
            if (result == 2)
            {
                return true;
            }
            else
            {
                throw new Exception(string.Format("管理员向用户{0}转账{1}失败", userWallet.User.Id, amount));
            }
        }
    }
}
