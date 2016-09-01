using System;
using System.Linq;

namespace DGWebScanner
{
    class WafBypass
    {
        public string NewSingleQuoteUrl;
        public string NewSingleQuoteWebsiteHtml;
        public string[] WafSingleQuote = { "'", "\'", "%27", "%5C%27" };

        public WafBypass()
        {
            NewSingleQuoteUrl = "";
            NewSingleQuoteWebsiteHtml = "nothing";
        }

        public void SetUrl(string givenUrl)
        {
            NewSingleQuoteUrl = givenUrl;
        }
    }

    class SingleQuoteUrlBypass : WafBypass
    {
        public void UpdateUrl()
        {
            NewSingleQuoteUrl = NewSingleQuoteUrl + "'";
        }

        public string[] GetInfo()
        {
            using (WebDownload client = new WebDownload())
            {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                int n = -1;
                do
                {
                    try
                    {
                        if (n >= 0)
                        {
                            NewSingleQuoteUrl = NewSingleQuoteUrl.Replace(WafSingleQuote[n], WafSingleQuote[n + 1]);
                            NewSingleQuoteWebsiteHtml = client.DownloadString(NewSingleQuoteUrl);

                        }
                        else
                        {
                            NewSingleQuoteWebsiteHtml = client.DownloadString(NewSingleQuoteUrl);
                            Console.WriteLine("now:  " + NewSingleQuoteUrl);
                        }
                    }
                    catch (Exception)
                    {
                        n = n + 1;
                    }
                } while (NewSingleQuoteWebsiteHtml == "nothing" && n < WafSingleQuote.Count());
                if (NewSingleQuoteWebsiteHtml == "nothing")
                {
                    string[] results = { "no", "no", "no", "no" };
                    return results;
                }
                else
                {
                    if (n == -1)
                    {
                        string[] results = { NewSingleQuoteUrl, "'", "normal", NewSingleQuoteWebsiteHtml };
                        return results;
                    }
                    else
                    {
                        string[] results = { NewSingleQuoteUrl.Replace("'", WafSingleQuote[n + 1]), WafSingleQuote[n + 1], "bypass", NewSingleQuoteWebsiteHtml };
                        return results;
                    }
                }

            }
        }
    }


}
