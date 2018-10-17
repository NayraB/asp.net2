using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Data;

namespace WebApplication4.Pages.Usuarios
{
    public class CadastrarModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public Usuario usuario { get; set; }

        static List<Usuario> usuarios = new List<Usuario>();

        public void OnGet()
        {
            if (usuario == null)
            {
                usuario = new Usuario();
            }
        }
        [HttpPost]
        public void OnPost()
        {
            /* IMPORTANTE
             * Model State é o estado das minhas variaveis que eu fiz binding. No caso, usuario
             * IsValid se não der nenhum erro de validação
             * IsValid não valida o formulário inteiro!!!
             * Ele serve para saber se a validação deu certo ou errado
             */
            if (ModelState.IsValid)
            {
                usuarios.Add(usuario);
            }
        }
    }
}