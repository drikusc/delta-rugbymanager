using RugbyManager.Models;

namespace RugbyManager.Contracts
{
    public interface IPlayerService
    {
        GetPlayersResponse Get(string firstName, string lastName, decimal? height, string teamName, string positionCode);

        CreatePlayerResponse Create(CreatePlayerRequest request);

        TransferPlayerResponse Transfer(TransferPlayerRequest request);
    }
}
