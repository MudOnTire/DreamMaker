using System;
using System.Collections.Generic;
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

        public UserWalletRepository(IModelMapper modelMapper)
        {
            _modelMapper = modelMapper;
        }

        public IEnumerable<UserWallet> UserWallets
        {
            get { return _appContext.UserWallets; }
        }

        /// <summary>
        /// 为当前用户创建钱包
        /// </summary>
        /// <returns></returns>
        public int Create()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var newWallet = new UserWallet
            {
                UserId = currentUserId,
                CurrentBalance = 0
            };
            var addedWallet = _appContext.UserWallets.Add(newWallet);
            _appContext.SaveChanges();
            return addedWallet.WalletId;
        }

        /// <summary>
        /// 获取当前用户的钱包，如果当前用户没有钱包就创建
        /// </summary>
        /// <returns></returns>
        public UserWallet GetOrCreateWalletOfCurrentUser()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var dbModel = _appContext.UserWallets.FirstOrDefault(w => w.UserId == currentUserId);
            if (dbModel == null)
            {
                int walletId = Create();
                dbModel = _appContext.UserWallets.FirstOrDefault(w => w.WalletId == walletId);
            }
            return dbModel;
        }

        /// <summary>
        /// 根据用户名获取用户的钱包
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public UserWallet GetOrCreateWalletOfUser(string userName)
        {
            var user = _appContext.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
            {
                return null;
            }
            else
            {
                var dbModel = _appContext.UserWallets.FirstOrDefault(w => w.UserId == user.Id);
                if (dbModel == null)
                {
                    int walletId = Create();
                    dbModel = _appContext.UserWallets.FirstOrDefault(w => w.WalletId == walletId);
                }
                return dbModel;
            }
        }

        /// <summary>
        /// 获取当前用户钱包的ViewModel
        /// </summary>
        /// <returns></returns>
        public UserWalletViewModel GetCurrentUserWalletViewModel()
        {
            var dbModel = GetOrCreateWalletOfCurrentUser();
            return _modelMapper.GetUserWalletViewModelFromEntity(dbModel);
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
        /// 消费
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool Expense(decimal amount)
        {
            var wallet = GetOrCreateWalletOfCurrentUser();
            var adminWallet = GetOrCreateWalletOfUser("DMAdmin");
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
    }
}
