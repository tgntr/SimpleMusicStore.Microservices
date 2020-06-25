using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Contracts.Auth
{
    public interface IClaimAccessor
    {
        int Id { get; }
    }
}
