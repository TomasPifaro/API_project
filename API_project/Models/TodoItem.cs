namespace TodoApi.Models;

public class TodoItem
{
    public long Id { get; set; }
    public string? promp { get; set; }
    public bool IsComplete { get; set; }

    public string Text { get; set; }
}
