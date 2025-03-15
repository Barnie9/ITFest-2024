using API.Entities;
using API.Models;

namespace API.Mappers;

public static class BadgeMapper
{
    public static Badge MapBadgeInputModelToBadgeEntity(BadgeInputModel badgeInputModel) =>
        new Badge()
        {
            Name = badgeInputModel.Name,
            BaseName = badgeInputModel.BaseName.ToLower(),
            Level = badgeInputModel.Level,
            Icon = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(badgeInputModel.Icon))
        };

    public static BadgeModel MapBadgeEntityToBadgeModel(Badge badge) =>
        new BadgeModel()
        {
            Name = badge.Name,
            Level = badge.Level,
            Icon = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(badge.Icon))
        };
}