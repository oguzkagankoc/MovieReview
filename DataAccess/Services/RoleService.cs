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
    public abstract class RoleServiceBase : ServiceBase<Role>
    {
        protected RoleServiceBase(MovieContext dbContext) : base(dbContext)
        {
        }
    }

    public class RoleService : RoleServiceBase
    {
        public RoleService(MovieContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Role> Query()
        {
            return base.Query().OrderBy(r => r.RoleName).Select(r => new Role
            {
                Id = 0,
                IsActive = false,
                RoleName = null,
                Users = null
            });
        }
    }
}
