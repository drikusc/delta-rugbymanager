using Microsoft.Extensions.Options;
using RugbyManager.Contracts;
using RugbyManager.DataAccess.Contracts;
using RugbyManager.Models;
using System;
using System.Linq;

namespace RugbyManager.Services
{
    public class PositionService : IPositionService
    {
        private IOptions<ResponseConfiguration> _responseSettings;
        private IPositionDataManager _positionDataManager;

        public PositionService(IOptions<ResponseConfiguration> responseSettings, IPositionDataManager positionDataManager)
        {
            _responseSettings = responseSettings;
            _positionDataManager = positionDataManager;
        }

        public GetPositionsResponse Get()
        {
            try
            {
                var response = new GetPositionsResponse
                {
                    Code = _responseSettings.Value.SuccessfulResponseCode,
                    Message = _responseSettings.Value.SuccessfulResponseMessage,
                };
                response.Positions = _positionDataManager.Get().Select(x => new Position
                {
                    Id = x.Id,
                    Code = x.Code,
                    Description = x.Description
                }).ToArray();

                return response;
            }
            catch(Exception exception)
            {
                //TODO Log error
                return new GetPositionsResponse
                {
                    Code = _responseSettings.Value.ErrorOccuredCode,
                    Message = _responseSettings.Value.ErrorOccuredMessage
                };
            }
        }
    }
}
