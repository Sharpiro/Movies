using System.Net.Http;
using System.Threading.Tasks;

namespace Movies.Core
{
    public class HttpWrapper
    {
        public string Get(string url)
        {
            using (var client = new HttpClient())
            {
                var res = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
                return res;
            }
        }

        public async Task<string> GetASync(string url)
        {
            using (var client = new HttpClient())
            {
                var res = await client.GetAsync(url);
                return res.Content.ReadAsStringAsync().Result;
            }
        }
    }
}
