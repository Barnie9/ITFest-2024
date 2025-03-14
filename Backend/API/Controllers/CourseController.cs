using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class CourseController(
    ICourseService courseService
    ) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateCourse([FromBody] CourseInputModel courseInputModel)
    {
        return await courseService.CreateAsync(courseInputModel) ? Ok() : BadRequest();
    }
}