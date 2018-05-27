using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using ManageGames.Data.Contexts;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Domain;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.Repositories
{
    public class GeneroRepository : IGeneroRepository
    {
        private readonly ManageGamesDataContext _context;

        public GeneroRepository(ManageGamesDataContext context)
        {
            _context = context;
        }

        public Genero Recuperar(Guid id)
        {
            return _context
                .Genero
                .FirstOrDefault(x => x.Id == id);
        }

        public Genero RecuperarPorNome(string nome)
        {
            return _context
                .Genero
                .AsNoTracking()
                .FirstOrDefault(x => x.Nome == nome);
        }

        public IEnumerable<Genero> RecuperarDapper()
        {
            var query = "SELECT * FROM [Genero]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn
                    .Query<Genero>(query)
                    .ToList();
            }
        }

        public void Salvar(Genero genero)
        {
            genero.GerarId();
            _context.Genero.Add(genero);
            _context.SaveChanges();
        }

        public void Alterar(Genero genero)
        {
            _context.Entry(genero).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(Genero genero)
        {
            _context.Entry(Recuperar(genero.Id)).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
