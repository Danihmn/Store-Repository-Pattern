using Store.Domain.Entities;

namespace Store.Test.Entities;

[TestClass]
public class AddressTest
{
    [TestMethod]
    public void TestPrivateProperties ()
    {
        var address = new Address(
            street: "Avenida Professor Henrique da Motta Fonseca Júnior",
            city: "Porto Ferreira",
            state: "SP",
            zipCode: "13660-136");

        address.UpdateAddress(street: "Onélio Clemonesi");
    }
}