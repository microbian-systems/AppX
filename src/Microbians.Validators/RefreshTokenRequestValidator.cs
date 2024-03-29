using Microbians.Models;
using Microbians.Validators.Extensions;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace Microbians.Validators
{
    public class RefreshTokenRequestValidator : BaseModelValidator<RefreshTokenRequest>
    {
        public RefreshTokenRequestValidator(IMemoryCache cache, ILogger<BaseModelValidator<RefreshTokenRequest>> log) 
            : base(cache, log)
        {
            RuleFor(x => x.Token).NotNullOrEmpty();
            RuleFor(x => x.RefreshToken).NotNullOrEmpty();
        }
    }
}