using Microsoft.AspNetCore.Mvc;
using WebApplicationORM.Models;
using WebApplicationORM.Repository;

namespace WebApplicationORM.Controllers
{
    public class UserController : Controller
    {
        private readonly UserRepository _repo;

        public UserController(UserRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var users = _repo.GetAll();
            return View(users);
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] User user)
        {
            _repo.Add(user);
            return Json(new { message = "User added successfully!" });
        }

        [HttpPut]
        public IActionResult EditUser([FromBody] User user)
        {
            _repo.Update(user);
            return Json(new { message = "User updated successfully!" });
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromBody] User user)
        {
            _repo.Delete(user.Id);
            return Json(new { message = "User deleted successfully!" });
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _repo.GetAll();
            return Json(users);
        }
    }
}