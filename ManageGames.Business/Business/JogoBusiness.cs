using System;
using System.Collections.Generic;
using ManageGames.Business.IBusiness;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Domain.Entities;

namespace ManageGames.Business.Business
{
    public class JogoBusiness : IJogoBusiness
    {
        private readonly IJogoRepository _repository;
        private readonly IGeneroRepository _repositoryGenero;

        public JogoBusiness(IJogoRepository repository, IGeneroRepository repositoryGenero)
        {
            _repository = repository;
            _repositoryGenero = repositoryGenero;
        }

        public Jogo Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        public Jogo RecuperarPorNome(string nome)
        {
            return _repository.RecuperarPorNome(nome);
        }

        public IEnumerable<Jogo> RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        public IEnumerable<Jogo> RecuperarDisponiveis()
        {
            return _repository.RecuperarDisponiveis();
        }

        public void Salvar(Jogo jogo)
        {
            
            _repository.Salvar(jogo);
        }

        public void Alterar(Jogo jogo)
        {
            _repository.Alterar(jogo);
        }

        public void Deletar(Jogo jogo)
        {
            _repository.Deletar(jogo);
        }
    }
}
