namespace Kebab.LyricFindAPIWrapper
{
    [System.Serializable]
    public class LFResponseStatus
    {
        public int code;
        public string description;
        public string message;
    }

    [System.Serializable]
    public class LFResponse
    {
        public LFResponseStatus response;
    }
}