using API.Models;
using API.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class LearningCourseController(
    ILearningCourseService learningCourseService
    ) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateLearningCourse([FromBody] LearningCourseInputModel learningCourseInputModel)
    {
        return await learningCourseService.CreateAsync(learningCourseInputModel) ? Ok() : BadRequest();
    }
}