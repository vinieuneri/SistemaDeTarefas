using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositer _usuarioRepositer;
        public UsuarioController(IUsuarioRepositer usuarioRepositer) 
        {
            _usuarioRepositer = usuarioRepositer;
        }
        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> BuscarTodosUsuarios()
        {
            List<UsuarioModel> usuarios = await _usuarioRepositer.BuscarTodosUsuario();
            return Ok(usuarios);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModel>> BuscarPorId(int id)
        {
            UsuarioModel usuario = await _usuarioRepositer.BuscarPorId(id);
            return Ok(usuario);
        }
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Cadastrar([FromBody] UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioRepositer.Adicionar(usuarioModel);
            return Ok(usuario);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModel>> Atualizar([FromBody] UsuarioModel usuarioModel, int id)
        {
            usuarioModel.Id = id;
            UsuarioModel usuario = await _usuarioRepositer.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<UsuarioModel>> Apagar([FromBody] UsuarioModel usuarioModel, int id)
        {
            bool apagado = await _usuarioRepositer.Apagar(id);
            return Ok(apagado);
        }
    }
}
