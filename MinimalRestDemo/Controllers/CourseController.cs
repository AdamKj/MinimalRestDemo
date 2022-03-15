﻿using Microsoft.AspNetCore.Mvc;
using MinimalRestDemo.DAL;
using MinimalRestDemo.DAL.Models;

namespace MinimalRestDemo.Controllers;

[Route("[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly CourseStorage _courseStorage;

    public CourseController([FromServices] CourseStorage courseStorage)
    {
        _courseStorage = courseStorage;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var courses = _courseStorage.GetAllCourses();

        if (courses.Count <= 0) return NotFound();

        return Ok(courses);
    }

    [HttpGet("{id}")]
    public IActionResult GetCourse(int id)
    {
        var course = _courseStorage.GetCourse(id);

        return course is null ? Ok(course) : NotFound();
    }

    [HttpPost]
    public IActionResult Post([FromBody] Course? course)
    {
        if (course is null) return BadRequest();

        return _courseStorage.CreateCourse(course) ? Ok() : Conflict("Course already exists");
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, Course course)
    {
        if (string.IsNullOrEmpty(course.Name.Trim())) return BadRequest();

        return _courseStorage.UpdateCourse(id, course) ? Ok() : NotFound();
    }

    [HttpPatch("/Course/name/{id}")]
    public IActionResult PatchName(int id, string name)
    {
        if (string.IsNullOrEmpty(name.Trim())) return BadRequest();

        return _courseStorage.UpdateCourseName(id, name) ? Ok(_courseStorage.GetCourse(id)) : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        return _courseStorage.DeleteCourse(id) ? Ok() : NotFound();
    }
}