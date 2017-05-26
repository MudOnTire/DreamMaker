using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;

namespace DreamMaker.Web.IdentityExtensions
{
    public class DmPasswordValidator : IIdentityValidator<String>
    {
        public int RequiredLength { get; set; }

        public DmPasswordValidator(int length)
        {
            RequiredLength = length;
        }

        public Task<IdentityResult> ValidateAsync(string item)
        {
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength)
            {
                return Task.FromResult(IdentityResult.Failed(String.Format("Password should be of length {0}", RequiredLength)));
            }
            string pattern = @"^[\w\d]{6,}$";
            if (!Regex.IsMatch(item, pattern))
            {
                return Task.FromResult(IdentityResult.Failed("Password should have one numeral and one special character"));
            }
            return Task.FromResult(IdentityResult.Success);
        }
    }
}