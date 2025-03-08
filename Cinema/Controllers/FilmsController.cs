using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using System.Numerics;
using Cinema.Entities;

namespace Cinema.Controllers
{
    public class FilmsController : Controller
    {
        private readonly CinemaDbContext context;

        public FilmsController()
        {
            context = new CinemaDbContext();
        }

        // GET: 
        public ActionResult Index()
        {
            var films = context.FilmTeams
                .Include(x => x.Actors)
                .ToList();

            return View(films);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Film film)
        {
            if (!ModelState.IsValid)
                return View();

            context.FilmTeams.Add(film);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        

        public ActionResult Details(int id)
        {
            var film = context.FilmTeams
                .Include(x => x.Actors)
                .FirstOrDefault(x => x.Id == id);

            if (film == null) return NotFound();

            return View(film);
        }
        public ActionResult Delete(int id)
        {
            var film = context.FilmTeams.Find(id);
            if (film == null) return NotFound();

            context.FilmTeams.Remove(film);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}