namespace BMDb.Core.ServiceContracts;

public interface IBlackListService
{
    public void AddToBlackList(string token);
    public bool IsBlackListed(string token);
}