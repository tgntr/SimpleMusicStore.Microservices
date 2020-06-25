using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleMusicStore.Contracts.Services;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;

namespace SimpleMusicStore.Api.Controllers
{
    [Authorize]
    public class AddressController : Controller
    {
        private readonly IAddressService _addresses;

        public AddressController(IAddressService addresses)
            : base()
        {
            _addresses = addresses;
        }

        [HttpPost]
        public Task Add([FromBody]NewAddress address)
        {
            return _addresses.Add(address);
        }

        [HttpPost]
        public Task Edit([FromBody]AddressEdit address)
        {
            return _addresses.Edit(address);
        }

        public Task Remove(int id)
        {
            return _addresses.Remove(id);
        }

        public IEnumerable<AddressDetails> FindAll()
        {
            return _addresses.FindAll();
        }
    }
}