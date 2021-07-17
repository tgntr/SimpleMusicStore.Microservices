//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using SimpleMusicStore.Contracts.Services;
//using SimpleMusicStore.Models.View;
//
//namespace SimpleMusicStore.Api.Controllers
//{
//    public class HomeController : Controller
//    {
//        private readonly IRecordService _records;
//
//        public HomeController(IRecordService records)
//            :base()
//        {
//            _records = records;
//        }
//        public NewsFeed Index()
//        {
//            return _records.NewsFeed();
//        }
//    }
//}