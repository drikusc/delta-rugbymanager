using Microsoft.Extensions.Options;
using RugbyManager.Contracts;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.Models;
using System;
using System.Linq;

namespace RugbyManager.Services
{
    public class PlayerService : IPlayerService
    {
        private IOptions<PlayerServiceConfiguration> _settings;
        private IOptions<ResponseConfiguration> _responseSettings;
        private IPlayerDataManager _playerDataManager;
        private IPositionDataManager _positionDataManager;
        private ITeamDataManager _teamDataManager;

        public PlayerService(IOptions<PlayerServiceConfiguration> settings, IOptions<ResponseConfiguration> responseSettings, IPlayerDataManager playerDataManager, IPositionDataManager positionDataManager, ITeamDataManager teamDataManager)
        {
            _settings = settings;
            _responseSettings = responseSettings;
            _playerDataManager = playerDataManager;
            _positionDataManager = positionDataManager;
            _teamDataManager = teamDataManager;
        }

        public GetPlayersResponse Get(string firstName, string lastName, decimal? height, string teamName, string positionCode)
        {
            try
            {
                var players = new GetPlayersResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };

                players.Players = _playerDataManager.Get(firstName: firstName, lastName: lastName, height: height, teamName: teamName, positionCode: positionCode).Select(x => new Models.Player
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    MiddleName = x.MiddleName,
                    LastName = x.LastName,
                    Height = x.Height,
                    BirthDate = x.BirthDate,
                    Position = x.Position.Description,
                    Team = x.Team.Name
                }).ToArray();

                return players;
            }
            catch (Exception exception)
            {
                return new GetPlayersResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage,
                };
            }
        }

        public CreatePlayerResponse Create(CreatePlayerRequest request)
        {
            try
            {
                var isValidDate = DateTime.TryParseExact(request.BirthDate, _settings.Value.BirthDateFormat, null, System.Globalization.DateTimeStyles.None, out DateTime birthDate);
                if (!isValidDate || (DateTime.Now.Year - birthDate.Year) < _settings.Value.MinimumAge)
                    return new CreatePlayerResponse
                    {
                        Code = _responseSettings.Value.InvalidBirthDateFormatCode,
                        Message = string.Format(_responseSettings.Value.InvalidBirthDateFormatMessage, _settings.Value.BirthDateFormat, _settings.Value.MinimumAge)
                    };

                var position = _positionDataManager.Get(request.PositionCode);
                if(string.IsNullOrWhiteSpace(request.PositionCode) || !position.Any())
                    return new CreatePlayerResponse
                    {
                        Code = _responseSettings.Value.InvalidPositionCode,
                        Message = _responseSettings.Value.InvalidPositionMessage
                    };

                if(!_teamDataManager.Get(request.TeamId.GetValueOrDefault()).Any())
                    return new CreatePlayerResponse
                    {
                        Code = _responseSettings.Value.InvalidTeamCode,
                        Message = _responseSettings.Value.InvalidTeamMessage
                    };

                _playerDataManager.Create(new DataAccess.Models.Player
                {
                    FirstName = request.FirstName,
                    MiddleName = request.MiddleName,
                    LastName = request.LastName,
                    Height = request.Height.GetValueOrDefault(),
                    BirthDate = birthDate,
                    PrimaryPositionId = position.First().Id,
                    TeamId = request.TeamId.GetValueOrDefault()
                });

                return new CreatePlayerResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };
            }
            catch (Exception exception)
            {
                //TODO Add logging
                return new CreatePlayerResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage,
                };
            }
        }

        public TransferPlayerResponse Transfer(TransferPlayerRequest request)
        {
            try
            {
                var player = _playerDataManager.Get(request.PlayerId.GetValueOrDefault()).FirstOrDefault();
                if (player == null)
                    return new TransferPlayerResponse
                    {
                        Code = _responseSettings.Value.InvalidPlayerCode,
                        Message = _responseSettings.Value.InvalidPlayerMessage,
                    };

                if (!_teamDataManager.Get(request.TeamId.GetValueOrDefault()).Any())
                    return new TransferPlayerResponse
                    {
                        Code = _responseSettings.Value.InvalidTeamCode,
                        Message = _responseSettings.Value.InvalidTeamMessage
                    };

                _playerDataManager.Update(request.PlayerId.GetValueOrDefault(), request.TeamId.GetValueOrDefault());

                return new TransferPlayerResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };
            }
            catch (Exception exception)
            {
                //TODO Add logging
                return new TransferPlayerResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage,
                };
            }
        }
    }
}