using System.Diagnostics;
using System.Net;
using System.Text.RegularExpressions;

namespace DGWebScanner
{
    public class Hash
    {

        public static bool ValidateHash(string inputHash)
        {
            //MD5 = 32
            //SHA1 = 40
            //SHA256 = 64
            Debug.WriteLine(inputHash);
            if (inputHash.Length % 4 == 0 && inputHash.Length != 0)
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
            string hashKillerHtml = HelpfulFunctions.GetHtml(inputHashUrl);
            Regex hashMatch = new Regex("^" + inputOriginalHash + "\\s(.*?)$", RegexOptions.Multiline);
            Match decodedHash = hashMatch.Match(hashKillerHtml);
            if (decodedHash.Groups[1].ToString() == string.Empty)
            {
                return "0";
            }
            return decodedHash.Groups[1].ToString();
        }

        public static string GetNitrxgenDecodedHash(string inputOriginalHash)
        {
            string hashKillerHtml = HelpfulFunctions.GetHtml("http://www.nitrxgen.net/md5db/" + inputOriginalHash);
            if (hashKillerHtml.Length == 0 || hashKillerHtml.Contains("$HEX["))
            {
                return "0";
            }
            return hashKillerHtml;
        }
    }


}
