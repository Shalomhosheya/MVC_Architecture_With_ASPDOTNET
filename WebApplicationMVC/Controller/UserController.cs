using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("~/View/Index.cshtml");
        }

        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] User user)
        {
            // Remove Id from model state validation since it's auto-generated
            ModelState.Remove("Id");
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (user == null)
                return BadRequest(new { message = "User data is required" });

            // No need to set Id - it will be auto-generated
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { 
                message = "User saved successfully!", 
                userId = user.Id  // Return the generated ID
            });
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromBody] User user)
        {
            if (user == null || user.Id == 0)
                return BadRequest(new { message = "Valid user ID is required" });

            var existingUser = await _context.Users.FindAsync(user.Id);

            if (existingUser == null)
                return NotFound(new { message = "User not found" });

            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();

            return Ok(new { message = "User deleted successfully!" });
        }

        [HttpPut]
        public async Task<IActionResult> EditUser([FromBody] User user)
        {
            if (user == null || user.Id == 0)
                return BadRequest(new { message = "Valid user ID is required" });
            var existinguser =  await _context.Users.FindAsync(user.Id);

            if (existinguser == null)
            {
                return NotFound(new { message = "User not found" });
            }
            
            existinguser.Email = user.Email;
            existinguser.Password = user.Password;
            _context.Users.Update(existinguser);
            await _context.SaveChangesAsync();
            return Ok(new { message = "User updated successfully" });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _context.Users.ToListAsync();
            return Ok(users);
        }

    }
}