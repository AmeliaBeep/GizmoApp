namespace GizmoApp;

public enum OpinionCategory
{
    Happy,
    Grumpy,
    Curious
}

public class Opinion
{
    public OpinionCategory Category { get; set; }
    public required string Text { get; set; }
}
