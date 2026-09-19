using GizmoApp.Models;
using GizmoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GizmoApp.Services;

public interface IOpinionService
{
    Task<Opinion?> GetRandomOpinionAsync();
}

public class OpinionService(GizmoDbContext db) : IOpinionService
{
    public async Task<Opinion?> GetRandomOpinionAsync()
    {
        var opinions = await db.Opinions.ToListAsync();

        return opinions.Count == 0
            ? null
            : opinions[Random.Shared.Next(opinions.Count)];
    }
}