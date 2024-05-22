namespace TodoApi.Models;

public class TodoItem
{
    public long id { get; set; }
    public string? promp { get; set; }
    public bool IsComplete { get; set; }
    public string? resposta {get; set; }
}
