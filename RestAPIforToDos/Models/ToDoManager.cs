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

        // Returns all ToDos
        public async Task<List<ToDo>> GetToDosAsync()
        {
            return await _context.ToDos.ToListAsync();
        }

        // Returns ToDos to be done in given range
        public async Task<List<ToDo>> GetToDosRangeAsync(DateTime startDate, DateTime endDate)
        {
            return await _context.ToDos
                .Where(t => t.DateOfExpiry >= startDate && t.DateOfExpiry <= endDate)
                .ToListAsync();
        }

        public async Task<ToDo?> GetToDoByIdAsync(int id)
        {
            return await _context.ToDos.FindAsync(id);
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

        public async Task MarkDoneToDoAsync(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                toDo.Complete = 100;
                toDo.Done = true;
                _context.ToDos.Update(toDo);
                await _context.SaveChangesAsync();
            }
        }

        public async Task MarkNotDoneToDoAsync(int id)
        {
            var toDo = await _context.ToDos.FindAsync(id);
            if (toDo != null)
            {
                if (toDo.Complete >=100)
                {
                    toDo.Complete = 99;
                }
                toDo.Done = false;
                _context.ToDos.Update(toDo);
                await _context.SaveChangesAsync();
            }
        }
    }
}
