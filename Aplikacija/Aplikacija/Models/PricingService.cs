namespace Aplikacija.Models
{
    public class PricingService
    {
        private const int BrojDecimala = 2;

        public int Id { get; set; }

        public double IzracunajCijenu(DateTime pocetak, DateTime kraj, double cijenaPoSatu)
        {
            ProvjeriUlaz(pocetak, kraj, cijenaPoSatu);

            var sati = (kraj - pocetak).TotalHours;
            return Math.Round(sati * cijenaPoSatu, BrojDecimala);
        }

        private static void ProvjeriUlaz(DateTime pocetak, DateTime kraj, double cijenaPoSatu)
        {
            if (kraj <= pocetak)
            {
                throw new ArgumentException("Kraj mora biti poslije pocetka.");
            }

            if (cijenaPoSatu < 0)
            {
                throw new ArgumentException("Cijena po satu ne smije biti negativna.");
            }
        }
    }
}