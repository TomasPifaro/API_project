using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using TodoApi.Models;


namespace API_project.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;
        }

        public static string ApiResposte(string prompt)
        {
            prompt = prompt.ToLower();
            string[] altResposte = new string[11] {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. ",
                "Nam sed lectus sed mi venenatis tristique. ",
                "Ut sed mattis augue. ",
                "Cras ac diam neque. Vivamus scelerisque lectus risus, et lacinia ligula aliquam sed. ",
                "Nulla mattis fermentum convallis. ",
                "Nunc mollis dignissim arcu et accumsan. ",
                "Aenean nec risus quam. ",
                "Nam commodo, ante sit amet mattis auctor, ligula neque sagittis leo, non fermentum nulla ipsum ac quam. ",
                "Aenean pellentesque sed purus porta molestie. ",
                "Quisque ullamcorper volutpat ex non accumsan. ",
                "Integer eget tincidunt lorem. "
                };
            string respostaFinal = "";
            Random repticoes = new Random();
            if (prompt == "hello" || prompt == "ola")
            {
                respostaFinal = "olá amigo tem alguma pergunta?";
            }
            else if (prompt == "pifaro" || prompt == "tomas pifaro")
            {
                respostaFinal = "Não tenho autorização para isso, posso ser apagado :/";
            }
            else
            {
                for (int i = 0; i <= repticoes.Next(1, 5); i++)
                {
                    Random respostas = new Random();
                    respostaFinal = respostaFinal + altResposte[respostas.Next(0, 11)];
                }
            }


            return respostaFinal;
        }

        [HttpGet]
        public IEnumerable<TodoItem> Get()
        {
            return _context.TodoItems.ToList();
        }


        [HttpGet("{id:long}")]
        [ActionName("getTodoItem")]
        public async Task<ActionResult<TodoItem>> GetTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            return todoItem;
        }


        [HttpPost]
        public async Task<ActionResult<TodoItem>> PostTodoItem(TodoItemDTO todoItemDTO)
        {

            var todoItem = new TodoItem{
                promp = todoItemDTO.promp,
                resposta = ApiResposte(todoItemDTO.promp!)
            };

            _context.TodoItems.Add(todoItem);
            await _context.SaveChangesAsync();

            var responseStoredInDb = await _context.TodoItems.Where(ti => ti.promp == todoItemDTO.promp && ti.resposta == todoItem.resposta).FirstAsync();

            return CreatedAtAction(nameof(GetTodoItem), new { id = responseStoredInDb.id }, todoItem);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var todoItem = await _context.TodoItems.FindAsync(id);
            if (todoItem == null)
            {
                return NotFound();
            }
            _context.TodoItems.Remove(todoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}