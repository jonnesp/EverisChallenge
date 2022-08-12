using EverisChallenge.Business.Interfaces;
using EverisChallenge.Business.Models;
using EverisChallenge.Business.Notificacoes;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EverisChallenge.Service.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepo;
        private readonly ITelefoneRepository _telefoneRepo;
        private readonly INotificador _notificador;
        private readonly IConfiguration _configuration;

        public UsuarioService(IUsuarioRepository usuarioRepo, INotificador notificador, ITelefoneRepository telefoneRepo, IConfiguration configuration)
        {
            _usuarioRepo = usuarioRepo;
            _notificador = notificador;
            _telefoneRepo = telefoneRepo;
            _configuration = configuration;
        }

        public async Task<Usuario> Adicionar(Usuario user)
        {
            try
            {

                if (_usuarioRepo.EmailExists(user.Email))
                {
                    Notificar("E-mail já cadastrado.");
                    return null;
                }

                user.Token = TokenService.GerarToken(_configuration["AppSettings:Secret"]);


                await _usuarioRepo.Adicionar(user);



                return user;
            }
            catch (Exception e)
            {
                Notificar($"Um erro não esperado foi encontrado: {e.InnerException}");
                return null;
            }
        }

        public async Task<Usuario> AutenticarUsuario(string email, string senha)
        {
            try
            {
                if (!_usuarioRepo.EmailExists(email))
                {
                    Notificar("Usuário e / ou senha inválidos");
                    return null;
                }

                var user = _usuarioRepo.FindByEmail(email);

                if (!user.Senha.Equals(senha))
                {
                    Notificar("Usuário e / ou senha inválidos");
                    return null;
                }

                user.UltimoLogin = DateTime.Now;
                user.Token = TokenService.GerarToken(_configuration["AppSettings:Secret"]);

                await _usuarioRepo.Atualizar(user);

                return user;
            }

            catch(Exception e)
            {
                Notificar($"Ocorreu um erro não esperado: {e.Message}");
                return null;
            }
        }


        public async Task<Usuario> Buscar(Guid id, string token)
        {
            var user = await _usuarioRepo.ObterPorId(id);

            if (!RealizarValidacoes(user, token)) return null;
            
            var teste = DateTime.Now.Subtract(user.UltimoLogin).TotalMinutes;

            return user;

        }

        private void Notificar(string msg)
        {
            _notificador.Handle(new Notificacao(msg));
        }

        private bool RealizarValidacoes(Usuario user, string token)
        {
            if (user is null)
            {
                Notificar("Usuário não localizado.");
                return false;
            }
            if (!user.Token.Equals(token))
            {
                Notificar("Não Autorizado.");
                return false;
                
            }
            if (DateTime.Now.Subtract(user.UltimoLogin).TotalMinutes > 30)
            {
                Notificar("Sessão Inválida, favor gerar um novo token.");
                return false;
                
            }
            return true;
        }


    }
}
