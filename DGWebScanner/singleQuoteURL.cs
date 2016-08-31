using System;
using System.Linq;

namespace DGWebScanner
{
    class singleQuoteURL
    {
        public singleQuoteURL()
        {
            newSingleQuoteURL = "";
            newSingleQuoteWebsiteHTML = "nothing";
        }

        public void setURL(string singleQuoteURL)
        {
            newSingleQuoteURL = singleQuoteURL + "'";
        }

        public string[] getInfo()
        {
            using (WebDownload client = new WebDownload()) {
                client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                int n = -1;
                do {
                    try {
                        if (n >= 0) {
                            newSingleQuoteURL = newSingleQuoteURL.Replace(wafSingleQuote[n], wafSingleQuote[n + 1]);
                            newSingleQuoteWebsiteHTML = client.DownloadString(newSingleQuoteURL);

                        } else {
                            newSingleQuoteWebsiteHTML = client.DownloadString(newSingleQuoteURL);
                            Console.WriteLine("now:  " + newSingleQuoteURL);
                        }
                    }
                    catch (Exception) {
                        n = n + 1;
                    }
                } while (newSingleQuoteWebsiteHTML == "nothing" && n < wafSingleQuote.Count());
                if (newSingleQuoteWebsiteHTML == "nothing") {
                    string[] results = { "no", "no", "no", "no" };
                    return results;
                } else {
                    if (n == -1) {
                        string[] results = { newSingleQuoteURL, "'", "normal", newSingleQuoteWebsiteHTML };
                        return results;
                    } else {
                        string[] results = { newSingleQuoteURL.Replace("'", wafSingleQuote[n + 1]), wafSingleQuote[n + 1], "bypass", newSingleQuoteWebsiteHTML };
                        return results;
                    }
                }

            }
        }
        private string newSingleQuoteURL;
        private string newSingleQuoteWebsiteHTML;
        private string[] wafSingleQuote = { "'", "\'", "%27", "%5C%27" };
    }
}
