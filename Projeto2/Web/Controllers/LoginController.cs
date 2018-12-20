using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Modelos;
using DAL;
using Web.Models;

namespace Web.Controllers
{
    public class LoginController : Controller
    {
       private readonly LojaDbContext _context;

       public LoginController(LojaDbContext context)
       {
           _context = context;
       }

        public IActionResult Index()
        {
            return View("Registro");
        }

        public IActionResult Criar(LoginViewModel login)
        {
            if(ModelState.IsValid){
                _context.Usuarios.Add(new Usuario{Username=login.Username,Password=login.Password});
                _context.SaveChanges();
                
                return RedirectToAction("Index","Usuario");
            }
            return View("Index");

        }

        public IActionResult Registro()
        {
            return View();
        }

        // public IActionResult Autenticacao(LoginViewModel loginViewModel)
        // {
        //     if(!ModelState.IsValid)
        //     {
        //         return View(loginViewModel);
        //     }

        //     if(db.ValidarLogin(loginViewModel as Usuario))
        //     {
                
        //         var identity = new ClaimsIdentity(
        //             new[]
        //             {
        //                 new Claim(ClaimTypes.NameIdentifier, loginViewModel.Id.ToString()),
        //                 new Claim(ClaimTypes.Name, loginViewModel.Username),
        //                 new Claim("Login", loginViewModel.Id.ToString())
        //             }, "ApplicationCookie"
        //         );

        //         Request.GetOwinContext().Authentication.SignIn(identity);
                
        //     }
        // }
    }
}