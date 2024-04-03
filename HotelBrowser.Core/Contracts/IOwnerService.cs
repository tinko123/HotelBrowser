namespace HotelBrowser.Core.Contracts
{
    public interface IOwnerService
    {
        Task<bool> ExistByIdAsync(string userId);
        Task<bool> UserWithPhoneNumberExistAsync(string phoneNumber);
        Task<bool> UserHasRentsAsync(string userId);
        Task CreateAsync(string userId, string phoneNumber);
    }
}
