using SimpleMusicStore.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SimpleMusicStore.Models.Binding
{
    public class FilterCriterias
    {
        public FilterCriterias()
        {
            Genres = new List<string>();
            Formats = new List<string>();
            Sort = SortTypes.Popularity;
            MustBeInStock = false;
        }
        public IEnumerable<string> Genres { get; set; }
        public IEnumerable<string> Formats { get; set; }
        //TODO doesn't return the specified error message, but the default one O_O
        [EnumDataType(typeof(SortTypes), ErrorMessage = ErrorMessages.UNSUPPORTED_SORT)]
        public SortTypes Sort { get; set; }
        public bool MustBeInStock { get; set; }
    }
}
