using RugbyManager.Models;

namespace RugbyManager.Contracts
{
    public interface ITeamService
    {
        GetTeamsResponse Get();

        CreateTeamResponse Create(CreateTeamRequest request);

        LinkTeamToStadiumResponse LinkStadium(LinkTeamToStadiumRequest request);

        UnlinkTeamToStadiumResponse UnlinkStadium(UnlinkTeamToStadiumRequest request);
    }
}
