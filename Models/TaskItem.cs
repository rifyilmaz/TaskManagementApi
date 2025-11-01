namespace TaskManagementApi.Models;

public class TaskItem {

    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string? Description { get; set; }
    public bool IsCompleted { get; set; }
    public DateTime? DueDate { get; set; }   

    public Priority Priority { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;          

}
public enum Priority
{
 Low = 1,
 Medium = 2,
 High = 3
}