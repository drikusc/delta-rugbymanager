using Microsoft.Extensions.Options;
using RugbyManager.Contracts;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.Models;
using System;
using System.Linq;

namespace RugbyManager.Services
{
    public class StadiumService : IStadiumService
    {
        private IOptions<ResponseConfiguration> _responseSettings;
        private IStadiumDataManager _stadiumDataManager;


        public StadiumService(IOptions<ResponseConfiguration> responseSettings, IStadiumDataManager stadiumDataManager)
        {
            _responseSettings = responseSettings;
            _stadiumDataManager = stadiumDataManager;
        }

        public GetStadiumsResponse Get()
        {
            try
            {
                var response = new GetStadiumsResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };

                response.Stadiums = _stadiumDataManager.Get().Select(x => new Stadium
                {
                    Id = x.Id,
                    Name = x.Name,
                    Suburb = x.Suburb,
                    City = x.City,
                    Province = x.Province,
                    TeamName = x.Team?.Name
                }).ToArray();

                return response;
            }
            catch (Exception exception)
            {
                //TODO Log error
                return new GetStadiumsResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage
                };
            }
        }

        public CreateStadiumResponse Create(CreateStadiumRequest request)
        {
            try
            {
                if (_stadiumDataManager.Get(name: request.Name).Any())
                    return new CreateStadiumResponse
                    {
                        Code = _responseSettings.Value.DuplicateStadiumNameCode,
                        Message = _responseSettings.Value.DuplicateStadiumNameMessage
                    };

                _stadiumDataManager.Create(new DataAccess.Models.Stadium
                {
                    Name = request.Name,
                    Suburb = request.Suburb,
                    City = request.City,
                    Province = request.Province
                });

                return new CreateStadiumResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };
            }
            catch (Exception exception)
            {
                //TODO Add logging
                return new CreateStadiumResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage,
                };
            }
        }
    }
}
