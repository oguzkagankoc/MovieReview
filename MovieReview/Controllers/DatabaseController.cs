//using DataAccess.Contexts;
//using DataAccess.Entities;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

//namespace MovieReview.Controllers
//{
//    public class DatabaseController : Controller
//    //{
//    //    public IActionResult Seed()
//    //    {
//    //        using (var dbcontext = new MovieContext())
//    //        {
//    //            var user = dbcontext.Users.ToList();
//    //            dbcontext.Users.RemoveRange(user);

//    //            var role = dbcontext.Roles.ToList();
//    //            dbcontext.Roles.RemoveRange(role);

//    //            var comment = dbcontext.Comments.ToList();
//    //            dbcontext.Comments.RemoveRange(comment);

//    //            var director = dbcontext.Directors.ToList();
//    //            dbcontext.Directors.RemoveRange(director);

//    //            var movie = dbcontext.Movies.ToList();
//    //            dbcontext.Movies.RemoveRange(movie);

//    //            dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Users', RESEED, 0)");
//    //            dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Roles', RESEED, 0)");
//    //            dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Movies', RESEED, 0)");
//    //            dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Comments', RESEED, 0)");
//    //            dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Directors', RESEED, 0)");

//    //            dbcontext.Roles.Add(new Role()
//    //            {
//    //                RoleName = "admin",
//    //                IsActive = true,
//    //                Users = new List<User>()
//    //                    {
//    //                        new User() 
//    //                        {
//    //                            IsActive = true,
//    //                            FirstName = "Oğuz Kağan",
//    //                            LastName = "Koç",
//    //                            Password = "122333",
//    //                            UserName = "konix",
//    //                    }}

//    //            }
//    //            );
//    //            dbcontext.Roles.Add(new Role()
//    //            {
//    //                RoleName = "user",
//    //                IsActive = true,
//    //            }
//    //            );
//    //            dbcontext.SaveChanges();

//    //            dbcontext.Users.Add(new User()
//    //            {
//    //                IsActive = true,
//    //                FirstName = "Oğuz Kağan",
//    //                LastName = "Koç",
//    //                Password = "122333",
//    //                UserName = "konix",
//    //                RoleId =
//    //            })

//    //        }

//    //    }
//    }
//}
