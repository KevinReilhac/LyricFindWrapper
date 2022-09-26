using System.Collections.Generic;

namespace Kebab.LyricFindAPIWrapper
{
    [System.Serializable]
    public class LFSearchResult : LFResponse
    {
        public int totalresults;
        public int totalpages;
        public List<LFSearchResultTrack> tracks;
    }
}
