using System;
using System.Linq;
using DotNetUtils;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class HashUtilTest
    {
        private string _password;
        private string _wrongPassword;
        private string _passwordHashMD5;
        private string _passwordHashSha1;
        private string _passwordHashSha256;
        private string _passwordHashSha384;
        private string _passwordHashSha512;
        private string _passwordHashMD5WithSalt;
        private string _passwordHashSha1WithSalt;
        private string _passwordHashSha256WithSalt;
        private string _passwordHashSha384WithSalt;
        private string _passwordHashSha512WithSalt;

        [SetUp]
        public void SetUp()
        {
            _password = "myP@5sw0rd"; // original password
            _wrongPassword = "password";
            _passwordHashMD5 =
                HashUtil.ComputeHash(_password, HashingAlgorithm.MD5, null);
            _passwordHashSha1 =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA1, null);
            _passwordHashSha256 =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA256, null);
            _passwordHashSha384 =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA384, null);
            _passwordHashSha512 =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA512, null);
            _passwordHashMD5WithSalt =
                HashUtil.ComputeHash(_password, HashingAlgorithm.MD5, SecurityUtil.RandomSalt(4));
            _passwordHashSha1WithSalt =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA1, SecurityUtil.RandomSalt(8));
            _passwordHashSha256WithSalt =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA256, SecurityUtil.RandomSalt(16));
            _passwordHashSha384WithSalt =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA384, SecurityUtil.RandomSalt(32));
            _passwordHashSha512WithSalt =
                HashUtil.ComputeHash(_password, HashingAlgorithm.SHA512, SecurityUtil.RandomSalt(64));
        }

        [Test]
        public void DifferentHashAlgoritmsGiveUniqueHashes()
        {
            var passwords = new[]
                                {
                                    _passwordHashMD5,
                                    _passwordHashSha1,
                                    _passwordHashSha256,
                                    _passwordHashSha384,
                                    _passwordHashSha512

                                };

            int uniquePasswords = passwords.Distinct().Count();
            Assert.That(uniquePasswords, Is.EqualTo(passwords.Length));

        }
        [Test]
        public void CanMatchMd5()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.MD5, _passwordHashMD5);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha1()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA1, _passwordHashSha1);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha256()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA256, _passwordHashSha256);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha384()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA384, _passwordHashSha384);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha512()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA512, _passwordHashSha512);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchMd5WithSalt()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.MD5, _passwordHashMD5WithSalt);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha1WithSalt()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA1, _passwordHashSha1WithSalt);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha256WithSalt()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA256, _passwordHashSha256WithSalt);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha384WithSalt()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA384, _passwordHashSha384WithSalt);
            Assert.IsTrue(success);
        }

        [Test]
        public void CanMatchSha512WithSalt()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA512, _passwordHashSha512WithSalt);
            Assert.IsTrue(success);
        }

        [Test]
        public void BadMd5()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.MD5, _wrongPassword);
            Assert.IsFalse(success);
        }

        [Test]
        public void BadSha1()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA1, _wrongPassword);
            Assert.IsFalse(success);
        }

        [Test]
        public void BadSha256()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA256, _wrongPassword);
            Assert.IsFalse(success);
        }

        [Test]
        public void BadSha384()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA384, _wrongPassword);
            Assert.IsFalse(success);
        }

        [Test]
        public void BadSha512()
        {
            bool success = HashUtil.VerifyHash(_password, HashingAlgorithm.SHA512, _wrongPassword);
            Assert.IsFalse(success);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AttemptToHashNull()
        {
            HashUtil.VerifyHash(_password, HashingAlgorithm.SHA512, null);

        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AttemptToMatchHashToNull()
        {
            HashUtil.VerifyHash(null, HashingAlgorithm.SHA512, _passwordHashSha512);

        }


    }
}
