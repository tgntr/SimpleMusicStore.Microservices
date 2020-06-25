using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SimpleMusicStore.Constants;
using SimpleMusicStore.Contracts.Repositories;
using SimpleMusicStore.Data;
using SimpleMusicStore.Entities;
using SimpleMusicStore.Models.MusicLibraries;
using SimpleMusicStore.Models.View;
using SimpleMusicStore.Sorting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMusicStore.Repositories
{
    public class ArtistRepository : DbRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(SimpleMusicStoreDbContext db, IMapper mapper)
            :base(db, mapper)
        {
        }

        public async Task Add(ArtistInfo artist)
        {
            if (!await Exists(int.Parse(artist.Id)))
            {
                await _set.AddAsync(_mapper.Map<Artist>(artist));
            }
        }

        public Task<bool> Exists(int id)
        {
            return _set.AnyAsync(a => a.Id == id);
        }

        public async Task<ArtistView> Find(int id)
        {
            var artist = await _set.FindAsync(id);
            ValidateThatArtistExists(artist);
            return ArtistAsDto(artist);
        }

        public IEnumerable<SearchResult> FindAll(string searchTerm)
        {
            return ((IEnumerable<Artist>)_set)
                .Search(searchTerm)
                .Select(_mapper.Map<SearchResult>);
        }

        private void ValidateThatArtistExists(Artist artist)
        {
            if (artist == null)
                throw new ArgumentException(ErrorMessages.INVALID_ARTIST);
        }

        private ArtistView ArtistAsDto(Artist artist)
        {
            var artistDto = _mapper.Map<ArtistView>(artist);
            artistDto.Records = artistDto.Records.OrderByDescending(r => r.DateAdded);
            return artistDto;
        }
    }
}
