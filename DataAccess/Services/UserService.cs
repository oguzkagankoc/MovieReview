using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.DataAccess.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public abstract class UserServiceBase : ServiceBase<User>
    {
        protected UserServiceBase(MovieContext dbContext) : base(dbContext)
        {
        }
    }

    public class UserService : UserServiceBase
    {
        public UserService(MovieContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<User> Query()
        {
            return base.Query().OrderBy(u => u.UserName).Select(u => new User
            {
                Id = 0,
                IsActive = false,
                FirstNameDisplay = null,
                LastNameDisplay = null,
                UserName = null,
                Password = null,
                FirstName = null,
                LastName = null,
                RoleId = null,
                Role = null,
                Comments = null
            });


        }

    }
}
