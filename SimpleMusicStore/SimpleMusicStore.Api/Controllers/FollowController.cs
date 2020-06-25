using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;

namespace SimpleMusicStore.Api.Controllers
{
    [Authorize]
    public class FollowController : Controller
    {
        private readonly IFollowService _follows;

        public FollowController(IFollowService follows)
            : base()
        {
            _follows = follows;
        }

        public Task AddToWishlist(int id)
        {
            return _follows.AddToWishlist(id);
        }

        public Task RemoveFromWishlist(int id)
        {
            return _follows.RemoveFromWishlist(id);
        }

        public Task FollowArtist(int id)
        {
            return _follows.FollowArtist(id);
        }

        public Task UnfollowArtist(int id)
        {
            return _follows.UnfollowArtist(id);
        }

        public Task FollowLabel(int id)
        {
            return _follows.FollowLabel(id);
        }

        public Task UnfollowLabel(int id)
        {
            return _follows.UnfollowLabel(id);
        }
    }
}