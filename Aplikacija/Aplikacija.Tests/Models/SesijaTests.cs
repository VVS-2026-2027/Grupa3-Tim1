using Aplikacija.Models;
using Aplikacija.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ComponentModel.DataAnnotations;

namespace Aplikacija.Tests.Models;

[TestClass]
[TestCategory("Model")]
public class SesijaTests
{
    private Sesija _sesija = null!;

    [TestInitialize]
    public void Setup()
    {
        _sesija = new Sesija
        {
            Id = 7,
            VrijemePocetka = new DateTime(2026, 11, 15, 10, 0, 0),
            Status = StatusSesije.Pauzirana
        };
    }

    [TestMethod]
    public void GetId_PostavljenId_VracaId()
    {
        Assert.AreEqual(7, _sesija.GetId());
    }

    [TestMethod]
    public void GetVrijemePocetka_PostavljenoVrijeme_VracaVrijeme()
    {
        Assert.AreEqual(new DateTime(2026, 11, 15, 10, 0, 0), _sesija.GetVrijemePocetka());
    }

    [TestMethod]
    public void GetStatus_PostavljenStatus_VracaStatus()
    {
        Assert.AreEqual(StatusSesije.Pauzirana, _sesija.GetStatus());
    }

    [TestMethod]
    public void NovaSesija_PodrazumijevaneVrijednosti_StatusJeAktivnaIGostNijeAnoniman()
    {
        var nova = new Sesija();

        Assert.AreEqual(StatusSesije.Aktivna, nova.Status);
        Assert.IsFalse(nova.AnonimniGost);
        Assert.IsNull(nova.KorisnikId);
    }

    [TestMethod]
    [DynamicData(nameof(Osoba3Data.ValidacijaSesijeJson), typeof(Osoba3Data), DynamicDataSourceType.Method)]
    public void Validacija_RazliciteGraniceVremena_VracaOcekivaniBrojGresaka(DateTime pocetak, DateTime kraj, int ocekivanoGresaka)
    {
        var sesija = new Sesija { VrijemePocetka = pocetak, VrijemeZavrsetka = kraj };
        var greske = new List<ValidationResult>();

        Validator.TryValidateObject(sesija, new ValidationContext(sesija), greske, true);

        Assert.AreEqual(ocekivanoGresaka, greske.Count);
    }
}
