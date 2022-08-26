using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore.DataAccess.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services
{

    public abstract class DirectorServiceBase : ServiceBase<Director>
    {
        protected DirectorServiceBase(MovieContext dbContext) : base(dbContext)
        {
        }
    }

    public class DirectorService : DirectorServiceBase
    {
        public DirectorService(MovieContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Director> Query()
        {
            return base.Query().OrderBy(o => o.DirectorFirstName).Select(c => new Director
            {
                Id = 0,
                IsActive = false,
                DirectorFirstNameDisplay = null,
                DirectorLastNameDisplay = null,
                DirectorFirstName = null,
                DirectorLastName = null,
                Movies = null
            });
        }
    }
}
