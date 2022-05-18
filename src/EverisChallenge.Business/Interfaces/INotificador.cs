using EverisChallenge.Business.Notificacoes;
using System.Collections.Generic;

namespace EverisChallenge.Business.Interfaces
{
    public interface INotificador
    {
        bool TemNotificacao();
        List<Notificacao> ObterNotificacoes();
        void Handle(Notificacao notificacao);
    }
}
