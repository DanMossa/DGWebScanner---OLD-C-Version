using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DGWebScanner.Properties;

namespace DGWebScanner
{
    public class GitHubPage
    {
        public string MasterGitHubUsername { get; set; }
        public string CurrentVersionNumber { get; set; }
        public static string VersionNumberHtml { get; set; }
        public static string NewVersionNumber { get; set; }

        public GitHubPage()
        {

        }

        public static string GetRawGitHubText(string masterGitHubUsername, string fileName)
        {
            string rawGitHubVersionUrl = "http://raw.githubusercontent.com/" + masterGitHubUsername + "/DGWebScanner/master/" + fileName;
            using (WebClient client = new WebClient())
            {
                VersionNumberHtml = client.DownloadString(rawGitHubVersionUrl);
            }
            NewVersionNumber = VersionNumberHtml.TrimEnd('\n');
            return NewVersionNumber;
        }
    }
}
