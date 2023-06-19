﻿using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using moyo_ismailstarke_backend.Models;

namespace moyo_ismailstarke_backend.Factory
{
    public class AppUserClaimsPrincipalFactory : UserClaimsPrincipalFactory<User, IdentityRole>
    {
        public AppUserClaimsPrincipalFactory(UserManager<User> userManager,
        RoleManager<IdentityRole> roleManager,
        IOptions<IdentityOptions> optionsAccessor)
        : base(userManager, roleManager, optionsAccessor)
        {
        }
    }
}
