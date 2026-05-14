using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RateMedia.Models;

namespace RateMedia.Data
{
    public class RateMediaDb : IdentityDbContext<User>
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }

        public RateMediaDb(DbContextOptions<RateMediaDb> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Movie>().HasData(
                new Movie { Id = 1, Title = "The Shawshank Redemption", Director = "Frank Darabont", Year = 1994, Url = "https://www.themoviedb.org/t/p/w600_and_h900_face/9cqNxx0GxF0bflZmeSMuL5tnGzr.jpg", Description = "A wrongfully convicted banker forms a close friendship with a hardened convict over a quarter century while retaining his humanity through simple acts of compassion.", ImdbRating = 9.3, AverageRating = 0.0, RatingCount = 0 },
                new Movie { Id = 2, Title = "The Godfather", Director = "Francis Ford Coppola", Year = 1972, Url = "https://image.tmdb.org/t/p/w600_and_h900_face/3bhkrj58Vtu7enYsRolD1fZdja1.jpg", Description = "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.", ImdbRating = 9.2, AverageRating = 0.0, RatingCount = 0 },
                new Movie { Id = 3, Title = "The Dark Knight", Director = "Christopher Nolan", Year = 2008, Url = "https://www.themoviedb.org/t/p/w600_and_h900_face/qJ2tW6WMUDux911r6m7haRef0WH.jpg", Description = "When a menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman, James Gordon and Harvey Dent must work together to put an end to the madness.", ImdbRating = 9.0, AverageRating = 0.0, RatingCount = 0 },
                new Movie { Id = 4, Title = "Pulp Fiction", Director = "Quentin Tarantino", Year = 1994, Url = "https://www.themoviedb.org/t/p/w600_and_h900_face/vQWk5YBFWF4bZaofAbv0tShwBvQ.jpg", Description = "The lives of two mob hitmen, a boxer, a gangster and his wife, and a pair of diner bandits intertwine in four tales of violence and redemption.", ImdbRating = 8.9, AverageRating = 0.0, RatingCount = 0 },
                new Movie { Id = 5, Title = "Inception", Director = "Christopher Nolan", Year = 2010, Url = "https://image.tmdb.org/t/p/original/5vqYbsRyfzuF1X5yXq4I8ju3Xwc.jpg", Description = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a CEO, but his tragic past may doom the project and his team to disaster.", ImdbRating = 8.8, AverageRating = 0.0, RatingCount = 0 }
            );
        }
    }
}