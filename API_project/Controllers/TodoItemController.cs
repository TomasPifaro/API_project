using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[ApiController]
[Route("[controller]")]
public class TodoItemController : ControllerBase{

    private static readonly string[] _loremIpsum = new[]{
         "Lorem ipsum dolor sit amet, consectetur adipiscing elit.",
        "Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
        "Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."   
    };

    [HttpPost]
    public async Task<ActionResult<string>> Post([FromBody] string input){
        if (string.IsNullOrEmpty(input)){
            return BadRequest("Input string cannot be null or empty.");
        }

        var random = new Random();
        var loremIpsum = _loremIpsum[random.Next(_loremIpsum.Length)];
        return Ok(_loremIpsum);
    }
    
    }