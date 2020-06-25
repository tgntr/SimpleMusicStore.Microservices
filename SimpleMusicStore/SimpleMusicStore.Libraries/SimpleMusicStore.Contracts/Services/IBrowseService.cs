using SimpleMusicStore.Models.Binding;
using SimpleMusicStore.Models.View;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleMusicStore.Contracts.Services
{
    public interface IBrowseService
    {
        Browse GenerateBrowseView();
        IEnumerable<RecordDetails> Filter(FilterCriterias criterias, int page);
		IEnumerable<SearchResult> Search(string searchTerm);
    }
}
