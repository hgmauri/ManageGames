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
    public class EmprestimoRepository : IEmprestimoRepository
    {
        private readonly ManageGamesDataContext _context;

        public EmprestimoRepository(ManageGamesDataContext context)
        {
            _context = context;
        }

        public Emprestimo Recuperar(Guid id)
        {
            return _context.Emprestimo.Include(x=>x.Amigo).Include(x => x.Jogo).FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Emprestimo> RecuperarEmprestimos()
        {
            return _context.Emprestimo.Include(x => x.Amigo).Include(x => x.Jogo).AsEnumerable();
        }

        public IEnumerable<Emprestimo> RecuperarDapper()
        {
            var query = "SELECT * FROM [Emprestimo]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<Emprestimo>(query).ToList();
            }
        }

        public void Salvar(Emprestimo emprestimo)
        {
            emprestimo.GerarId();
            emprestimo.Amigo = _context.Amigo.Find(emprestimo.Amigo.Id);
            emprestimo.Jogo = _context.Jogo.Find(emprestimo.Jogo.Id);
            _context.Emprestimo.Add(emprestimo);
            _context.SaveChanges();
        }

        public void Alterar(Emprestimo emprestimo)
        {
            _context.Entry(emprestimo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(Emprestimo emprestimo)
        {
            _context.Entry(Recuperar(emprestimo.Id)).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}
