using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Data;
using WebApplication4.Models;

namespace WebApplication4.Business
{
    public class JogoService : IJogoService
    {
        WebApplication4Context _context;
        public JogoService(WebApplication4Context context)
        {
            _context = context;
        }
        public List<Mesa> ListarMesasDoUsuario(string cpf)
        { // buscar pelo CPF do usuário
            Usuario usuario = _context.Usuario
                .Include(u => u.MesasUsuarios)
                .ThenInclude(mu => mu.Mesa)
                .ThenInclude(m => m.MesasUsuarios)
                .ThenInclude(mu2 => mu2.Usuario)
                .Where(u => u.Cpf == cpf).FirstOrDefault();
            List<Mesa> mesas = new List<Mesa>();
            if (usuario != null && usuario.MesasUsuarios != null)
            {
                foreach (MesaUsuario mu in usuario.MesasUsuarios)
                {
                    mesas.Add(mu.Mesa);
                }
            }
            return mesas;
        }
        public List<Mesa> ListarMesasDoUsuarioPeloNome(string nome)
        { // buscar pelo CPF do usuário
            Usuario usuario = _context.Usuario
                .Include(u => u.MesasUsuarios)
                .ThenInclude(mu => mu.Mesa)
                .ThenInclude(m => m.MesasUsuarios)
                .ThenInclude(mu2 => mu2.Usuario)
                .Where(u => u.Nome.Contains(nome)).FirstOrDefault();
            List<Mesa> mesas = new List<Mesa>();
            if (usuario != null && usuario.MesasUsuarios != null)
            {
                foreach (MesaUsuario mu in usuario.MesasUsuarios)
                {
                    mesas.Add(mu.Mesa);
                }
            }
            return mesas;
        }
        public List<Mesa> ListarMesa(int usuarioId)
        {
            List<MesaUsuario> mesasUsuarios =
                _context.MesasUsuarios
                .Include(mu => mu.Mesa)
                .Include(mu => mu.Usuario)
                .Where(mu => mu.UsuarioId == usuarioId).ToList();
            List<Mesa> mesas = new List<Mesa>();
            foreach(MesaUsuario mu in mesasUsuarios)
            {
                mesas.Add(mu.Mesa);
            }
            return mesas;
        }
        public void MontarMesa(string nome, int usuarioId)
        {
            Mesa mesa = new Mesa { Nome = nome };
            MesaUsuario mesaUsuario = new MesaUsuario
            {
                UsuarioId = usuarioId,
                Mesa = mesa
            };
            _context.MesasUsuarios.Add(mesaUsuario);
            _context.SaveChanges();
        }
    }
    public interface IJogoService
    {
        List<Mesa> ListarMesa(int usuarioId);
        List<Mesa> ListarMesasDoUsuario(string cpf);
        List<Mesa> ListarMesasDoUsuarioPeloNome(string nome);
        void MontarMesa(string nome, int usuarioId);
    }
}
