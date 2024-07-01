using Application.DTOs.Chat;
using Application.DTOs.Usuario;
using Application.Interfaces;
using Application.Services;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.Net.WebSockets;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsuarioService _usuarioService;
        public HomeController(ILogger<HomeController> logger, IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
            _logger = logger;
        }

        
        public async Task<IActionResult> Logout(int Id)
        {
            var user = await _usuarioService.AtualizarUsuarioLogout(Id);

            if(user != null)
            {
                return RedirectToAction("Index", "Login");
            }
            
            return View();
        }

        public IActionResult Chat()
        {
            return View();
        }

        public async Task<IActionResult> Index(int Id)
        {
            var user = await _usuarioService.BuscarUsuarioPorId((int)Id!);

            if (user == null || user.Ativo == false)
            {
                return RedirectToAction("Index", "Login");
            }

            ViewData["Id"] = user.Id;
            ViewData["Nome"] = user.Nome;
            ViewData["Img"] = user.Img;
            ViewData["DataAlteracao"] = user.DataAlteracao;

            var usuarioBuscado = await _usuarioService.BuscarUsuario();
            return View(usuarioBuscado);
        }

        [HttpGet("/api/ListaUser")]
        public JsonResult ListaUser(string text)
        {
            var usuarioBuscado = _usuarioService.BuscarUsuarioPorTermo(text);

            return Json(new { usuarioBuscado });
        }

        [HttpGet("/api/ListaUserById")]
        public JsonResult ListaUser(int id)
        {
            var usuarioBuscado = _usuarioService.BuscarUsuarioPorId(id);

            return Json(new { usuarioBuscado });
        }
        [HttpPost("/api/SendMenssage")]
        public JsonResult SendMenssage(string menssage, int userRecebidoId, int userEnviadoId)
        {
            ChatPost chatPost = new ChatPost();
            chatPost.UsuarioRecebidoId = userRecebidoId;
            chatPost.UsuarioEnviadoId = userEnviadoId;
            chatPost.MensagemEnviada = menssage;
            chatPost.MensagemRecebida = menssage;
            var result = _usuarioService.AdicionarChat(chatPost);

            return Json(new { result });
        }

        [HttpGet("/api/ListaChatByUsersId")]
        public JsonResult ListaChatByUsersId(int userRecebidoId,int userEnviadoId)
        {
            var chatBuscado = _usuarioService.BuscarChat(userRecebidoId, userEnviadoId);

            return Json(new { chatBuscado });
        }
    }
}
