namespace Aplikacija.Models
{
    public class DeviceService
    {
        public int Id { get; set; }
    

    public bool MozeSeRezervisati(Uredjaj uredjaj, DateTime vrijemeOd, DateTime vrijemeDo, DateTime sada)
        {

            if (vrijemeOd < sada)
            {
                return false;
            }

            return uredjaj.Status != StatusUredjaja.Neispravan;
        }
    } 
}
