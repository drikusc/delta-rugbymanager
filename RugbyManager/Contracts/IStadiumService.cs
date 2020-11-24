using RugbyManager.Models;

namespace RugbyManager.Contracts
{
    public interface IStadiumService
    {
        GetStadiumsResponse Get();

        CreateStadiumResponse Create(CreateStadiumRequest request);
    }
}
