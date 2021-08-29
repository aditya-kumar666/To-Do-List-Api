using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using To_Do_List_Api.DAL;
using Task = To_Do_List_Api.Models.Task;

namespace To_Do_List_Api.Controllers
{
    [Route("api/[Controller]/[action]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public TasksController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/Tasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetTask()
        {
            return await _context.Task.Where(x => !x.Complete).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Task>>> GetHistoricTask()
        {
            return await _context.Task.Where(x => x.Complete).ToListAsync();
        }

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<bool>> PostTask(Task task)
        {
            _context.Task.Add(task);
            await _context.SaveChangesAsync();

            return true;
        }

        // POST: api/Tasks
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<bool>> PostTaskList([FromBody]List<Task> task)
        {
            try
            {
                var ids = task.Where(x => x.id != 0).Select(x => x.id).ToArray();
                if (ids.Any())
                {   
                    foreach (int id in ids)
                    {
                        var tasks = await _context.Task.FindAsync(id);
                        _context.Task.Remove(tasks);
                    }
                }
                _context.Task.AddRange(task);
                await _context.SaveChangesAsync();

                return true;
            }
            catch(Exception)
            {
                return false;
            }
        }
    }
}
