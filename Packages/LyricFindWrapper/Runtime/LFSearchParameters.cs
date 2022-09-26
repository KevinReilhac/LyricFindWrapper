namespace Kebab.LyricFindAPIWrapper
{
    public class LFSearchParameters : LFRequestParameters
    {
        public string artist = null;
        public string album = null;
        public string track = null;
        public string lyrics = null;
        public string meta = null;
        public string all = null;
        public string alltracks = null;
        public int? offset = null;
        public int? limit = null;
        public string displayKey = null;
    }
}
