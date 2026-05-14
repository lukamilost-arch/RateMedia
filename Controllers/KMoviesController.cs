using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RateMedia.Data;
using RateMedia.Models;
using System.Threading.Tasks;

namespace RateMedia.Controllers
{ 
    public class KMoviesController : Controller
    {
        private readonly RateMediaDb _rateMediaDb;
        private readonly UserManager<User> _userManager;

        public KMoviesController(RateMediaDb rateMediaDb, UserManager<User> userManager)
        {
            _rateMediaDb = rateMediaDb;
            _userManager = userManager;
        }

        private bool verifyUser()
        {
            return User.Identity != null && User.Identity.IsAuthenticated;
        }

        private Rating createNewRating(int movieId, string userId, int value)
        {
            return Rating.newRating(movieId, userId, value);
        }
        public async Task<IActionResult> Index()
        {
            var films = await _rateMediaDb.Movies
                                          .AsNoTracking()
                                          .ToListAsync();
            return View(films);
        }
        public async Task<IActionResult> Details(int id)
        {
            var movie = await _rateMediaDb.Movies
                                          .Include(m => m.Ratings)
                                          .FirstOrDefaultAsync(m => m.Id == id);

            if (movie == null)
                return NotFound();

            movie.recalculateAverage();

            return View("ZMUserRatesMovie", movie);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> rate(int movieId, int value)
        {
            if (!verifyUser())
            {
                TempData["Error"] = "Za ocenjevanje se morate prijaviti v sistem.";
                return RedirectToAction("Details", new { id = movieId });
            }

            if (value < 1 || value > 10)
            {
                TempData["Error"] = "Ocena mora biti med 1 in 10.";
                return RedirectToAction("Details", new { id = movieId });
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                TempData["Error"] = "Napaka pri pridobivanju uporabnika.";
                return RedirectToAction("Details", new { id = movieId });
            }

            bool alreadyRated = await _rateMediaDb.Ratings
                .AnyAsync(r => r.MovieId == movieId && r.UserId == currentUser.Id);
            if (alreadyRated)
            {
                TempData["Error"] = "Film ste že ocenili.";
                return RedirectToAction("Details", new { id = movieId });
            }

            Rating ratingObject = createNewRating(movieId, currentUser.Id, value);

            var movie = await _rateMediaDb.Movies
                                          .Include(m => m.Ratings)
                                          .FirstOrDefaultAsync(m => m.Id == movieId);
            if (movie == null) return NotFound();

            movie.Ratings.Add(ratingObject);
            movie.RatingCount++;

            movie.recalculateAverage();

            _rateMediaDb.Ratings.Add(ratingObject);
            await _rateMediaDb.SaveChangesAsync();
            TempData["Success"] = "Vaša ocena je bila uspešno oddana!";
            return RedirectToAction("Details", new { id = movieId });
        }
    }
}