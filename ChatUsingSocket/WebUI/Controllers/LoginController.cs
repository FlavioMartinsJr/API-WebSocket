using Application.DTOs.Usuario;
using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System;
using System.Diagnostics;
using System.Net.WebSockets;
using System.Text;
using System.Threading;

namespace WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IUsuarioService _usuarioService;
        public LoginController(ILogger<LoginController> logger, IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logar([Bind("Nome,Senha")]string? Nome, string Senha)
        {

            if (ModelState.IsValid)
            {
                var user = await _usuarioService.BuscarUsuarioLogin(Nome!,Senha);
                if(user != null)
                {
                   
                    return RedirectToAction("Index", "Home", new {id=user.Id});
                }
            }
            return RedirectToAction("Index", "Login");
        }




    }
}
