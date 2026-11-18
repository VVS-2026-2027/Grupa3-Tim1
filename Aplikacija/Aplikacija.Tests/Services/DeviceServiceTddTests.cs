using Aplikacija.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplikacija.Tests.Services;

[TestClass]
[TestCategory("TDD")]
public class DeviceServiceTddTests
{
    private static readonly DateTime Sada = new DateTime(2026, 11, 20, 12, 0, 0);
    private DeviceService _servis = null!;

    [TestInitialize]
    public void Setup()
    {
        _servis = new DeviceService();
    }

    [TestMethod]
    public void MozeSeRezervisati_SlobodanUredjajBuduciTermin_VracaTrue()
    {
        var uredjaj = new Uredjaj { Status = StatusUredjaja.Slobodan };

        var rezultat = _servis.MozeSeRezervisati(uredjaj, Sada.AddHours(2), Sada.AddHours(3), Sada);

        Assert.IsTrue(rezultat);
    }

    [TestMethod]
    public void MozeSeRezervisati_NeispravanUredjaj_VracaFalse()
    {
        var uredjaj = new Uredjaj { Status = StatusUredjaja.Neispravan };

        var rezultat = _servis.MozeSeRezervisati(uredjaj, Sada.AddHours(2), Sada.AddHours(3), Sada);

        Assert.IsFalse(rezultat);
    }

    [TestMethod]
    public void MozeSeRezervisati_TerminUProslosti_VracaFalse()
    {
        var uredjaj = new Uredjaj { Status = StatusUredjaja.Slobodan };

        var rezultat = _servis.MozeSeRezervisati(uredjaj, Sada.AddHours(-2), Sada.AddHours(-1), Sada);

        Assert.IsFalse(rezultat);
    }
}