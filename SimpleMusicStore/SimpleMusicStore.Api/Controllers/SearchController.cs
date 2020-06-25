using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.View;

namespace SimpleMusicStore.Api.Controllers
{
    public class SearchController : Controller
    {
        private readonly IBrowseService _browser;

        public SearchController(IBrowseService browser)
        {
            _browser = browser;
        }

        public IEnumerable<SearchResult> Index([Required, MinLength(1)]string searchTerm)
        {
            return _browser.Search(searchTerm);
        }
    }
}