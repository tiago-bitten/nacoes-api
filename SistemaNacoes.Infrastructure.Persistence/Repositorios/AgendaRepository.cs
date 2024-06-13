﻿using Microsoft.EntityFrameworkCore;
using SistemaNacoes.Domain.Entidades;
using SistemaNacoes.Domain.Interfaces;
using SistemaNacoes.Infrastructure.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaNacoes.Infrastructure.Persistence.Repositorios
{
    public class AgendaRepository : IAgendaRepository
    {
        private readonly SistemaNacoesDbContext _context;

        public AgendaRepository(SistemaNacoesDbContext context)
        {
            _context = context;
        }

        public async Task<int> CreateAsync(Agenda entity)
        {
            await _context.Agendas.AddAsync(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Agenda entity)
        {
            _context.Agendas.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Agenda?>> GetAllAsync()
        {
            return await _context.Agendas.ToListAsync();
        }

        public async Task<Agenda?> GetByIdAsync(int id)
        {
            return await _context.Agendas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task UpdateAsync(Agenda entity)
        {
            throw new NotImplementedException();
        }
    }
}
