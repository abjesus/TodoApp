using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApp.Domain.Entidades;

namespace TodoApp.Data.Mappings
{
    public class TodoMapping : EntityTypeConfiguration<Todo>
    {
        public TodoMapping()
        {
            ToTable(nameof(Todo));

            Property(todo => todo.Nome)
                .IsRequired();

            Property(todo => todo.Descricao)
                .IsRequired();

            Property(todo => todo.Vencimento)
                .IsRequired();

            Property(todo => todo.Status)
                .IsRequired();

            Property(todo => todo.UsuarioId)
                .IsRequired();
        }
    }
}
