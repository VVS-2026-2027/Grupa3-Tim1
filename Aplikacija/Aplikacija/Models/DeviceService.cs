namespace Aplikacija.Models
{
    public class DeviceService
    {
        public int Id { get; set; }
    

        public bool MozeSeRezervisati(Uredjaj uredjaj, DateTime vrijemeOd, DateTime vrijemeDo, DateTime sada)
            {

            ProvjeriInterval(vrijemeOd, vrijemeDo);

            return uredjaj.Status != StatusUredjaja.Neispravan && vrijemeOd >= sada;
        }
        private static void ProvjeriInterval(DateTime vrijemeOd, DateTime vrijemeDo)
        {
            if (vrijemeDo <= vrijemeOd)
            {
                throw new ArgumentException("Kraj mora biti poslije pocetka.");
            }
        }


    } 
}
