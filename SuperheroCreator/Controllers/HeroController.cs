using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SuperheroCreator.Models;

namespace SuperheroCreator.Controllers
{
    public class HeroController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

       //get view for main homepage
        public ActionResult Index()
        {
            return View(context.Heroes);

        }

        //get views for CRUD

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

        public ActionResult Details(int ID) //should show 1 hero in DB with all properties of model 
        {
            var hero = context.Heroes.Where(h => h.ID == ID).FirstOrDefault();
            return View(hero);
        }


        public ActionResult Details() //should show all heroes in DB with all properties of model
        {
            ViewBag.Hero = new SelectList(context.Heroes, "Name", "AlterEgo", "PrimaryAbility", "SecondaryAbility", "CatchPhrase");
            return View();
        }

        //need to do the posting of the actions now that views have been returned

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

        public ActionResult DeleteDBSide(int ID)
        {
            var hero = context.Heroes.Where(h => h.ID == ID).FirstOrDefault();
            context.Heroes.Remove(hero);
            return RedirectToAction("Index");

        }

    }
}