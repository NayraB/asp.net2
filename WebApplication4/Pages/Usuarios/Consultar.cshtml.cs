using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication4.Data;

namespace WebApplication4.Pages.Usuarios
{
    public class ConsultarModel : PageModel
    {
        public void OnGet()
        {

        }
        [HttpPost]
            public void OnPost(string cpf)
        {
            List<Usuario> usuarios = CadastrarModel.usuarios;
            foreach (Usuario u in usuarios)
            {
                if (cpf.Equals(u.Cpf))
                {
                    ViewData["usuario"] = u;
                }
            }
        }
    }
}