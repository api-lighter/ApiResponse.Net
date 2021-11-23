using ApiResponse.Common;
using Moq;
using NUnit.Framework;
using System;

namespace Tests.ApiResponse.Common
{
    [TestFixture]
    public class ValueResultTests
    {
        class SampleClass
        {
        }

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void CreateOkValueResultInstance()
        {
            Assert.IsTrue(ValueResult<SampleClass>.Ok(default).IsSuccess);
        }

        [Test]
        public void CreateFailResultInstance()
        {
            Assert.IsFalse(ValueResult<SampleClass>.Fail().IsSuccess);
        }

        [Test]
        public void CreateFailResultWithNullErrorMessage()
        {
            Assert.Throws<ArgumentNullException>(() => ValueResult<SampleClass>.Fail(ErrorCodes.InternalError, null));
        }
    }
}
