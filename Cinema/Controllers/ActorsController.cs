using Cinema.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    public class ActorsController : Controller
    {

        private readonly CinemaDbContext context;

        public ActorsController()
        {
            context = new CinemaDbContext();
        }

        // GET: 
        public ActionResult Index()
        {
            var actors = context.CinemaActors
                .Include(x => x.Film)
                .ToList();

            return View(actors);
        }

        public ActionResult Delete(int id)
        {
            var player = context.CinemaActors.Find(id);
            if (player == null) return NotFound();

            context.CinemaActors.Remove();
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
