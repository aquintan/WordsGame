using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordsGame.Data.Context;
using WordsGame.Data.Interfaces;
using WordsGame.Data.User;

namespace WordsGame.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext dbContext;

        public UserRepository()
        {
            this.dbContext = ApplicationDbContext.Create();
        }

        public IQueryable<IdentityUser> Users
        {
            get
            {
                return this.dbContext.Users;
            }
        }

        public IQueryable<IdentityRole> Roles
        {
            get
            {
                return this.dbContext.Roles;
            }
        }        
    }
}
