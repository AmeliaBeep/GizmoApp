namespace GizmoApp;

public interface IOpinionService
{
    Opinion GetRandomOpinion();
}

public class InMemoryOpinionService : IOpinionService
{
    private readonly Opinion[] opinions =
    [
        new(OpinionCategory.Happy, "Head scratches approved"),
        new(OpinionCategory.Grumpy, "Do not pet the tail"),
        new(OpinionCategory.Curious, "He thinks you smell funny"),
        new(OpinionCategory.Happy, "Treats are welcome"),
        new(OpinionCategory.Grumpy, "Stinky girl cats need to go away")
    ];

    public Opinion GetRandomOpinion()
    {
        return opinions[Random.Shared.Next(opinions.Length)];
    }
}
