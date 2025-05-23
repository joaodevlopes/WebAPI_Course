﻿using Microsoft.EntityFrameworkCore;
using WebAPI_Course.DataContext;
using WebAPI_Course.Models;

namespace WebAPI_Course.Service.FuncionariosService
{
    public class FuncionarioService : IFuncionarioInterface
    {
        private readonly AplicationDbContext _context;
        public FuncionarioService(AplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> CreateFuncionario(FuncionarioModel NovoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {
                if (NovoFuncionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados";
                    serviceResponse.Sucesso = false;


                    return serviceResponse;
                }
                _context.Add(NovoFuncionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;

            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> DeleteFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();

            try
            {

                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                _context.Funcionarios.Remove(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não encontrado";
                    serviceResponse.Sucesso = false;

                }
            }
                
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<FuncionarioModel>> GetFuncionarioById(int id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = new ServiceResponse<FuncionarioModel>();

            try
            {

                FuncionarioModel funcionario = _context.Funcionarios.FirstOrDefault(x => x.Id == id);
                serviceResponse.Dados = funcionario;

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso=false;
                }

            }
            catch(Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> GetFuncionarios()
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {
                serviceResponse.Dados = _context.Funcionarios.ToList();

                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado";
                }

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<FuncionarioModel>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {

                FuncionarioModel funcionario =  _context.Funcionarios.FirstOrDefault(x => x.Id == id);

                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }

                funcionario.Ativo = false;
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(funcionario);
                await _context.SaveChangesAsync();
                serviceResponse.Dados =  _context.Funcionarios.ToList();
            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }
            return serviceResponse;
        }   

        public async Task<ServiceResponse<List<FuncionarioModel>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = new ServiceResponse<List<FuncionarioModel>>();
            try
            {

                FuncionarioModel funcionario = _context.Funcionarios.AsNoTracking().FirstOrDefault(x => x.Id == editadoFuncionario.Id);
                if (funcionario == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Usuario não localizado";
                    serviceResponse.Sucesso = false;
                }
                funcionario.DataDeAlteracao = DateTime.Now.ToLocalTime();
                _context.Funcionarios.Update(editadoFuncionario);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Funcionarios.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
