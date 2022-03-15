using Microsoft.AspNetCore.Mvc;
using MinimalRestDemo.DAL;
using MinimalRestDemo.DAL.Models;

namespace MinimalRestDemo.Controllers;

[Route("[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserStorage _userStorage;

    public UserController([FromServices] UserStorage userStorage)
    {
        _userStorage = userStorage;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userStorage.GetAllUsers();

        if (users.Count <= 0) return NotFound();

        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetUser(int id)
    {
        var user = _userStorage.GetUser(id);

        return user is null ? Ok(user) : NotFound();
    }

    [HttpPost]
    public IActionResult Post([FromBody]User? user)
    {
        if (user is null) return BadRequest();

        return _userStorage.CreateUser(user) ? Ok() : Conflict("User already exists");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, User user)
    {
        if (string.IsNullOrEmpty(user.Name.Trim()) ||
            string.IsNullOrEmpty(user.Email.Trim()))
            return BadRequest();

        return _userStorage.UpdateUser(id, user) ? Ok() : NotFound();
    }

    [HttpPatch("/User/name/{id}")]
    public IActionResult PatchName(int id, string name)
    {
        if (string.IsNullOrEmpty(name.Trim())) return BadRequest();

        return _userStorage.UpdateUserName(id, name) ? Ok(_userStorage.GetUser(id)) : NotFound();
    }

    [HttpPatch("/User/email/{id}")]
    public IActionResult PatchEmail(int id, string email)
    {
        if (string.IsNullOrEmpty(email.Trim())) return BadRequest();

        return _userStorage.UpdateUserEmail(id, email) ? Ok(_userStorage.GetUser(id)) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _userStorage.DeleteUser(id) ? Ok() : NotFound();
    }

}