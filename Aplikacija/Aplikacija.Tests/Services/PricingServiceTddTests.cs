using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aplikacija.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplikacija.Tests.Services;

[TestClass]
[TestCategory("TDD")]
public class PricingServiceTddTests
{
    private static readonly DateTime Pocetak = new DateTime(2026, 11, 17, 10, 0, 0);
    private PricingService _servis = null!;

    [TestInitialize]
    public void Setup()
    {
        _servis = new PricingService();
    }

    [TestMethod]
    public void IzracunajCijenu_JedanSat_VracaCijenuPoSatu()
    {
        var rezultat = _servis.IzracunajCijenu(Pocetak, Pocetak.AddHours(1), 5.0);

        Assert.AreEqual(5.0, rezultat, 0.001);
    }

    [TestMethod]
    [DataRow(2, 5.0, 10.0)]
    [DataRow(3, 4.0, 12.0)]
    [DataRow(10, 2.5, 25.0)]
    public void IzracunajCijenu_ViseSati_VracaSatiPutaCijena(int sati, double cijena, double ocekivano)
    {
        var rezultat = _servis.IzracunajCijenu(Pocetak, Pocetak.AddHours(sati), cijena);

        Assert.AreEqual(ocekivano, rezultat, 0.001);
    }


    [TestMethod]
    public void IzracunajCijenu_DvadesetMinuta_ZaokruzujeNaDvijeDecimale()
    {
        var rezultat = _servis.IzracunajCijenu(Pocetak, Pocetak.AddMinutes(20), 5.0);

        Assert.AreEqual(1.67, rezultat, 0.001);
    }


    [TestMethod]
    [DataRow(0)]
    [DataRow(-30)]
    public void IzracunajCijenu_KrajNijePoslijePocetka_BacaArgumentException(int minuta)
    {
        Assert.ThrowsException<ArgumentException>(
            () => _servis.IzracunajCijenu(Pocetak, Pocetak.AddMinutes(minuta), 5.0));
    }
}