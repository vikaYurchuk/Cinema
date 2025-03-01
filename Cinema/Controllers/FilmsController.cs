using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;

namespace Cinema.Controllers
{
    public class FilmsController : Controller
    {
        private readonly CinemaDbContext context;

        public FilmsController()
        {
            context = new CinemaDbContext();
        }

        // GET: FilmsController
        public ActionResult Index()
        {
            var films = context.FilmTeams
                .Include(x => x.Actors)
                .ToList();

            return View(films);
        }

        public ActionResult Delete(int id)
        {
            var player = context.FilmTeams.Find(id);
            if (player == null) return NotFound();

            context.FilmTeams.Remove();
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}