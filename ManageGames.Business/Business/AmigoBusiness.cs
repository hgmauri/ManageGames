using System;
using System.Collections.Generic;
using ManageGames.Business.IBusiness;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Domain.Entities;

namespace ManageGames.Business.Business
{
    public class AmigoBusiness : IAmigoBusiness
    {
        private readonly IAmigoRepository _repository;

        public AmigoBusiness(IAmigoRepository repository)
        {
            _repository = repository;
        }

        public Amigo Recuperar(Guid id)
        {
            return _repository.Recuperar(id);
        }

        public Amigo RecuperarPorNome(string nome)
        {
            return _repository.RecuperarPorNome(nome);
        }

        public IEnumerable<Amigo> RecuperarDapper()
        {
            return _repository.RecuperarDapper();
        }

        public void Salvar(Amigo amigo)
        {
            _repository.Salvar(amigo);
        }

        public void Alterar(Amigo amigo)
        {
            _repository.Alterar(amigo);
        }

        public void Deletar(Amigo amigo)
        {
            _repository.Deletar(amigo);
        }
    }
}
