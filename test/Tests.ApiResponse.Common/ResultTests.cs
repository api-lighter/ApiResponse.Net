using ApiResponse.Net.OperationResult;
using NUnit.Framework;
using System;

namespace Tests.ApiResponse.Net.OperationResult
{
    [TestFixture]
    public class ResultTests
    {
        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void TestCreateOkResultInstance()
        {
            // Act
            var result = Result.Ok();

            // Assert
            Assert.IsTrue(result.IsSuccess);
        }

        [Test]
        public void TestCreateFailResultInstanceWithNoArgs()
        {
            // Act
            var result = Result.Fail();

            // Assert
            Assert.IsFalse(result.IsSuccess);
            Assert.IsNotNull(result.Error);
        }

        [Test]
        public void TestCreateFailResultInstanceWithNullErrorArg()
        {
            // Assert
            Assert.Throws<ArgumentNullException>(() => Result.Fail(null));
        }
    }
}
