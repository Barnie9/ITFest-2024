using API.Mappers;
using API.Models;
using API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("[controller]")]
[ApiController]
public class BadgeController(
    IBadgeRepository badgeRepository
    ) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateBadge([FromBody] BadgeInputModel badgeInputModel) =>
        await badgeRepository.CreateAsync(BadgeMapper.MapBadgeInputModelToBadgeEntity(badgeInputModel)) != null ? Ok() : BadRequest();

    [HttpGet]
    public async Task<ActionResult<List<BadgeModel>>> GetAllBadges() =>
        Ok((await badgeRepository.GetAllBadgesAsync()).Select(BadgeMapper.MapBadgeEntityToBadgeModel).ToList());
}