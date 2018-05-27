using System;
using System.Collections.Generic;
using ManageGames.Business.IBusiness;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Domain.Entities;

namespace ManageGames.Business.Business
{
    public class EmprestimoBusiness :IEmprestimoBusiness
    {
        private readonly IEmprestimoRepository _repository;
        private readonly IAmigoRepository _repositoryAmigo;
        private readonly IJogoRepository _repositoryJogo;

        public EmprestimoBusiness(IEmprestimoRepository repository, IAmigoRepository repositoryAmigo, IJogoRepository repositoryJogo)
        {
            _repository = repository;
            _repositoryAmigo = repositoryAmigo;
            _repositoryJogo = repositoryJogo;
        }

        public Emprestimo Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        public IEnumerable<Emprestimo> RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        public IEnumerable<Emprestimo> RecuperarEmprestimos()
        {
            return _repository.RecuperarEmprestimos();
        }

        public void Salvar(Emprestimo emprestimo)
        {
            _repository.Salvar(emprestimo);
        }

        public void Alterar(Emprestimo emprestimo)
        {
            _repository.Alterar(emprestimo);
        }

        public void Deletar(Emprestimo emprestimo)
        {
            _repository.Deletar(emprestimo);
        }
    }
}
