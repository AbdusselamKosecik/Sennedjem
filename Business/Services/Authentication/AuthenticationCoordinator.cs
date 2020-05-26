﻿using DataAccess.Entities;
using System;

namespace Business.Services.Authentication
{
    /// <summary>
    /// Çok hızlı yazmak zorunda kaldım, refactor gerekecek.
    /// </summary>
    public class AuthenticationCoordinator : IAuthenticationCoordinator
    {
        private readonly IServiceProvider serviceProvider;

        public AuthenticationCoordinator(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }



        public IAuthenticationProvider SelectProvider(AuthenticationProviderType type)
        {
            switch (type)
            {
                case AuthenticationProviderType.Person:
                    return (IAuthenticationProvider)serviceProvider.GetService(typeof(PersonAuthenticationProvider));
                case AuthenticationProviderType.Agent:
                    return (IAuthenticationProvider)serviceProvider.GetService(typeof(AgentAuthenticationProvider));
                default:
                    throw new ApplicationException($"Authentication provider not found: {type}");
            }
        }
    }

}
