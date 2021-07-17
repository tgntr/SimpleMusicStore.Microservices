using SimpleMusicStore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleMusicStore.Sorting
{
    public static class RecordFilters
    {
        public static IEnumerable<Record> FilterByGenre(this IEnumerable<Record> records, IEnumerable<string> genres)
        {
            if (genres.Any())
                return records.Where(r => genres.Contains(r.Genre));
            else
                return records;
        }

        public static IEnumerable<Record> FilterByFormat(this IEnumerable<Record> records, IEnumerable<string> formats)
        {
            if (formats.Any())
                return records.Where(r => formats.Contains(r.Format));
            else
                return records;
        }

        public static IEnumerable<Record> Search(this IEnumerable<Record> records, string searchTerm)
        {
            return records
                .Where(r => 
                    r.Title.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase) ||
                    r.Tracklist.Any(t=>t.Title.Split().Any(tt=>tt.StartsWith(searchTerm, StringComparison.InvariantCultureIgnoreCase))));
        }

        public static IEnumerable<Artist> Search(this IEnumerable<Artist> artists, string searchTerm)
        {
            return artists.Where(a => a.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase));
        }

        public static IEnumerable<Label> Search(this IEnumerable<Label> labels, string searchTerm)
        {
            return labels.Where(l => l.Name.Contains(searchTerm, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
