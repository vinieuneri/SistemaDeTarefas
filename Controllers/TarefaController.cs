using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaDeTarefas.Models;
using SistemaDeTarefas.Repositorios.Interfaces;

namespace SistemaDeTarefas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepositer _tarefaRepositer;
        public TarefaController(ITarefaRepositer tarefaRepositer) 
        {
            _tarefaRepositer = tarefaRepositer;
        }
        [HttpGet]
        public async Task<ActionResult<List<TarefaModel>>> ListarTodas()
        {
            List<TarefaModel> tarefas = await _tarefaRepositer.BuscarTodasTarefas();
            return Ok(tarefas);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TarefaModel>> BuscarPorId(int id)
        {
            TarefaModel tarefa = await _tarefaRepositer.BuscarPorId(id);
            return Ok(tarefa);
        }
        [HttpPost]
        public async Task<ActionResult<TarefaModel>> Cadastrar([FromBody] TarefaModel tarefaModel)
        {
            TarefaModel tarefa = await _tarefaRepositer.Adicionar(tarefaModel);
            return Ok(tarefa);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<TarefaModel>> Atualizar([FromBody] TarefaModel tarefaModel, int id)
        {
            tarefaModel.Id = id;
            TarefaModel tarefa = await _tarefaRepositer.Atualizar(tarefaModel, id);
            return Ok(tarefa);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaModel>> Apagar([FromBody] TarefaModel tarefaModel, int id)
        {
            bool apagado = await _tarefaRepositer.Apagar(id);
            return Ok(apagado);
        }
    }
}
