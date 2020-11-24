using Microsoft.Extensions.Options;
using RugbyManager.Contracts;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.Models;
using System;
using System.Linq;

namespace RugbyManager.Services
{
    public class TeamService : ITeamService
    {
        private IOptions<ResponseConfiguration> _responseSettings;
        private ITeamDataManager _teamDataManager;
        private IStadiumDataManager _stadiumDataManager;

        public TeamService(IOptions<ResponseConfiguration> responseSettings, ITeamDataManager teamDataManager, IStadiumDataManager stadiumDataManager)
        {
            _responseSettings = responseSettings;
            _teamDataManager = teamDataManager;
            _stadiumDataManager = stadiumDataManager;
        }

        public GetTeamsResponse Get()
        {
            try
            {
                var response = new GetTeamsResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };
                response.Teams = _teamDataManager.Get().Select(x => new Team
                {
                    Id = x.Id,
                    Name = x.Name,
                    Suburb = x.Suburb,
                    City = x.City,
                    Province = x.Province,
                    StadiumName = x.Stadium?.Name,
                    TotalPlayers = x.Players.Count,
                    CreatedDate = x.CreatedDate
                }).ToArray();

                return response;
            }
            catch (Exception exception)
            {
                return new GetTeamsResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage,
                };
            }
        }

        public CreateTeamResponse Create(CreateTeamRequest request)
        {
            try
            {
                if (request.StadiumId != null)
                {
                    var stadium = _stadiumDataManager.Get(request.StadiumId.GetValueOrDefault());
                    if (!stadium.Any())
                        return new CreateTeamResponse
                        {
                            Code = _responseSettings.Value.InvalidStadiumResponseCode,
                            Message = string.Format(_responseSettings.Value.InvalidStadiumResponseMessage, request.StadiumId)
                        };

                    if (stadium.First().Team != null)
                        return new CreateTeamResponse
                        {
                            Code = _responseSettings.Value.StadiumAlreadyHasLinkedTeamCode,
                            Message = _responseSettings.Value.StadiumAlreadyHasLinkedTeamMessage
                        };
                }

                if (_teamDataManager.Get(name: request.Name).Any())
                    return new CreateTeamResponse
                    {
                        Code = _responseSettings.Value.TeamAlreadyExistsCode,
                        Message = _responseSettings.Value.TeamAlreadyExistsMessage
                    };

                _teamDataManager.Create(new DataAccess.Models.Team
                {
                    Name = request.Name,
                    Suburb = request.Suburb,
                    City = request.City,
                    Province = request.Province,
                    StadiumId = request.StadiumId
                });

                return new CreateTeamResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };
            }
            catch (Exception exception)
            {
                //TODO Add logging
                return new CreateTeamResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage,
                };
            }
        }

        public LinkTeamToStadiumResponse LinkStadium(LinkTeamToStadiumRequest request)
        {
            try
            {
                var stadium = _stadiumDataManager.Get(request.StadiumId.GetValueOrDefault()).FirstOrDefault();
                if (stadium == null)
                    return new LinkTeamToStadiumResponse
                    {
                        Code = _responseSettings.Value.InvalidStadiumResponseCode,
                        Message = _responseSettings.Value.InvalidStadiumResponseMessage
                    };

                if (stadium.Team != null)
                    return new LinkTeamToStadiumResponse
                    {
                        Code = _responseSettings.Value.StadiumAlreadyHasLinkedTeamCode,
                        Message = _responseSettings.Value.StadiumAlreadyHasLinkedTeamMessage
                    };

                if (!_teamDataManager.Get(request.TeamId.GetValueOrDefault()).Any())
                    return new LinkTeamToStadiumResponse
                    {
                        Code = _responseSettings.Value.InvalidTeamCode,
                        Message = _responseSettings.Value.InvalidTeamMessage
                    };

                _teamDataManager.Update(request.TeamId.GetValueOrDefault(), request.StadiumId.GetValueOrDefault());

                return new LinkTeamToStadiumResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage
                };
            }
            catch (Exception exception)
            {
                //TODO Log error
                return new LinkTeamToStadiumResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage
                };
            }
        }

        public UnlinkTeamToStadiumResponse UnlinkStadium(UnlinkTeamToStadiumRequest request)
        {
            try
            {
                if (!_teamDataManager.Get(request.TeamId.GetValueOrDefault()).Any())
                    return new UnlinkTeamToStadiumResponse
                    {
                        Code = _responseSettings.Value.InvalidTeamCode,
                        Message = _responseSettings.Value.InvalidTeamMessage
                    };

                _teamDataManager.Update(request.TeamId.GetValueOrDefault(), null);

                return new UnlinkTeamToStadiumResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage
                };
            }
            catch (Exception exception)
            {
                //TODO Log error
                return new UnlinkTeamToStadiumResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage
                };
            }
        }
    }
}