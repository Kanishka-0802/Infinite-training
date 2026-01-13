using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Assessment_2.Models;
using Assessment_2.Repositories;

namespace Assessment_2.Controllers
{
    public class MovieController : Controller
    {
       
            private readonly IMovieRepository repos = new MovieRepository();

            public ActionResult Index()
            {
                return View(repos.GetAll());
            }

            public ActionResult Details(int id)
            {
                return View(repos.GetById(id));
            }

            [HttpGet]
            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create(Movie movie)
            {
                if (ModelState.IsValid)
                {
                    repos.Add(movie);
                    return RedirectToAction("Index");
                }
                return View(movie);
            }

            [HttpGet]
            public ActionResult Edit(int id)
            {
                return View(repos.GetById(id));
            }

            [HttpPost]
            public ActionResult Edit(Movie movie)
            {
                if (ModelState.IsValid)
                {
                    repos.Update(movie);
                    return RedirectToAction("Index");
                }
                return View(movie);
            }

            [HttpGet]
            public ActionResult Delete(int id)
            {
                return View(repos.GetById(id));
            }

            [HttpPost, ActionName("Delete")]
            public ActionResult DeleteConfirmed(int id)
            {
                repos.Delete(id);
                return RedirectToAction("Index");
            }

            public ActionResult ByYear(int year)
            {
                return View("Index", repos.GetmoviesByYear(year));
            }

            public ActionResult ByDirector(string director_Name)
            {
                return View("Index", repos.GetmoviesByDirector(director_Name));
            }
        }
    }

