using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Business;
using WebApplication4.Data;

namespace WebApplication4.Pages.Mesas
{
    public class BuscaModel : PageModel
    {
        IJogoService _jogoService;
        // Não preciso colocar o get set porque ele não é uma propriedade
        // que precisa ser acessada por alguém de fora
        public BuscaModel(IJogoService jogoService)
        { // construtor
            _jogoService = jogoService;
        }

        [BindProperty]
        [RegularExpression(@"\d{9}-\d{2}", ErrorMessage = "Cpf inválido!")]
        public string Cpf { get; set; }
        [BindProperty]
        public string NomeUsuario { get; set; }
        public List<Mesa> mesas { get; set; }

        public void OnGet()
        {
            mesas = new List<Mesa>();
        }
        public void OnPostBuscar()
        {
            if (ModelState.IsValid)
            {
                if (Cpf != null && Cpf.Length > 0)
                {
                    // busca por cpf, caso ele seja preenchido
                    mesas = _jogoService.ListarMesasDoUsuario(Cpf);
                }
                else if (NomeUsuario != null && NomeUsuario.Length > 0)
                {
                    // busca por Nome 
                    mesas = _jogoService.ListarMesasDoUsuarioPeloNome(NomeUsuario);
                }
                else
                {
                    ModelState.AddModelError("", "Preencha pelo menos um dos campos");
                    mesas = new List<Mesa>();
                }
            }
        }

        public ActionResult OnPostEntrar(int mesaId)
        {
            int? usuarioId =
                HttpContext.Session.GetInt32("usuarioId");
            if (!usuarioId.HasValue)
            {
                throw new Exception("Erro de permissão");
            }
            try
            {
                _jogoService.EntrarMesa(usuarioId ?? 0, mesaId);
                return RedirectToPage("MinhasMesas");
            }
            catch (JaEstaNaMesaException e)
            {
                ModelState.AddModelError("", "Usuário já está na mesa");
            }
            catch (MesaCheiaException e)
            {
                ModelState.AddModelError("", "Mesa está cheia");
            }
            if (Cpf != null && Cpf.Length > 0)
            {
                // busca por cpf, caso ele seja preenchido
                mesas = _jogoService.ListarMesasDoUsuario(Cpf);
            }
            else if (NomeUsuario != null && NomeUsuario.Length > 0)
            {
                // busca por Nome 
                mesas = _jogoService.ListarMesasDoUsuarioPeloNome(NomeUsuario);
            }
            return Page();
        }
    }
}