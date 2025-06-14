namespace BMDb.Core.ServiceContracts;

public interface IBlackListService
{
    bool IsTokenBlackListed(string token);

    /// <summary>
    /// Add a token to the black list
    /// </summary>
    /// <param name="token"></param>
    void AddTokenToBlackList(string token);
}