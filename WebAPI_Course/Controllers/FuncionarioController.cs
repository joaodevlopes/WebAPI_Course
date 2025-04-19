using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI_Course.Models;
using WebAPI_Course.Service.FuncionariosService;

namespace WebAPI_Course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionarioController : ControllerBase
    {
        private readonly IFuncionarioInterface _funcionarioInterface; 
        public FuncionarioController(IFuncionarioInterface funcionariointerface)
        {
            _funcionarioInterface = funcionariointerface;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> GetFuncionarios()
        {
            return Ok(await _funcionarioInterface.GetFuncionarios());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<FuncionarioModel>>> GetFuncionarioById(int Id)
        {
            ServiceResponse<FuncionarioModel> serviceResponse = await _funcionarioInterface.GetFuncionarioById(Id);
            return Ok(serviceResponse); 
                
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> CreateFuncionario(FuncionarioModel novoFuncionario)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new
                {
                    sucesso = false,
                    mensagem = "Dados inválidos",
                    erros = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                });
            }

            return Ok(await _funcionarioInterface.CreateFuncionario(novoFuncionario));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> UpdateFuncionario(FuncionarioModel editadoFuncionario)
        { 
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await  _funcionarioInterface.UpdateFuncionario(editadoFuncionario);

            return Ok(serviceResponse);
        }

        [HttpPut("InativaFuncionario")]
        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> InativaFuncionario(int id)
        {
            ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.InativaFuncionario(id);
            return Ok(serviceResponse);
        }

        [HttpDelete]

        public async Task<ActionResult<ServiceResponse<List<FuncionarioModel>>>> DeleteFuncionario(int id)
        { 
             ServiceResponse<List<FuncionarioModel>> serviceResponse = await _funcionarioInterface.DeleteFuncionario(id);
            return Ok(serviceResponse); 
        }






    }
}
