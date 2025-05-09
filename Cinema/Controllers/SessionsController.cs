using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Cinema.Data;
using Cinema.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Identity.UI.Services;

namespace Cinema.Controllers
{
    public class SessionsController : Controller
    {
        private readonly CinemaDbContext context;
        private readonly IEmailSender _emailSender;
        public SessionsController(CinemaDbContext context, IEmailSender emailSender)
        {
            this.context = context;
            _emailSender = emailSender;
        }

        // GET: Sessions
        public ActionResult Index()
        {
            var sessions = context.Sessions
                .Include(x => x.Film)  // Завантажуємо пов'язані дані про фільм
                .ToList();

            return View(sessions);
        }

        // GET: Create session
        [HttpGet]
        public ActionResult Create()
        {
            LoadFilms();  // Завантажуємо список фільмів
            return View();
        }

        // POST: Create session
        [HttpPost]
        public ActionResult Create(Session session)
        {
            if (!ModelState.IsValid)
            {
                LoadFilms();
                return View();
            }

            context.Sessions.Add(session);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Edit session
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var session = context.Sessions.Find(id);
            if (session == null) return NotFound();

            LoadFilms();
            return View(session);
        }

        // POST: Edit session
        [HttpPost]
        public ActionResult Edit(Session session)
        {
            if (!ModelState.IsValid)
            {
                LoadFilms();
                return View();
            }

            context.Sessions.Update(session);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Delete session
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var session = await context.Sessions.FindAsync(id);
            if (session == null) return NotFound();

            // Надсилаємо електронного листа
            await _emailSender.SendEmailAsync("vikajurchyk@gmail.com", "Deleting session",
                $"<h1>Session on deleting...</h1><p>Film: {session.Film.Name}, Hall: {session.Hall}, Time: {session.StartTime}</p>");

            return View(session);
        }

        // POST: Delete session
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            var session = context.Sessions.Find(id);
            if (session == null) return NotFound();

            context.Sessions.Remove(session);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        // GET: Details session
        public async Task<IActionResult> Details(int? id, string? returnUrl = null)
        {
            if (id == null) return NotFound();

            var session = await context.Sessions
                .Include(s => s.Film)  // Завантажуємо дані про фільм
                .FirstOrDefaultAsync(s => s.Id == id);

            if (session == null) return NotFound();

            ViewBag.ReturnUrl = returnUrl;
            return View(session);
        }

        // Завантажуємо список фільмів для вибору в DropDownList
        private void LoadFilms()
        {
            var films = new SelectList(context.FilmTeams4.ToList(), "Id", "Name");
            ViewBag.Films = films;
        }
    }
}
