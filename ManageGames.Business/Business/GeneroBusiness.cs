using System;
using System.Collections.Generic;
using ManageGames.Business.IBusiness;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Domain.Entities;

namespace ManageGames.Business.Business
{
    public class GeneroBusiness : IGeneroBusiness
    {
        private readonly IGeneroRepository _repository;

        public GeneroBusiness(IGeneroRepository repository)
        {
            _repository = repository;
        }

        public Genero Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        public Genero RecuperarPorNome(string nome)
        {
            return _repository.RecuperarPorNome(nome);
        }

        public IEnumerable<Genero>  RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        public void Salvar(Genero genero)
        {
            _repository.Salvar(genero);
        }

        public void Alterar(Genero genero)
        {
            _repository.Alterar(genero);
        }

        public void Deletar(Genero genero)
        {
            _repository.Deletar(genero);
        }
    }
}
