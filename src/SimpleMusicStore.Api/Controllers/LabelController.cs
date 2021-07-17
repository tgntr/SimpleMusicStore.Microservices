using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.View;

namespace SimpleMusicStore.Api.Controllers
{
    public class LabelController : Controller
    {
        private readonly ILabelService _labels;

        public LabelController(ILabelService labels)
            : base()
        {
            _labels = labels;
        }
        public Task<LabelView> Details(int id)
        {
            return _labels.Find(id);
        }
    }
}