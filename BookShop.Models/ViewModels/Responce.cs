namespace BookShop.Models.ViewModels
{
    public class Responce<T> where T : class
    {
        public List<T> values { get; set; } = new List<T>();
        public int CurruntPage { get; set; }
        public int Pages { get; set; }
    }
}
