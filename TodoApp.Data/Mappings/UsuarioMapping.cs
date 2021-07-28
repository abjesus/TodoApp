using System.Data.Entity.ModelConfiguration;
using TodoApp.Domain.Entidades;

namespace TodoApp.Data.Mappings
{
    public class UsuarioMapping : EntityTypeConfiguration<Usuario>
    {
        public UsuarioMapping()
        {
            ToTable(nameof(Usuario));

            Property(usuario => usuario.Nome)
                .IsRequired();

            Property(usuario => usuario.Sobrenome)
                .IsRequired();

            Property(usuario => usuario.Email)
                .IsRequired();

            Property(usuario => usuario.Senha)
                .IsRequired();

            Property(usuario => usuario.Status)
                .IsRequired();

            HasMany(usuario => usuario.Todos)
                .WithRequired(todo => todo.Usuario);
        }
    }
}
