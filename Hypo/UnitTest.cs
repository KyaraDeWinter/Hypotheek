using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Hypo;

[TestClass]
public class UnitTest
{
    [TestMethod]
    public void ReturnJaarInkomenTest()
    {
        Assert.AreEqual(61200, Program.ReturnJaarinkomen(2500, 2600));
    }

    [TestMethod]
    public void ReturnMaximaalHypotheek()
    {
        Assert.AreEqual(195075, Program.ReturnMaximaleHypotheek(61200, true));
        Assert.AreEqual(260100, Program.ReturnMaximaleHypotheek(61200, false));
    }

    [TestMethod]
    public void ReturnRentePercentage()
    {
        Assert.AreEqual(5, Program.ReturnRentePercentage(30));
    }
}
