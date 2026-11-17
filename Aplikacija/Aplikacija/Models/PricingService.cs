namespace Aplikacija.Models
{
    public class PricingService
    {
        public int Id { get; set; }

        public double IzracunajCijenu(DateTime pocetak, DateTime kraj, double cijenaPoSatu)
        {
            if (kraj <= pocetak)
            {
                throw new ArgumentException("Kraj mora biti poslije pocetka.");
            }

            return Math.Round((kraj - pocetak).TotalHours * cijenaPoSatu, 2);
        }
    }
}
