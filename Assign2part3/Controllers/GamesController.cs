using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Assign2part3.Models;

namespace Assign2part3.Controllers
{
    public class GamesController : Controller
    {
    
            // private GameStoreHere db = new GameStoreHere();
            private IMockGamesRepository db;

            // default constructor - use the database / ef
            public GamesController()
            {
                this.db = new EFGamesRepository();
            }
            // unit test constructor - mock data comes in so don't use the database/ef
            public GamesController(IMockGamesRepository mockRepo)
            {
                this.db = mockRepo;
            }
            // GET: Games
            public ActionResult Index()
            {
                return View(db.Games.ToList());
            }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            // modify so it can work with ef or the mock repo
            //Game game = db.Games.Find(id);

            // new code to select single order using LINQ
            Game game = db.Games.SingleOrDefault(g => g.GameId == id);
            
            if (game == null)
            {
                return View("Error");
            }
            return View(game);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GameId,Game1,ReleaseDate,Country,Developer")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Save(game);
                return RedirectToAction("Index");
            }

            return View("Create", game);
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            Game game = db.Games.SingleOrDefault(g => g.GameId == id);
            if (game == null)
            {
                return View("Error");
            }
            return View("Delete", game);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GameId,Game1,ReleaseDate,Country,Developer")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Save(game);
                return RedirectToAction("Index");
            }
            return View("Edit", game);
        }

       // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return View("Error");
            }
            //Game game = db.Games.Find(id);
            Game game = db.Games.SingleOrDefault(g => g.GameId == id);
            if (game == null)
            {
                return View("Error");
            }
            return View(game);
        }

        //POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Game game = db.Games.Find(id);
            Game game = db.Games.SingleOrDefault(g => g.GameId == id);
            db.Delete(game);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        }
    }
