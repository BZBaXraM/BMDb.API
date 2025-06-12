namespace BMDb.Core.Services;

public class BlackListService : IBlackListService
{
    private HashSet<string> BlackList { get; set; } = [];

    public void AddToBlackList(string token)
    {
        BlackList.Add(token);
    }

    public bool IsBlackListed(string token)
    {
        return BlackList.Contains(token);
    }
}