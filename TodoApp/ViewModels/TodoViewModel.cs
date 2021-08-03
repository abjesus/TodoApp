﻿using System;
using System.Collections.Generic;
using TodoApp.Domain.Entidades;
using TodoApp.Enumeradores;

namespace TodoApp.ViewModels
{
    public class TodoViewModel
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }

        public virtual UsuarioViewModel Usuario { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public DateTime Vencimento { get; set; }

        public TodoStatus Status { get; set; }

        public Todo ToDomain()
        {
            return new Todo
            {
                UsuarioId = this.UsuarioId,
                Nome = this.Nome,
                Descricao = this.Descricao,
                Vencimento = this.Vencimento,
                Status = (Domain.Enumeradores.TodoStatus) this.Status
            };
        }

        public static TodoViewModel FromDomain(Todo todo)
        {
            return new TodoViewModel
            {
                Id = todo.Id,
                UsuarioId = todo.UsuarioId,
                Nome = todo.Nome,
                Descricao = todo.Descricao,
                Vencimento = todo.Vencimento,
                Status = (TodoStatus) todo.Status
            };
        }

        public static List<TodoViewModel> FromDomain(List<Todo> todos)
        {
            var list = new List<TodoViewModel>();

            todos.ForEach((todo) => list.Add(FromDomain(todo)));

            return list;
        }
    }
}
