using AppCore.DataAccess.Results;
using AppCore.DataAccess.Results.Bases;
using AppCore.DataAccess.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public abstract class MovieServiceBase : ServiceBase<Movie>
    {
        protected MovieServiceBase(MovieContext dbContext) : base(dbContext)
        {
        }
    }

    public class MovieService : MovieServiceBase
    {
        public MovieService(MovieContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Movie> Query()
        {
            return base.Query().OrderBy(o => o.Title).Select(o => new Movie
            {
                Id = 0,
                IsActive = false,
                Title = null,
                Year = null,
                Director = null,
                DirectorId = null,
                Comments = null,
                MovieGenres = null
            });
        }

        public override Result Add(Movie entity, bool save = true)
        {
            if (_dbContext.Set<Movie>().Any(m => m.Title.ToLower() == entity.Title.ToLower().Trim()))
                return new ErrorResult("There are already registrations with this title!");
            return base.Add(entity, save);
        }
    }
}
