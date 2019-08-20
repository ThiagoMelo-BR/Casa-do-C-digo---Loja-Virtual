using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CasaDoCodigo.Repositories;

namespace CasaDoCodigo.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ICadastroRepository cadastroRepository;

        public ClienteController(ICadastroRepository cadastroRepository)
        {
            this.cadastroRepository = cadastroRepository;
        }

        public IActionResult Index()
        {
            return View(cadastroRepository.Listar());
        }

    }
}