using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts;
using SimpleMusicStore.Extensions;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.MusicLibraries;

namespace SimpleMusicStore.Api.Controllers
{
    [Authorize]
    public class DiscogsController : Controller
    {
        private readonly MusicSource _discogs;

        public DiscogsController(MusicSource discogs)
            :base()
        {
            _discogs = discogs;
        }

        public Task<NewRecord> Find([RegularExpression(DiscogsConstants.DISCOGS_URL_PATTERN)]string url)
        {
            return _discogs.ExtractInformation(url.AsUri());
        }
    }
}