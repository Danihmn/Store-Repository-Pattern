using Store.Domain.ValueObjects;

namespace Store.Test.Domain.ValueObjects;

[TestClass]
public class ZipCodeTests
{
    [TestMethod]
    public void Create_ValidZipCode_ReturnsOk ()
    {
        var result = ZipCode.Create("12345678");

        Assert.IsTrue(result.IsSuccess);
        Assert.AreEqual("12345678", result.Value.Value);
    }

    [TestMethod]
    public void Create_InvalidZipCode_ReturnsError ()
    {
        var result = ZipCode.Create("1234");

        Assert.IsFalse(result.IsSuccess);
        Assert.AreEqual("Invalid zip code", result.Errors[0].Message);
    }
}