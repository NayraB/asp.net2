using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Business;

namespace WebApplication4.Pages.Mesas
{
    public class MinhasMesasModel : PageModel
    {
        IJogoService _jogoService;
        public MinhasMesasModel(IJogoService jogoService)
        {
            _jogoService = jogoService;
        }
        [BindProperty]
        [Required(ErrorMessage ="O nome da mesa é obrigatório")]
        public string NomeMesa { get; set; }
        public void OnGet()
        {
        }
        public void OnPost()
        {
            if (ModelState.IsValid)
            {
                int? usuarioId =
                   HttpContext.Session.GetInt32("usuarioId");
                if (!usuarioId.HasValue)
                {
                    throw new Exception("Erro de permissão");
                }
                _jogoService.MontarMesa(NomeMesa, usuarioId ?? 0);
            }
        }
    }
}