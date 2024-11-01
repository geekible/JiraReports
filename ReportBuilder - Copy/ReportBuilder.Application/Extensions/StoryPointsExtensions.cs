namespace ReportBuilder.Application.Extensions;

public static class StoryPointsExtensions
{
    public static int ToDays(this float storyPoints)
    {
        return (int)storyPoints switch
        {
            1 => 1,
            2 => 1,
            3 => 2,
            5 => 5,
            8 => 10,
            _ => 0,
        };
    }
}