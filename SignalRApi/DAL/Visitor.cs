namespace SignalRApi.DAL
{
    public enum ECity
    {
        Edrine = 1,
        İstbul = 2,
        Ankara = 3,
        Antalya = 4,
        Bursa = 5,

    }
    public class Visitor
    {
        public int VisitorID { get; set; }
        public ECity City { get; set; }
        public int CityVisitorCount { get; set; }
        public DateTime VisitorDate { get; set; }
    }
}
