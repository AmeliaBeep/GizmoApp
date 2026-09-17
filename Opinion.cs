namespace GizmoApp;

public enum OpinionCategory
{
    Happy,
    Grumpy,
    Curious
}
public class Opinion
{
    
    public OpinionCategory Category { get; private set; }
    public string Text { get; private set; }

    public Opinion(OpinionCategory category, string text)
    {
        this.Category = category;
        this.Text = text;
    }

}
