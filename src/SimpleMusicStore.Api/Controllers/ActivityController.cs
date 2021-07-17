using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EasyNetQ;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Auth;
using SimpleMusicStore.Models.MessageBus;
using SimpleMusicStore.Models.View;

namespace SimpleMusicStore.Api.Controllers
{
    [Authorize]
    public class ActivityController : Controller
    {
        private readonly IBus _messageBus;
        private readonly IClaimAccessor _currentUserClaims;

        public ActivityController(IBus messageBus, IClaimAccessor currentUserClaims)
            :base()
        {
            _messageBus = messageBus;
            _currentUserClaims = currentUserClaims;
        }
        public IEnumerable<WishDetails> Wishlist(int page)
        {
            var request = new UserActivityRequest(_currentUserClaims.Id, page);
            return _messageBus.Request<UserActivityRequest, IEnumerable<WishDetails>>(request);
        }

        //[Route("dada")]
        public string Testing()
        {
            return "da";
        }

        //public IEnumerable<ArtistFollowDetails> FollowedArtists(int page)
        //{
        //    return _currentUser.FollowedArtistsOrdered(page);
        //}
        //
        //public IEnumerable<LabelFollowDetails> FollowedLabels(int page)
        //{
        //    return _currentUser.FollowedLabelsOrdered(page);
        //}
        //
        //public IEnumerable<OrderDetails> Orders(int page)
        //{
        //    return _currentUser.OrdersOrdered(page);
        //}
    }
}