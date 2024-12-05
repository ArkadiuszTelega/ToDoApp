using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestAPIforToDos;

namespace RestAPIforToDos.Models
{
    public class ToDoManager
    {
        private readonly AppDbContext _context;

        public ToDoManager(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<ToDo>> GetToDosAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        public async Task<ToDo> GetToDoByIdAsync(int id)
        {
            var todo = await _context.ToDos.FindAsync(id);
            if (todo != null)
            {
                return todo;
            }else
            {
                return null;
            }   
        }

        public async Task<List<ToDo>> GetDoneToDosAsync()
        {
            return await _context.ToDos.Where(t => t.Done).ToListAsync();
        }

        public async Task<List<ToDo>> GetNotDoneToDosAsync()
        {
            return await _context.ToDos.Where(t => t.Done == false).ToListAsync();
        }

        public async Task AddToDoAsync(ToDo toDo)
        {
            _context.ToDos.Add(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateToDoAsync(ToDo toDo)
        {
            _context.ToDos.Update(toDo);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteToDoAsync(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                _context.ToDos.Remove(toDo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
