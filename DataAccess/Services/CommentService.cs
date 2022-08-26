using System.Globalization;
using AppCore.DataAccess.Services.Bases;
using DataAccess.Contexts;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public abstract class CommentServiceBase : ServiceBase<Comment>
    {
        protected CommentServiceBase(MovieContext dbContext) : base(dbContext)
        {
        }
    }

    public class CommentService : CommentServiceBase
    {
        public CommentService(MovieContext dbContext) : base(dbContext)
        {
        }

        public override IQueryable<Comment> Query()
        {
            return base.Query().OrderBy(o => o.UserComment).Select(c => new Comment
            {
                //TODO
                Id = c.Id,
                AddedDateTime = c.AddedDateTime,
                AddedDateTimeDisplay = c.AddedDateTime.HasValue ? c.AddedDateTime.Value.ToString("dd.MM.yyyy",
                        new CultureInfo("tr-TR")) : "",
                UserComment = c.UserComment,
                
                IsActive = c.IsActive,
               // UserCommentDisplay = c.UserComment.HasValue ? c.UserComment.ToString() : "",
                
                UserId = null,
                User = null,
                MovieId = null,
                Movie = null,

            });
        }
    }
}
