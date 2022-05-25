using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Business.Notificacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Business.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly ITelefoneRepository _telefoneRepo;
        private readonly INotificador _notificador;

        public UsuarioService(IUsuarioRepository usuarioRepo, INotificador notificador, ITelefoneRepository telefoneRepo)
        {
            _usuarioRepo = usuarioRepo;
            _notificador = notificador;
            _telefoneRepo = telefoneRepo;
        }

        public async Task<Usuario> Adicionar(Usuario usuario, string token)
        {
            try
            {
                var emailExiste = _usuarioRepo.FindByEmailAsync(usuario.Email);

                if (_usuarioRepo.FindByEmailAsync(usuario.Email))
                {
                    Notificar("E-mail já cadastrado.");
                    return null;
                }
                usuario.Token = token;

                await _usuarioRepo.Adicionar(usuario);



                return usuario;
            }
            catch (Exception e)
            {
                Notificar($"Um erro não esperado foi encontrado: {e.InnerException}");
                return null;
            }
        }


        private void Notificar(string msg)
        {
            _notificador.Handle(new Notificacao(msg));
        }


    }
}
