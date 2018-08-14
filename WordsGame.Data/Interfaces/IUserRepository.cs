using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordsGame.Data.Interfaces
{
    /// <summary>
    /// Defines the base operations for User data access
    /// </summary>
    public interface IUserRepository
    {
        IQueryable<IdentityUser> Users { get; }

        IQueryable<IdentityRole> Roles { get; }
    }
}