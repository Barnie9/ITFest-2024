using API.Entities;
using API.Models;

namespace API.Services;

public interface ICourseService
{
    Task<bool> CreateAsync(CourseInputModel courseInputModel);
}