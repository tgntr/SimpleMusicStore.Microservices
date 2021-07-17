using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace SimpleMusicStore.Api.Controllers
{
    public class RecordController : Controller
    {
        private readonly IRecordService _records;
        private readonly IBrowseService _browser;

        public RecordController(IRecordService records, IBrowseService browser)
            : base()
        {
            _records = records;
            _browser = browser;
        }

        [Authorize(Roles = Roles.ADMIN)]
        [HttpPost]
        public Task Add([FromBody] NewRecord record)
        {
            return _records.Add(record);
        }

        public Browse Browse()
        {
            return _browser.GenerateBrowseView();
        }

        [HttpPost]
        public IEnumerable<RecordDetails> Filter(int page, [FromBody] FilterCriterias criterias)
        {
            return _browser.Filter(criterias, page);
        }

        public Task<RecordView> Details(int id)
        {
            return _records.Find(id);
        }

        [HttpPost]
        public Task AddStock(int recordId , [FromBody,Range(1, 100)] int quantity)
        {
            return _records.AddStock(recordId, quantity);
        }
    }
}