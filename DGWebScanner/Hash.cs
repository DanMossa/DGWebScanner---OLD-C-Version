using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGWebScanner
{
    public class Hash
    {
        public Hash()
        {

        }

        public bool ValidateHash(string inputHash)
        {
            //MD5 = 32
            //SHA1 = 40
            //SHA256 = 64
            Debug.WriteLine(inputHash);
            if (inputHash.Length%4 == 0)
            {
                return true;
            }
            return false;
        }

        public static string GetHashKillerUrl(string inputHash)
        {
            string finishedUrl = "http://hash-killer.com/dict";
            for (int i = 0; i < 4; i++)
            {
                finishedUrl += "/" + inputHash[i];
            }
            return finishedUrl;
        }

        public static string GetHashKillerDecodedHash(string inputHashUrl, string inputOriginalHash)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent",
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string hashKillerHtml = client.DownloadString(inputHashUrl);
                Regex hashMatch = new Regex("^" + inputOriginalHash + "\\s(.*?)$", RegexOptions.Multiline);
                Match decodedHash = hashMatch.Match(hashKillerHtml);
                if (decodedHash.Groups[1].ToString() == string.Empty)
                {
                    return "0";
                }
                return decodedHash.Groups[1].ToString();
            }
        }

        public static string GetNitrxgenDecodedHash(string inputOriginalHash)
        {
            using (WebClient client = new WebClient())
            {
                client.Headers.Add("user-agent",
                    "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string hashKillerHtml = client.DownloadString("http://www.nitrxgen.net/md5db/" + inputOriginalHash);
                if (hashKillerHtml.Length == 0 || hashKillerHtml.Contains("$HEX["))
                {
                    return "0";
                }
                return hashKillerHtml;
            }
        }
    }


}
