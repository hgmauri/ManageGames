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
    public class JogoRepository : IJogoRepository
    {
        private readonly ManageGamesDataContext _context;

        public JogoRepository(ManageGamesDataContext context)
        {
            _context = context;
        }

        public Jogo Recuperar(Guid id)
        {
            return _context.Jogo.Include(x => x.Genero).FirstOrDefault(x => x.Id == id);
        }

        public Jogo RecuperarPorNome(string nome)
        {
            return _context.Jogo.AsNoTracking().FirstOrDefault(x => x.Nome == nome);
        }

        public IEnumerable<Jogo> RecuperarDapper()
        {

            var query = "SELECT * FROM [Jogo]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<Jogo>(query).ToList();
            }
        }

        public IEnumerable<Jogo> RecuperarDisponiveis()
        {

            var query = "SELECT * FROM[LocadoraS2IT].[dbo].[Jogo] J LEFT JOIN[dbo].[Emprestimo] E ON E.Jogo_Id = J.[Id] WHERE E.Jogo_Id IS NULL";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<Jogo>(query).ToList();
            }
        }

        public void Salvar(Jogo jogo)
        {
            jogo.GerarId();
            jogo.Genero = _context.Genero.Find(jogo.Genero.Id);
            _context.Jogo.Add(jogo);

            _context.SaveChanges();
        }

        public void Alterar(Jogo jogo)
        {

            _context.Entry(jogo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(Jogo jogo)
        {
            jogo = _context.Jogo.Find(jogo.Id);
            _context.Entry(jogo).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
