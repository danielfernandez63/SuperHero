using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SuperheroCreator.Models;

namespace SuperheroCreator.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public ActionResult Index()
        {
            // string currentUserId = User.Identity.GetUserId();
            ViewBag.BackgroundImage = "https://images3.alphacoders.com/212/212607.jpg";
            return View(context.Heroes);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Delete(int ID)  
        {
            var hero = context.Heroes.Where(h => h.ID == ID).FirstOrDefault();
            return View(hero);
        }

        public ActionResult Edit(int ID) 
        {
            var hero = context.Heroes.Where(h => h.ID == ID).FirstOrDefault();
            return View(hero);
        }

        public ActionResult Details(int ID)
        {
            var hero = context.Heroes.Where(h => h.ID == ID).FirstOrDefault();
            return View(hero);
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "Name,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")]Heroes Hero)
        {
            context.Heroes.Add(Hero);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,Name,AlterEgo,PrimaryAbility,SecondaryAbility,Catchphrase")]Heroes Hero)
        {
            var OGHero= context.Heroes.Where(h => h.ID == Hero.ID).FirstOrDefault();
            OGHero.Name = Hero.Name;
            OGHero.AlterEgo = Hero.AlterEgo;
            OGHero.PrimaryAbility = Hero.PrimaryAbility;
            OGHero.SecondaryAbility = Hero.SecondaryAbility;
            OGHero.CatchPhrase = Hero.CatchPhrase;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteDBSide(int ID)
        {
            var hero = context.Heroes.Find(ID);
            context.Heroes.Remove(hero);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


