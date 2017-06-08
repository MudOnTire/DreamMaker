using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DreamMaker.Domain.Entities;
using DreamMaker.UI.ViewModels;

namespace DreamMaker.Domain.Abstract
{
    public interface IUserWalletRepository
    {
        IEnumerable<UserWallet> UserWallets { get; }

        int Create();

        UserWalletViewModel GetViewModel();

        bool Recharge(decimal amount);
    }
}
