using System.Net;

namespace DGWebScanner
{
    public class GitHubPage
    {
        public string MasterGitHubUsername { get; set; }
        public string CurrentVersionNumber { get; set; }
        public static string VersionNumberHtml { get; set; }
        public static string NewVersionNumber { get; set; }

        public static string GetRawGitHubText(string masterGitHubUsername, string fileName)
        {
            string rawGitHubVersionUrl = "http://raw.githubusercontent.com/" + masterGitHubUsername + "/DGWebScanner/master/" + fileName;
            VersionNumberHtml = HelpfulFunctions.GetHtml(rawGitHubVersionUrl);
            NewVersionNumber = VersionNumberHtml.TrimEnd('\n');
            return NewVersionNumber;
        }
    }
}
