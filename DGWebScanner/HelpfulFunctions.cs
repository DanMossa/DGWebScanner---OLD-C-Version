using System;
using System.IO;
using System.Net;
using System.Text;
using DGWebScanner.Properties;

namespace DGWebScanner
{
    class HelpfulFunctions
    {
        private static readonly string[] UserAgents =
        {
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/535.2 (KHTML, like Gecko) Chrome/15.0.874.121 Safari/535.2",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.101 Safari/537.36",
            "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/52.0.2743.116 Safari/537.36 OPR/39.0.2256.71"
        };

        public static string GetHtml(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.CookieContainer = new CookieContainer();
            request.AllowAutoRedirect = true;
            //If internetTimeout is NOT null, request.Timeout = the settings
            //Else, request.Timeout = 5000
            request.Timeout = Settings.Default["internetTimeout"].ToString() != string.Empty
                ? Convert.ToInt32(Settings.Default["internetTimeout"])
                : 10000;
            Random rnd = new Random();
            request.UserAgent = UserAgents[rnd.Next(3)];
            if (Settings.Default["proxyIPSetting"].ToString() != string.Empty &&
                Settings.Default["proxyPortSetting"].ToString() != string.Empty)
            {
                WebProxy myProxy = new WebProxy();
                // ReSharper disable once RedundantToStringCall
                Uri newUri = new Uri("http://" + Settings.Default["proxyIPSetting"].ToString() + ":" +
                                     // ReSharper disable once RedundantToStringCall
                                     Settings.Default["proxyPortSetting"].ToString());
                myProxy.Address = newUri;
                if (Settings.Default["proxyUsernameSetting"].ToString() != string.Empty &&
                    Settings.Default["proxyPasswordSetting"].ToString() != string.Empty)
                {
                    myProxy.Credentials = new NetworkCredential(Settings.Default["proxyUsernameSetting"].ToString(),
                        Settings.Default["proxyPasswordSetting"].ToString());
                }
                request.Proxy = myProxy;
            }
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream receiveStream = response.GetResponseStream();
                StreamReader readStream = null;

                if (response.CharacterSet == null)
                {
                    readStream = new StreamReader(receiveStream);
                }
                else
                {
                    readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                }
                string html = readStream.ReadToEnd();
                response.Close();
                readStream.Close();
                return html;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
