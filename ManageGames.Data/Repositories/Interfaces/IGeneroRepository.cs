using System;
using System.Collections.Generic;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.Repositories.Interfaces
{
    public interface IGeneroRepository
    {
        Genero Recuperar(Guid id);
        Genero RecuperarPorNome(string nome);
        IEnumerable<Genero> RecuperarDapper();
        void Salvar(Genero genero);
        void Alterar(Genero genero);
        void Deletar(Genero genero);
    }
}
