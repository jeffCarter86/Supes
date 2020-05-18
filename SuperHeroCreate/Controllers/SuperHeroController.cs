using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroCreate.Data;
using SuperHeroCreate.Models;

namespace SuperHero_Project.Controllers
{
    public class SuperHeroController : Controller
    {
        private ApplicationDbContext _context;
        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: SuperHero
        public ActionResult Index()
        {
            var superHeroes = _context.SuperHeroes.ToList();
            return View(superHeroes);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            var superHero = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superHero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.SuperHeroes.Add(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var superHero = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();

            return View(superHero);
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SuperHero superHero)
        {
            try
            {
                // TODO: Add update logic here

                var superheroedit = _context.SuperHeroes.Where(s => s.Id == superHero.Id).SingleOrDefault();
                superheroedit.Name = superHero.Name;
                superheroedit.AlterEgoName = superHero.AlterEgoName;
                superheroedit.PrimaryAbility = superHero.PrimaryAbility;
                superheroedit.SecondaryAbility = superHero.SecondaryAbility;
                superheroedit.CatchPhrase = superHero.CatchPhrase;
                _context.SaveChanges();


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            var superHero = _context.SuperHeroes.Where(s => s.Id == id).SingleOrDefault();
            return View(superHero);
        }

        // POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here
                _context.SuperHeroes.Remove(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
