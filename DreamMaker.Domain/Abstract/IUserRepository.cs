using DreamMaker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamMaker.Domain.Abstract
{
    public interface IUserRepository
    {
        IEnumerable<ApplicationUser> Users { get; }

        ApplicationUser GetCurrentUser();
    }
}
