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
    public class LabelRepository : DbRepository<Label>, ILabelRepository
    {
        public LabelRepository(SimpleMusicStoreDbContext db, IMapper mapper)
            :base(db, mapper)
        {
        }

        public async Task Add(LabelInfo label)
        {
            if (!await Exists(label.Id))
            {
                await _set.AddAsync(_mapper.Map<Label>(label));
            }
        }

        public Task<bool> Exists(int id)
        {
            return _set.AnyAsync(l => l.Id == id);
        }

        public async Task<LabelView> Find(int id)
        {
            var label = await _set.FindAsync(id);
            ValidateThatLabelExists(label);
            return LabelAsDto(label);
        }

        private LabelView LabelAsDto(Label label)
        {
            var labelDto = _mapper.Map<LabelView>(label);
            labelDto.Records = labelDto.Records.OrderByDescending(r => r.Year);
            return labelDto;
        }

        public IEnumerable<SearchResult> FindAll(string searchTerm)
        {
            return ((IEnumerable<Label>)_set)
                .Search(searchTerm)
                .Select(_mapper.Map<SearchResult>);
        }

        private void ValidateThatLabelExists(Label label)
        {
            if (label == null)
                throw new ArgumentException(ErrorMessages.INVALID_LABEL);
        }
    }
}
