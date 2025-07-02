using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using TaskManager.API.Models; // 1. Precisamos "usar" o nosso modelo TaskItem

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Rota será /api/tasks
    public class TasksController : ControllerBase
    {
        // 2. Nosso "banco de dados" em memória, já com alguns dados
        private static List<TaskItem> _tasks = new List<TaskItem>
        {
            new TaskItem { Id = 1, Text = "Revisar C# Web API", Completed = false },
            new TaskItem { Id = 2, Text = "Estudar ASP.NET Core", Completed = false },
            new TaskItem { Id = 3, Text = "Criar uma API RESTful", Completed = false }

        };

        /* 3. Nosso primeiro endpoint para LISTAR as tarefas
         GET: /api/tasks
         Aqui, vamos retornar uma lista de TaskItem
         vamos utilizar o try catch para capturar erros
         e retornar uma resposta adequada
        */
        [HttpGet]

        /*O método GetTasks retorna uma lista de tarefas
         e utiliza o tipo ActionResult para permitir diferentes tipos de resposta HTTP.
        ActionResult<IEnumerable<TaskItem>> indica que o método pode retornar
         uma lista de TaskItem ou um erro HTTP.
         O tipo IEnumerable<TaskItem> é usado para indicar que estamos retornando uma coleção de objetos TaskItem.
        O método Ok() é um método auxiliar que cria uma resposta HTTP 200 (Sucesso)
         e envia a nossa lista de tarefas no corpo da resposta.
         */
        public ActionResult<IEnumerable<TaskItem>> GetTasks()
        {
            // O método Ok() cria uma resposta HTTP 200 (Sucesso)
            // e envia a nossa lista de tarefas no corpo da resposta.
            return Ok(_tasks);
        }

        // 4. vamos criar um endpoint para consultar uma tarefa específica
        // GET: /api/tasks/{id}
        [HttpGet("{id}")]
        public ActionResult<TaskItem> GetTaskId(long id)
        {
            //Vamos procurar a tarefa pelo ID
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                // Se não encontrarmos a tarefa, retornamos um erro 404 Not Found
                return NotFound();
            }
            // Se encontrarmos, retornamos a tarefa com um status 200 OK
            return Ok(task);
        }

        // 5. Vamos criar um endpoint para adicionar uma nova tarefa
        // POST: /api/tasks
        // Aqui, vamos receber um objeto TaskItem no corpo da requisição
        [HttpPost]
        public ActionResult<TaskItem> CreateTask(TaskItem newTask)
        {
            // Em um banco de dados real, o ID seria gerado automaticamente.
            // Para nossa lista em memória, vamos gerar um ID simples baseado no último item.
            long newId = _tasks.Any() ? _tasks.Max(t => t.Id) + 1 : 1;
            newTask.Id = newId;

            // Adiciona a nova tarefa à nossa lista
            _tasks.Add(newTask);

            // Retorna a tarefa recém-criada com um status 200 OK.
            // (Em uma API completa, retornaríamos um status 201 Created com a URL do novo item,
            // mas para simplificar, um 200 OK com o objeto já é ótimo).
            return Ok(newTask);
        }

        // 6. Vamos criar um endpoint para atualizar uma tarefa existente
        // PUT: /api/tasks/{id}
        // Aqui, vamos receber um objeto TaskItem atualizado no corpo da requisição
        [HttpPut("{id}")]
        public IActionResult UpdateTask(long id, TaskItem updatedTask)
        {
            //Vamos verificar se a tarefa existe
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                //se a tarefa não existir, retornamos um erro 404 Not Found
                return NotFound();
            }

            //Agora atualizamos a tarefa
            task.Text = updatedTask.Text;
            task.Completed = updatedTask.Completed;

            //agora um status 204 No Content para indicar que a atualização foi bem-Sucedida
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            //Vamos verificar se a tarefa existe
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                //se a tarefa não existir, retornamos um erro 404 Not Found
                return NotFound();
            }
            //Agora removemos a tarefa da lista caso tenha passado pela verificação
            _tasks.Remove(task);
            //então retornamos um status 204 No Content para indicar que a exlusão foi bem sucedida
            return NoContent();
        }
    }
}
