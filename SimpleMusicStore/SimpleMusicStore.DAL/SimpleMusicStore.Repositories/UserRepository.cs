using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.User.Data;

using SimpleMusicStore.Entities;
using SimpleMusicStore.Models;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class UserRepository : IUserRepository
    {
        private SimpleMusicStoreUserDataContext _db;
        private readonly IMapper _mapper;

        public UserRepository(SimpleMusicStoreUserDataContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }
        public Task SaveChanges()
        {
            return _db.SaveChangesAsync();
        }
        public async Task<UserDetails> Find(int id)
        {
            var user = await _db.Users.FindAsync(id);
            ValidateThatUserExists(user);
            return _mapper.Map<UserDetails>(user);
        }

        public async Task<UserClaims> Find(string email)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.Email == email);
            ValidateThatUserExists(user);
            return _mapper.Map<UserClaims>(user);
        }

        public ValueTask<EntityEntry<SimpleUser>> Add(UserClaims newUser)
        {
            var user = _mapper.Map<SimpleUser>(newUser);
            AssignToRole(user);
            return _db.Users.AddAsync(user);
        }

        private void AssignToRole(SimpleUser user)
        {
            if (_db.Users.Any())
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
            return _db.Users.AnyAsync(u => u.Email == email);
        }

        public IEnumerable<SubscriberDetails> Subscribers()
        {
            return _db.Users.Where(u => u.IsSubscribed).Select(_mapper.Map<SubscriberDetails>);
        }

        private void ValidateThatUserExists(SimpleUser user)
        {
            if (user == null)
                throw new ArgumentException(ErrorMessages.INVALID_USER);
        }
    }
}
