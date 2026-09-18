using GizmoApp.Models;
using GizmoApp.Data;
using Microsoft.EntityFrameworkCore;

namespace GizmoApp.Services;

public interface IOpinionService
{
    Task<Opinion?> GetRandomOpinionAsync();
}

// public class InMemoryOpinionService : IOpinionService
// {
//     private readonly Opinion[] opinions =
//     [
//         new(OpinionCategory.Happy, "Head scratches approved"),
//         new(OpinionCategory.Grumpy, "Do not pet the tail"),
//         new(OpinionCategory.Curious, "He thinks you smell funny"),
//         new(OpinionCategory.Happy, "Treats are welcome"),
//         new(OpinionCategory.Grumpy, "Stinky girl cats need to go away")
//     ];

//     public Opinion GetRandomOpinion()
//     {
//         return opinions[Random.Shared.Next(opinions.Length)];
//     }
// }




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