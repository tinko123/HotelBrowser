using HotelBrowser.Core.Contracts;
using HotelBrowser.Infrastructure.Data.Common;
using HotelBrowser.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBrowser.Core.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly IRepository repository;
        public OwnerService(IRepository _repository)
        {
            repository = _repository;
        }
        public Task CreateAsync(string userId, string phoneNumber)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<HotelOwner>()
                .AnyAsync(o => o.UserId == userId);
        }

        public Task<bool> UserHasRentsAsync(string userId)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            throw new NotImplementedException();
        }
    }
}
