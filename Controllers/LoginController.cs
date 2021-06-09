using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIFHA_WEB.Models.ViewsModels;
using SIFHA_WEB.Models.Conexion;
using SIFHA_WEB.Models.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIFHA_WEB.Controllers
{

    public class LoginController : Controller
    {
        private readonly ApplicationDbContext Sifha_Context;

        public LoginController(ApplicationDbContext context)
        {
            Sifha_Context = context;
        }
        public IActionResult Login()
        {


            return View();
        }


        public ActionResult LoginUsuario(Usuario usuario)
        {
            List<Usuario> usu = Sifha_Context.Usuarios.Where(p => p.User == usuario.User && p.PassWord == usuario.PassWord).ToList();



            //List<Usuario> usuarios = Sifha_Context.Usuarios.Where(usuario.User ==  Find(usuario.User) && x.PassWord == Password).ToList();


            if (ModelState.IsValid)
            {
                if (usu.Count == 0)
                { 
                    return RedirectToAction("Login");
                }
                else
                {
                    HttpContext.Session.SetString("N_usuario", usu.First().NombreUsuario);
                    HttpContext.Session.SetInt32("Id_usuario", usu.First().Id);
                    return Redirect("~/Home/Index");
                }
               
            }

            return View("Login");


        }

        public ActionResult PerfilUser(int Id)
        {
            

            Usuario usuario2 = Sifha_Context.Usuarios.Where(x => x.Id == Id).FirstOrDefault();



            ApplicationViewsModels mold = new ApplicationViewsModels();

            mold.usuarioss = usuario2;

            return View(mold);


            //    var usuario1 = Sifha_Context.Usuarios;


            // var usu = Sifha_Context.Usuarios.Where(x => x.Id == Id);

            //    usuario = usu.First();

            //    return View(usuario);
            //}
        }

        [HttpGet]
        public ActionResult CrearUsuario()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult CrearUsuarioNuevo(Usuario usuario,string Nombre1,string Nombre2)
        {
            usuario.NombreUsuario = Nombre1 + " " + Nombre2;
            Sifha_Context.Add(usuario);
            Sifha_Context.SaveChanges();

            return Redirect("~/Home/Index");
        }
    }
}