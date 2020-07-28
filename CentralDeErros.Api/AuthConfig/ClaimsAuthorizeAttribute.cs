﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CentralDeErros.Api.AuthConfig
{
    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequirementClaimFilter))
        {
            Arguments = new object[]
            {
                new Claim(claimName, claimValue)
            };
        }
    }
}
