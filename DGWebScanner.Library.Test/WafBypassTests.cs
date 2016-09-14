using NUnit.Framework;

namespace DGWebScanner.Library.Test
{
    [TestFixture]
    [Parallelizable]
    class WafBypassTests
    {
        [Test]
        public void ReturnNormalGivenNormalUrl([Values("http://www.royalprogress.com/about.php?id=5",
            "http://www.bertas.com.cn/en/about.php?id=3", "http://www.ro.com/abod=5","http://www.micro-mechanics.com/about.php?id=3",
            "http://interiorsdecor.in/pages.php?id=95","http://www.gruporosul.com/interior.php?id=197")] string inputUrl)
        {
            string outputUrl = SingleQuoteBypass.ReturnCorrectBaseUrLandGetSingleQuoteHtml(inputUrl);
            Assert.AreEqual(inputUrl + "'", outputUrl);
        }

        [Test]
        public void Return11AvailableColumnGivenCertainUrl([Values("http://www.micro-mechanics.com/about.php?id=3",
            "http://interiorsdecor.in/pages.php?id=95")] string givenUrl)
        {
            string beforeUrl = givenUrl.Split('=')[0];
            string afterUrl = givenUrl.Split('=')[1];
            int outputAvailableColumn = OrderbyBypass.GetAvailableColumns(beforeUrl, afterUrl);
            Assert.AreEqual(11, outputAvailableColumn);
        }

        [Test]
        public void Return12AvailableColumnGivenCertainUrl([Values("http://www.bertas.com.cn/en/about.php?id=3")] string givenUrl)
        {
            string beforeUrl = givenUrl.Split('=')[0];
            string afterUrl = givenUrl.Split('=')[1];
            int outputAvailableColumn = OrderbyBypass.GetAvailableColumns(beforeUrl, afterUrl);
            Assert.AreEqual(12, outputAvailableColumn);
        }

        [Test]
        public void Return7AvailableColumnGivenCertainUrl([Values("http://www.royalprogress.com/about.php?id=5")] string givenUrl)
        {
            string beforeUrl = givenUrl.Split('=')[0];
            string afterUrl = givenUrl.Split('=')[1];
            int outputAvailableColumn = OrderbyBypass.GetAvailableColumns(beforeUrl, afterUrl);
            Assert.AreEqual(7, outputAvailableColumn);
        }

        [Test]
        [Ignore("Gotta learn to bypass incapsula or someshit")]
        public void Return3ColumnGivenCertainUrl([Values("http://www.gruporosul.com/interior.php?id=197")] string givenUrl)
        {
            string beforeUrl = givenUrl.Split('=')[0];
            string afterUrl = givenUrl.Split('=')[1];
            int outputAvailableColumn = OrderbyBypass.GetAvailableColumns(beforeUrl, afterUrl);
            Assert.AreEqual(3, outputAvailableColumn);
        }
    }
}
