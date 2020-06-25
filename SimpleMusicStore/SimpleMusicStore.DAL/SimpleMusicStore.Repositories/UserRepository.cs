using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class UserRepository : DbRepository<User>, IUserRepository
    {
        public UserRepository(SimpleMusicStoreDbContext db, IMapper mapper)
            :base(db, mapper)
        {
        }
        
        public async Task<UserDetails> Find(int id)
        {
            var user = await _set.FindAsync(id);
            ValidateThatUserExists(user);
            return _mapper.Map<UserDetails>(user);
        }

        public async Task<UserClaims> Find(string email)
        {
            var user = await _set.FirstOrDefaultAsync(u => u.Email == email);
            ValidateThatUserExists(user);
            return _mapper.Map<UserClaims>(user);
        }

        public ValueTask<EntityEntry<User>> Add(UserClaims newUser)
        {
            var user = _mapper.Map<User>(newUser);
            AssignToRole(user);
            return _set.AddAsync(user);
        }

        private void AssignToRole(User user)
        {
            if (_set.Any())
            {
                user.Role = Roles.USER;
            }
            else
            {
                user.Role = Roles.ADMIN;
            }
        }

        public Task<bool> Exists(string email)
        {
            return _set.AnyAsync(u => u.Email == email);
        }

        public IEnumerable<SubscriberDetails> Subscribers()
        {
            return _set.Where(u => u.IsSubscribed).Select(_mapper.Map<SubscriberDetails>);
        }

        private void ValidateThatUserExists(User user)
        {
            if (user == null)
                throw new ArgumentException(ErrorMessages.INVALID_USER);
        }
    }
}
