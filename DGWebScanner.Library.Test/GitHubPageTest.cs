using System.Net;
using DGWebScanner.Properties;
using NUnit.Framework;

namespace DGWebScanner.Library.Test
{
    [TestFixture]
    class GitHubPageTest
    {
        [Test]
        public void ReturnVersionWith4DecimalPoints()
        {
            //Arrange
            GitHubPage updater = new GitHubPage
            {
                MasterGitHubUsername = "Dgameman1",
                CurrentVersionNumber = Settings.Default["version"].ToString()
            };
            //Act
            string output = GitHubPage.GetRawGitHubText(updater.MasterGitHubUsername, "version.txt");
            //Assert
            Assert.AreEqual(updater.CurrentVersionNumber, output);
        }
    }
}
