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
}