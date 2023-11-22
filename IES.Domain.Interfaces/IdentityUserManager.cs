using IES.Domain.Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IES.Domain.Interfaces
{
    public class IdentityUserManager : UserManager<User>
    {
        public IdentityUserManager(
            IUserStore<User> store,
            IOptions<IdentityOptions> optionsAccessor,
            IPasswordHasher<User> passwordHasher,
            IEnumerable<IUserValidator<User>> userValidators,
            IEnumerable<IPasswordValidator<User>> passwordValidators,
            ILookupNormalizer keyNormalizer,
            IdentityErrorDescriber errorDescriber,
            IServiceProvider service,
            ILogger<UserManager<User>> logger) : base(store, 
                optionsAccessor, 
                passwordHasher, 
                userValidators, 
                passwordValidators,
                keyNormalizer, 
                errorDescriber, 
                service, 
                logger) 
        {

        }
    }
}
