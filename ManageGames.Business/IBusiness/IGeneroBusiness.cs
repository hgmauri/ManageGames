using System;
using System.Collections.Generic;
using ManageGames.Domain.Entities;

namespace ManageGames.Business.IBusiness
{
    public interface IGeneroBusiness
    {
        Genero Recuperar(Guid id);
        Genero RecuperarPorNome(string nome);
        IEnumerable<Genero> RecuperarDapper();
        void Salvar(Genero genero);
        void Alterar(Genero genero);
        void Deletar(Genero genero);
    }
}
