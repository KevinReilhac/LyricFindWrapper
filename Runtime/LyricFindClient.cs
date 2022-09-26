using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;

using Kebab.LyricFindAPIWrapper.Utils;

namespace Kebab.LyricFindAPIWrapper
{
    public class LyricFindClient
    {
        private string searchKey = null;
        private string staticDisplayKey = null;
        private string syncDisplayKey = null;
        private string metadataKey = null;
        private HttpClient client = null;

        public LyricFindClient(string searchKey, string staticDisplayKey, string syncDisplayKey, string metadataKey)
        {
            this.searchKey = searchKey;
            this.staticDisplayKey = staticDisplayKey;
            this.metadataKey = metadataKey;
            this.syncDisplayKey = syncDisplayKey;
            CreateClient();
        }

        private void CreateClient()
        {
            client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64; rv:12.0) Gecko/20100101 Firefox/12.0");
            client.DefaultRequestHeaders.Add("Accept-Language", "en-gb");
            client.DefaultRequestHeaders.Add("Accept", "text/html");
        }

        public async Task<LFSearchResult> Search(LFSearchParameters searchParameters)
        {
            LFUrlRequestStringBuilder url = new LFUrlRequestStringBuilder("https://api.lyricfind.com/search.do");
            url.AddParameter("apikey", searchKey);
            url.AddParametersFromObject(searchParameters);
            url.AddParameter("searchtype", "track");

            HttpResponseMessage responseMessage = await client.GetAsync(url.ToString());

            string stringResult = await responseMessage.Content.ReadAsStringAsync();
            return (JsonUtility.FromJson<LFSearchResult>(stringResult));
        }

        public async Task<LFLyricsResult> GetLyrics(string trackId, LFTrackIDTypes trackIDType)
        {
            LFUrlRequestStringBuilder url = new LFUrlRequestStringBuilder("https://api.lyricfind.com/lyric.do");
            string trackIdString = string.Format("{0}:{1}", trackIDType.ToString(), trackId);

            url.AddParameter("apikey", staticDisplayKey);
            url.AddParameter("trackid", trackIdString);
            url.AddParameter("lrckey", syncDisplayKey);
            url.AddParameter("format", "lrc");

            HttpResponseMessage responseMessage = await client.GetAsync(url.ToString());
            string stringResult = await responseMessage.Content.ReadAsStringAsync();
            return (JsonUtility.FromJson<LFLyricsResult>(stringResult));
        }

        public void Close()
        {
            client.Dispose();
        }
    }
}