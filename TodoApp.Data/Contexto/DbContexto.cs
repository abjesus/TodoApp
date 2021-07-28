using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Notificacoes;

namespace TodoApp.Data.Contexto
{
    public class DbContexto : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Todo> Todos { get; set; }

        public DbContexto() : base(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TodoApp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Notificacao>();

            // Carrega os mappings
            modelBuilder.Configurations.AddFromAssembly(typeof(DbContexto).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            var entidades = ChangeTracker
                .Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("Criacao") != null);

            foreach (var entry in entidades)
            {
                if (entry.State == EntityState.Added)
                    entry.Property("Criacao").CurrentValue = DateTime.Now;

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("Criacao").IsModified = false;
                    entry.Property("UsuarioCriacao").IsModified = false;
                    entry.Property("Alteracao").CurrentValue = DateTime.Now;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
