﻿using Microsoft.EntityFrameworkCore;
using SistemaDeTarefas.Data;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Repositorios
{
    public class UsuarioRepositor : IUsuarioRepositer
    {

        private readonly SistemaTarefasDBContex _dbContext;
        public UsuarioRepositor(SistemaTarefasDBContex sistemaTarefasDBContex) 
        { 
            _dbContext = sistemaTarefasDBContex;
        }
        public async Task<UsuarioModel> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuario()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModel> Adicionar(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<bool> Apagar(int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"O Usuario por ID: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;

        }

        public async Task<UsuarioModel> Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = await BuscarPorId(id);
            if (usuarioPorId == null)
            {
                throw new Exception($"O Usuario por ID: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Name = usuario.Name;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Usuarios.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }


    }
}
