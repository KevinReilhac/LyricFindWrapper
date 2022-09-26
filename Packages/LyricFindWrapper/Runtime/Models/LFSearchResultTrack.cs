using System.Collections.Generic;

namespace Kebab.LyricFindAPIWrapper
{
    [System.Serializable]
    public class LFSearchResultTrack
    {
        public string lfid;
        public bool instrumental;
        public string language;
        public List<string> isrcs;
        public bool viewable;
        public bool has_lrc;
        public bool lrc_verified;
        public string title;
        public string duration;
        public List<LFArtist> artists;
        public LFArtist artist;
        public string last_update;
        public float score;
    }
}
