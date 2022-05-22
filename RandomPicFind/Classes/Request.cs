using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RandomPicFind.Classes
{
    public class Request
    {
        public void FindGif(string path)
        {
            try
            {
                Rootobject context = null;
                using (WebClient web = new WebClient())
                {
                    web.Encoding = Encoding.UTF8;
                    string response = web.DownloadString(path);
                    context = JsonConvert.DeserializeObject<Rootobject>(response);
                }
            }
            catch
            {
               
            }
        }
    }
}
