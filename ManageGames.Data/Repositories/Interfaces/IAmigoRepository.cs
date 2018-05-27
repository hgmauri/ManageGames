using System;
using System.Collections.Generic;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.Repositories.Interfaces
{
    public interface IAmigoRepository
    {
        Amigo Recuperar(Guid id);
        Amigo RecuperarPorNome(string nome);
        IEnumerable<Amigo> RecuperarDapper();
        void Salvar(Amigo amigo);
        void Alterar(Amigo amigo);
        void Deletar(Amigo amigo);
    }
}
