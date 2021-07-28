﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using TodoApp.Data.Contexto;
using TodoApp.Domain.Entidades;
using TodoApp.Domain.Interfaces;

namespace TodoApp.Data.Repositorios
{
    public class RepositorioBase<T> : IRepositorio<T> where T : Entidade, new()
    {
        public DbContexto Contexto { get; }

        public RepositorioBase(DbContexto contexto)
        {
            Contexto = contexto;
        }

        public async Task Incluir(T entidade)
        {
            Contexto.Set<T>().Add(entidade);
            await Commit();
        }

        public async Task Alterar(T entidade)
        {
            Contexto.Entry(entidade).State = System.Data.Entity.EntityState.Modified;
            await Commit();
        }

        public async Task Excluir(T entidade)
        {
            Contexto.Set<T>().Remove(entidade);
            await Commit();
        }

        public async Task<T> ObterPorId(Guid id)
        {
            return await Contexto.Set<T>().FindAsync(id);
        }

        public async Task<List<T>> ObterTodos(Guid idUsuario)
        {
            return await Contexto
                .Set<T>()
                .Where(entidade => entidade.Id == idUsuario)
                .ToListAsync();
        }

        public async Task Commit()
        {
            await Contexto.SaveChangesAsync();
        }
    }
}
