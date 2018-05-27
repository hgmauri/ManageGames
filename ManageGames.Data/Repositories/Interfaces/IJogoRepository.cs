using System;
using System.Collections.Generic;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.Repositories.Interfaces
{
    public interface IJogoRepository
    {
        Jogo Recuperar(Guid id);
        Jogo RecuperarPorNome(string nome);
        IEnumerable<Jogo> RecuperarDapper();
        IEnumerable<Jogo> RecuperarDisponiveis();
        void Salvar(Jogo jogo);
        void Alterar(Jogo jogo);
        void Deletar(Jogo jogo);
    }
}
