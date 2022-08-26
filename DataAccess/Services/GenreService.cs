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

    public abstract class GenreServiceBase : ServiceBase<Genre>
    {
        protected GenreServiceBase(MovieContext dbContext) : base(dbContext)
        {
        }
    }

    public class GenreService : GenreServiceBase
    {
        public GenreService(MovieContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Genre> Query()
        {
            return base.Query().OrderBy(o => o.GenreName).Select(o => new Genre
            {
                Id = 0,
                IsActive = false,
                GenreNameDisplay = null,
                GenreDescriptionDisplay = null,
                GenreName = null,
                GenreDescription = null,
                MovieGenres = null
            });
        }
    }
}
