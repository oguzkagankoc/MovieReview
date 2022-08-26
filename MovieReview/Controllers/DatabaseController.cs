using System.Text;
using DataAccess.Contexts;
using DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MovieReview.Controllers
{
    public class DatabaseController : Controller
    {
        public IActionResult Seed() // /database/seed
        {
            using (var dbcontext = new MovieContext())
            {
                var user = dbcontext.Users.ToList();
                dbcontext.Users.RemoveRange(user);

                var role = dbcontext.Roles.ToList();
                dbcontext.Roles.RemoveRange(role);

                var comment = dbcontext.Comments.ToList();
                dbcontext.Comments.RemoveRange(comment);

                var director = dbcontext.Directors.ToList();
                dbcontext.Directors.RemoveRange(director);

                var movie = dbcontext.Movies.ToList();
                dbcontext.Movies.RemoveRange(movie);

                var genre = dbcontext.Genres.ToList();
                dbcontext.Genres.RemoveRange(genre);

                var moviegenre = dbcontext.MovieGenres.ToList();
                dbcontext.MovieGenres.RemoveRange(moviegenre);

                dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Users', RESEED, 0)");
                dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Roles', RESEED, 0)");
                dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Movies', RESEED, 0)");
                dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Comments', RESEED, 0)");
                dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Directors', RESEED, 0)");
                dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('Genres', RESEED, 0)");
                //dbcontext.Database.ExecuteSqlRaw("dbcc CHECKIDENT ('MovieGenre', RESEED, 0)");

                dbcontext.Roles.Add(new Role()
                {
                    RoleName = "admin",
                    IsActive = true,
                    //Id = 1
                }
                );
                dbcontext.Roles.Add(new Role()
                {
                    RoleName = "user",
                    IsActive = true,
                    //Id = 2
                }
                );
                dbcontext.SaveChanges();

                dbcontext.Users.Add(new User()
                {
                    IsActive = true,
                    FirstName = "Oğuz Kağan",
                    LastName = "Koç",
                    Password = "122333",
                    UserName = "konix",
                    RoleId = 1
                });
                dbcontext.Users.Add(new User()
                {
                    IsActive = true,
                    FirstName = "Bilge Kağan",
                    LastName = "Koç",
                    Password = "122333",
                    UserName = "escepto",
                    RoleId = 2
                });
                dbcontext.SaveChanges();
                dbcontext.Add(new Genre()
                {
                    GenreDescription = "Associated with particular types of spectacle (e.g., explosions, chases, combat)",
                    GenreName = "Action film",
                    IsActive = true,
                    // Id = 1
                });
                dbcontext.Add(new Genre()
                {
                    GenreDescription = "Focused on emotions and defined by conflict, often looking to reality rather than sensationalism.",
                    GenreName = "Drama",
                    IsActive = true,
                    //  Id = 2
                });
                dbcontext.SaveChanges();


                dbcontext.Add(new Director()
                {
                    IsActive = true,
                    DirectorFirstName = "Christopher",
                    DirectorLastName = "Nolan ",
                    //  Id = 1
                });
                dbcontext.Add(new Director()
                {
                    IsActive = true,
                    DirectorFirstName = "Francis Ford",
                    DirectorLastName = "Coppola",
                    // Id = 2
                });
                dbcontext.SaveChanges();

                dbcontext.Add(new Movie()
                {
                    IsActive = true,
                    Title = "The Dark Knight",
                    Year = 2008,
                    DirectorId = 1,
                    //    Id = 1
                });
                dbcontext.Add(new Movie()
                {
                    IsActive = true,
                    Title = "The Godfather",
                    Year = 1972,
                    DirectorId = 2,
                    //    Id = 2
                });
                dbcontext.SaveChanges();
                dbcontext.Add(new MovieGenre()
                {
                    GenreId = 1,
                    MovieId = 1
                });
                dbcontext.Add(new MovieGenre()
                {
                    GenreId = 2,
                    MovieId = 2
                });
                dbcontext.SaveChanges();
                dbcontext.Add(new Comment()
                {
                    UserComment = "Confidently directed, dark, brooding, and packed with impressive action sequences and a complex story, The Dark Knight includes a career-defining turn from Heath Ledger as well as other Oscar worthy performances, TDK remains not only the best Batman movie, but comic book movie ever created.",
                    UserId = 1,
                    MovieId = 1,
                    AddedDateTime = DateTime.Now,
                    IsActive = true
                });
                dbcontext.Add(new Comment()
                {
                    UserComment = "Engrossing motion picture that features some of the finest editing, cinematography and performances ever. There is a wonderful theme of family that runs through this film and its later sequels. No one is truly judged. Love is unconditional. God is the one who truly judges. Easily, the word masterpiece describes this film, but that's been said by so many...Who am I to argue? Masterpiece is right on the money.",
                    UserId = 2,
                    MovieId = 2,
                    AddedDateTime = DateTime.Now,
                    IsActive = true
                });
                dbcontext.SaveChanges();
            }
            return Content("<label style=\"color:red;\"><b>İlk veriler oluşturuldu.</b></label>", "text/html", Encoding.UTF8);
        }
    }
}
