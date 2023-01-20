using System;

namespace Application.Common.Interfaces
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        string UserToken { get; }

        string UserName { get; }

        Guid CorporateId { get; }

        string Email { get; }

        string GivenName { get; }
    }
}