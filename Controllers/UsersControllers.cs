// using Microsoft.AspNetCore.Mvc;
// using UserManagementAPI.Models;

// [ApiController]
// [Route("api/[controller]")]
// public class UsersController : ControllerBase
// {
//     private static List<User> users = new List<User>();

//     // GET: Retrieve all users
//     [HttpGet]
//     public IActionResult GetUsers([FromQuery] int page = 1, [FromQuery] int limit = 10)
//     {
//         var paginatedUsers = users.Skip((page - 1) * limit).Take(limit).ToList();
//         return Ok(paginatedUsers);
//     }

//     // GET: Retrieve user by ID
//     [HttpGet("{id}")]
//     public IActionResult GetUserById(int id)
//     {
//         var user = users.FirstOrDefault(u => u.Id == id);
//         if (user == null)
//         {
//             return NotFound(new { error = "User not found." });
//         }
//         return Ok(user);
//     }

//     // POST: Add a new user
//     [HttpPost]
//     public IActionResult AddUser([FromBody] User user)
//     {
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }
//         user.Id = users.Count + 1;
//         users.Add(user);
//         return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
//     }

//     // PUT: Update user details
//     [HttpPut("{id}")]
//     public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
//     {
//         if (!ModelState.IsValid)
//         {
//             return BadRequest(ModelState);
//         }
//         var user = users.FirstOrDefault(u => u.Id == id);
//         if (user == null)
//         {
//             return NotFound(new { error = "User not found." });
//         }
//         user.FirstName = updatedUser.FirstName;
//         user.LastName = updatedUser.LastName;
//         user.Email = updatedUser.Email;
//         return NoContent();
//     }

//     // DELETE: Remove user by ID
//     [HttpDelete("{id}")]
//     public IActionResult DeleteUser(int id)
//     {
//         var user = users.FirstOrDefault(u => u.Id == id);
//         if (user == null)
//         {
//             return NotFound(new { error = "User not found." });
//         }
//         users.Remove(user);
//         return NoContent();
//     }
// }


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using UserManagementAPI.Models;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private static List<User> users = new List<User>();

    [HttpGet]
    [Authorize]
    public IActionResult GetUsers([FromQuery] int page = 1, [FromQuery] int limit = 10)
    {
        var paginatedUsers = users.Skip((page - 1) * limit).Take(limit).ToList();
        return Ok(paginatedUsers);
    }

    [HttpGet("{id}")]
    [Authorize]
    public IActionResult GetUserById(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(new { error = "User not found." });
        }
        return Ok(user);
    }

    [HttpPost]
    [Authorize]
    public IActionResult AddUser([FromBody] User user)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        user.Id = users.Count + 1;
        users.Add(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    [HttpPut("{id}")]
    [Authorize]
    public IActionResult UpdateUser(int id, [FromBody] User updatedUser)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(new { error = "User not found." });
        }
        user.FirstName = updatedUser.FirstName;
        user.LastName = updatedUser.LastName;
        user.Email = updatedUser.Email;
        return NoContent();
    }

    [HttpDelete("{id}")]
    [Authorize]
    public IActionResult DeleteUser(int id)
    {
        var user = users.FirstOrDefault(u => u.Id == id);
        if (user == null)
        {
            return NotFound(new { error = "User not found." });
        }
        users.Remove(user);
        return NoContent();
    }
}