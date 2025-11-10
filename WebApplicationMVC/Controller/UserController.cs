using Microsoft.AspNetCore.Mvc;
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
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            if (user == null)
                return BadRequest(new { message = "User data is required" });
            
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return Ok(new
            {
                message = "User deleted successfully" 
                
            });

        }
    }
}