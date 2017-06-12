using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.Domain.Entities
{
    public class UserWallet
    {
        /// <summary>
        /// 钱包的Id
        /// </summary>
        [Key]
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
        /// 用户ID
        /// </summary>
        public string UserId { get; set; }
    }
}
