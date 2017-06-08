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

        public UserWalletViewModel GetViewModel()
        {
            var currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var dbModel = _appContext.UserWallets.FirstOrDefault(w => w.UserId == currentUserId);
            if (dbModel == null)
            {
                int walletId = Create();
                dbModel = _appContext.UserWallets.FirstOrDefault(w => w.WalletId == walletId);
            }
            return _modelMapper.GetUserWalletViewModelFromEntity(dbModel);
        }
    }
}
