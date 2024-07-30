using Account.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Users.Data;

namespace Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly AppDbContexts _context;
        public UserControllers(AppDbContexts context)
        {
            _context = context;
        }

        //Adiciona as informações do usuário no banco de dados PostgreSQL
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user == null)
            {
                return BadRequest("Usuario não pode ser nulo!");
            }

            user.Id = 0;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUser), new { id = user.Id = user.Id }, user);
        }

        // Procura as informações do usuário pelo id
        [HttpGet("find/{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // Atualiza as informações do usuário
        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest("O Id do Usuário não corresponde.");
            }

            var userToUpdate = await _context.Users.FindAsync(id);
            if (userToUpdate == null)
            {
                return NotFound("Usuário não encontrado.");
            }

            userToUpdate.FirstName = user.FirstName;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Email = user.Email;
            userToUpdate.Telephone = user.Telephone;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound("Usuario não encontrado.");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
