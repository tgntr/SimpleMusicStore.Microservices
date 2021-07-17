using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class AddressRepository : DbRepository<Address>, IAddressRepository
    {
        public AddressRepository(SimpleMusicStoreDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public ValueTask<EntityEntry<Address>> Add(NewAddress address)
        {
            return _set.AddAsync(_mapper.Map<Address>(address));
        }

        public async Task Edit(AddressEdit addressDetails)
        {
            var address = await _set.FindAsync(addressDetails.Id);
            ValidateThatAddressExists(address);
            address.Street = addressDetails.Street;
            address.City = addressDetails.City;
            address.Country = addressDetails.Country;
        }

        public Task<bool> Exists(int id, int userId)
        {
            return _set.AnyAsync(a => a.Id == id && a.UserId == userId);
        }

        public IEnumerable<AddressDetails> FindAll(int userId)
        {
            return _set.Where(a => a.UserId == userId && a.IsActive).Select(_mapper.Map<AddressDetails>);
        }

        public async Task Remove(int addressId)
        {
            var address = await _set.FindAsync(addressId);
            ValidateThatAddressExists(address);
            address.IsActive = false;
        }

        private void ValidateThatAddressExists(Address address)
        {
            if (address == null)
                throw new ArgumentException(ErrorMessages.INVALID_ADDRESS);
        }
    }
}
