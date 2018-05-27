using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Transactions;
using Dapper;
using ManageGames.Data.Contexts;
using ManageGames.Data.Repositories.Interfaces;
using ManageGames.Domain;
using ManageGames.Domain.Entities;

namespace ManageGames.Data.Repositories
{
    public class AmigoRepository : IAmigoRepository 
    {
        private readonly ManageGamesDataContext _context;

        public AmigoRepository(ManageGamesDataContext context)
        {
            _context = context;
        }

        public Amigo Recuperar(Guid id)
        {
            return _context.Amigo.FirstOrDefault(x => x.Id == id);
        }

        public Amigo RecuperarPorNome(string nome)
        {
            return _context.Amigo.AsNoTracking().FirstOrDefault(x => x.Nome == nome);
        }

        public IEnumerable<Amigo> RecuperarDapper()
        {

            var query = "SELECT * FROM [Amigo]";
            using (var conn = new SqlConnection(Runtime.ConnectionString))
            {
                conn.Open();
                return conn.Query<Amigo>(query).ToList();
            }
        }

        public void Salvar(Amigo amigo)
        {
            amigo.GerarId();
            _context.Amigo.Add(amigo);
            _context.SaveChanges();
        }

        public void Alterar(Amigo amigo)
        {
            _context.Entry(amigo).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Deletar(Amigo amigo)
        {
            using (TransactionScope transactionScope = new TransactionScope())
            {
                amigo = _context.Amigo.Find(amigo.Id);
                _context.Entry(amigo).State = EntityState.Deleted;
                _context.SaveChanges();
                var query = "DELETE [AspNetUsers] WHERE Email = @Email";
                using (var conn = new SqlConnection(Runtime.ConnectionString))
                {
                    conn.Open();
                    var i = conn.Execute(query, new { Email = amigo.Email });

                    if (i == 1)
                    {
                        transactionScope.Complete();       
                    }
                }
            }
        }
    }
}
