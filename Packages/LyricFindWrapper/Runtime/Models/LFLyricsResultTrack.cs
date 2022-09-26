using System.Collections.Generic;

namespace Kebab.LyricFindAPIWrapper
{
    [System.Serializable]
    public class LFLyricsResultTrack
    {
        public string lfid;
        public bool instrumental;
        public bool viewable;
        public bool has_lrc;
        public bool lrc_verified;
        public string title;
        public string duration;
        public List<LFArtist> artists;
        public LFArtist artist;
        public string last_update;
        public string lyrics;
        public string lrc_version;
        public List<LFLrcLine> lrc;
        public string copyright;
        public string writer;
    }
}