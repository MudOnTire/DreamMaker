using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.UI.ViewModels
{
    public class UserWalletViewModel
    {
        /// <summary>
        /// 钱包Id
        /// </summary>
        public int WalletId { get; set; }

        /// <summary>
        /// 账户余额
        /// </summary>
        public decimal CurrentBalance { get; set; }

        /// <summary>
        /// 阿里巴巴账户
        /// </summary>
        public string AlipayAccount { get; set; }

        /// <summary>
        /// 微信账户
        /// </summary>
        public string WeChatAccount { get; set; }

        /// <summary>
        /// 用户
        /// </summary>
        public UserViewModel Owner { get; set; }
    }
}
