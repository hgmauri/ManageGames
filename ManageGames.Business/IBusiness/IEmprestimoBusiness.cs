using System;
using System.Collections.Generic;
using ManageGames.Domain.Entities;

namespace ManageGames.Business.IBusiness
{
    public interface IEmprestimoBusiness
    {
        Emprestimo Recuperar(Guid id);
        IEnumerable<Emprestimo> RecuperarDapper();
        IEnumerable<Emprestimo> RecuperarEmprestimos();
        void Salvar(Emprestimo emprestimo);
        void Alterar(Emprestimo emprestimo);
        void Deletar(Emprestimo emprestimo);
    }
}
