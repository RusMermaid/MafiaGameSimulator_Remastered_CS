using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Controllers;
using UI.Models;

namespace UI.Controllers
{
    public class JoueurController : Controller
    {

        public void Session_OnEnd()
        {
            throw new Exception("Session timed OUT !");
        }

        [HttpPost]
        public ActionResult LogIn(string pseudo, string mdp)
        {
            JoueurDto jDto = UCCJoueur.Instance.ConnexionJoueur(pseudo, mdp);

            if (jDto == null)
            {
                TempData["error"] = "Erreur de login ou mot de passe";
                return RedirectToAction("Index", new { controller = "Index" });
            }

            Session.Add("user",jDto);
            Session.Timeout = 40;

            return RedirectToAction("Index", "Partie");
        }

        public ActionResult LogOut()
        {
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", new { controller = "Index" });
        }

        public ViewResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserModel j)
        {
            bool res = UCCJoueur.Instance.InscriptionJoueur(j.Pseudo, j.Mdp);
            if (!res)
            {
                ViewData["errorMessage"] = "Erreur lors de l'inscription du joueur";
                return View();
            }
            else {
                return RedirectToAction("ConfirmRegistration");
            }
        }

        public ViewResult ConfirmRegistration()
        {
            return View();
        }
    }
}