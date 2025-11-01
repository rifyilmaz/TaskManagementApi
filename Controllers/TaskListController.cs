
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using TaskManagementApi.Models;
using TaskManagementApi.Services;

namespace TaskManagementApi.Controllers
{
    //[Route("api/[controller]")]
    [Route("api/tasks")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private readonly ITaskItemService _context;

        public TaskListController(ITaskItemService context)
        {
            _context = context;
        }
      

        // GET: api/tasks
        [HttpGet]
        public   async Task<ActionResult<List<TaskItem>>>  GetTasks()
        {
            var tasks =  await Task.FromResult(_context.GetAllTasks());            
            return Ok(tasks);
        }

        // GET: api/tasks/1
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskItem>> GetTask(int id)
        {
            TaskItem? item = _context.GetTaskById(id);            
            if (item == null)
            {
                return NotFound();
            }
            var taskItem = await Task.FromResult(item);
            return taskItem;
        }

        // GET: api/tasks/priority/{priority}
        [HttpGet("priority/{priority}")]
        public   async Task<ActionResult<List<TaskItem>>>  GetTasksByPriority(Priority priority)
        {
            var tasks =  await Task.FromResult(_context.GetTasksByPriority(priority));            
            return Ok(tasks);
        }
        // GET: api/tasks/search}
        [HttpGet("search")]
        public   async Task<ActionResult<List<TaskItem>>>  SearchTasks(string? keyword, bool? isCompleted)
        {
            var tasks =  await Task.FromResult(_context.SearchTasks(keyword, isCompleted));            
            return Ok(tasks);
        }

        // POST: api/TaskItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public   async Task<ActionResult<TaskItem?>> CreateTask(TaskItem taskItem)
        {
            TaskItem? createdTask =  _context.CreateTask(taskItem);
            if (createdTask == null)
            {
                return NotFound(createdTask); //Not created, means not found
            }

            return await Task.FromResult(createdTask);
            //return CreatedAtAction(nameof(CreateTask), new { id = createdTask.Id }, createdTask);
            //return Ok(createdTask);
        }

        // PUT: api/TaskItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public  async Task<ActionResult<TaskItem>> UpdateTask(int id, TaskItem taskItem)
        {
            if (id != taskItem.Id)
            {
                return BadRequest();
            }

            TaskItem? ret = _context.UpdateTask(id, taskItem);
            if (ret == null)
            {
                return NotFound();
            }

            //CreatedAtAction(nameof(UpdateTask), new { id = ret.Id }, ret);
            return await Task.FromResult(ret);
        }


        // DELETE: api/tasks/5
        [HttpDelete("{id}")]
        public  async Task<ActionResult> DeleteTask(int id)
        {
            bool deleted =  _context.DeleteTask(id);
            if (deleted == false)
            {
                //return NotFound();
                return await Task.FromResult(NotFound());
            }
            //return NoContent();
            return await Task.FromResult(NoContent());
        }

    }
}
