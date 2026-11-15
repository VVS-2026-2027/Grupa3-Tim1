using Aplikacija.Models;

namespace Aplikacija.Tests.Helpers;

public static class TestObjekti
{
    public static Uredjaj Uredjaj(string tip, int id = 10) => tip switch
    {
        "PC" => new PC { Id = id, Naziv = "PC sala", Model = "Model A", CijenaPoSatu = 2.5, Status = StatusUredjaja.Zauzet },
        "PlayStation" => new PlayStation { Id = id, Naziv = "PS sala", CijenaPoSatu = 3.5, Status = StatusUredjaja.Zauzet },
        "XBox" => new XBox { Id = id, Naziv = "Xbox sala", CijenaPoSatu = 4.5, Status = StatusUredjaja.Zauzet },
        "Uredjaj" => new Uredjaj { Id = id, Status = StatusUredjaja.Zauzet },
        _ => throw new ArgumentException("Nepoznat tip testnog objekta.", nameof(tip))
    };

    public static double Cijena(Uredjaj uredjaj) => uredjaj switch
    {
        PC pc => pc.CijenaPoSatu,
        PlayStation ps => ps.CijenaPoSatu,
        XBox xbox => xbox.CijenaPoSatu,
        _ => throw new ArgumentException("Osnovni uredjaj nema cijenu.")
    };

    public static Kvar Kvar(int id = 20, int uredjajId = 10,
        StatusKvara status = StatusKvara.Prijavljen) => new()
    {
        Id = id, UredjajId = uredjajId, Opis = "Monitor ne radi", Status = status,
        Uredjaj = null! // Vezu ucitava EF preko postojeceg stranog kljuca.
    };
}
