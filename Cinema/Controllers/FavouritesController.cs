﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema
{
    public class FavouritesController : Controller
    {
        private readonly FavouritesServiceDb favService;

        public FavouritesController(FavouritesServiceDb favService)
        {
            this.favService = favService;
        }

        public ActionResult Index()
        {
            var ids = favService.GetAll();
            return View(ids);
        }

        //public ActionResult Add(int id, string? returnUrl)
        //{
        //    favService.Add(id);

        //    return returnUrl != null ?
        //        Redirect(returnUrl) :
        //        RedirectToAction("Index", "Home");
        //}
        [Authorize]
        public ActionResult Add(int id, string? returnUrl)
        {
           favService.Add(id);
            return returnUrl != null ? Redirect(returnUrl) : RedirectToAction("Index", "Home");
        }

        public ActionResult Remove(int id, string? returnUrl)
        {
            favService.Remove(id);

            return returnUrl != null ?
                Redirect(returnUrl) :
                RedirectToAction("Index", "Home");
        }
    }
}