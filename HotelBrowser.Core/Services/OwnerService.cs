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
        public async Task CreateAsync(string userId, string phoneNumber)
        {
            await repository.AddAsync(new HotelOwner
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            });
            await repository.SaveChangesAsync();
        }

        public async Task<bool> ExistByIdAsync(string userId)
        {
            return await repository.AllReadOnly<HotelOwner>()
                .AnyAsync(o => o.UserId == userId);
        }

		public async Task<int?> GetOwnerIdAsync(string userId)
		{
            return (await repository.AllReadOnly<HotelOwner>()
                .FirstOrDefaultAsync(o => o.UserId == userId))?.Id;
		}

		public async Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber)
        {
            return await repository.AllReadOnly<HotelOwner>()
                .AnyAsync(o => o.PhoneNumber == phoneNumber);
        }
    }
}
