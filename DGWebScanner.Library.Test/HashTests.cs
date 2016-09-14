using NUnit.Framework;

namespace DGWebScanner.Library.Test
{
    [TestFixture]
    [Parallelizable]
    internal class HashTests
    {
        [Test]
        public void Return0Given4Chars_HashKiller(
            [Values("http://hash-killer.com/dict/a/s/d/a", "http://hash-killer.com/dict/1/2/3/4")] string inputUrl,
            [Values("asda", "1234")] string inputHash,
            [Values("0")] string inputResult)
        {
            //act
            string outputDecoded = Hash.GetHashKillerDecodedHash(inputUrl, inputHash);
            //assert
            Assert.AreEqual(inputResult, outputDecoded);
        }

        [Test]
        public void Return0GivenWrongHash_HashKiller([Values("http://hash-killer.com/dict/6/6/6/6")] string inputUrl,
            [Values("6666008ae0a0087fc5cfbcf075c")] string inputHash,
            [Values("0")] string inputResult)
        {
            //act
            string outputDecoded = Hash.GetHashKillerDecodedHash(inputUrl, inputHash);
            //assert
            Assert.AreEqual(inputResult, outputDecoded);
        }

        [Test]
        public void Return5555Given5555Anything(
            [Values("5555018f5ec415a0c929f7c07ae40b9a", "5555025dd61bd8192c8047cd321059ae")] string input)
        {
            string outputUrl = Hash.GetHashKillerUrl(input);
            Assert.AreEqual("http://hash-killer.com/dict/5/5/5/5", outputUrl);
        }

        [Test]
        public void ReturnDecodedGivenHash_HashKiller([Values("http://hash-killer.com/dict/6/6/6/6")] string inputUrl,
            [Values("6666002fb568ae0a0087fc5cfbcf075c")] string inputHash,
            [Values("rasmusj199213")] string inputResult)
        {
            //act
            string outputDecoded = Hash.GetHashKillerDecodedHash(inputUrl, inputHash);
            //assert
            Assert.AreEqual(inputResult, outputDecoded);
        }

        [Test]
        public void ReturnDecodedGivenHash_Nitrxgen()
        {
            string outputDecoded = Hash.GetNitrxgenDecodedHash("66660279d1166a7a241572cc1e2f0a1d");
            Assert.AreEqual("vatican32", outputDecoded);
        }

        [Test]
        public void ReturnDecodedGivenWrongHash_Nitrxgen(
            [Values("6e2f0a1d", "666602426340d91b6ba53e0667cc151d")] string inputHash)
        {
            string outputDecoded = Hash.GetNitrxgenDecodedHash(inputHash);
            Assert.AreEqual("0", outputDecoded);
        }

        [Test]
        public void ReturnFalseIfEmptyOrRemainder([Values("", "123", "12345")] string input)
        {
            Assert.IsFalse(Hash.ValidateHash(input));
        }

        [Test]
        public void ReturnTrueIfNoRemainder()
        {
            Assert.IsTrue(Hash.ValidateHash("5555018f5ec415a0c929f7c07ae40b9a"));
        }
    }
}