using Microsoft.AspNetCore.Mvc;

namespace Cinema
{
    public class FavouritesController : Controller
    {
        private readonly FavouritesService favService;

        public FavouritesController(FavouritesService favService)
        {
            this.favService = favService;
        }

        public ActionResult Index()
        {
            var ids = favService.GetAll();
            return View(ids);
        }

        public ActionResult Add(int id)
        {
            favService.Add(id);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(int id)
        {
            favService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}