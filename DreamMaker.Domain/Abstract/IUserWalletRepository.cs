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

        UserWallet Create();

        UserWallet GetCurrentUserWallet();

        UserWallet GetAdminWallet();

        bool Recharge(decimal amount);

        bool Expense(decimal amount);

        bool TransferFromAdminToCurrentUser(decimal amount);
    }
}
