using MarketTools.WebApi.Models.Identity;

namespace MarketTools.WebApi.Interfaces
{
    public interface IIdentityService
    {
        public Task<TokenVm> LoginAsync(LoginModel login);
        public Task<TokenVm> RegisterAsync(RegisterModel register);
        public Task<TokenVm> PasswordRecoveryAsync(PasswordRecoveryModel passwordRecovery);
        public Task<UserVm> GetAuthUserAsync();
    }
}
