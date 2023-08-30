namespace First_MVC.Models
{
    public class ProuctList
    {
        public static List<Prouduct> Products { get; set; }
        static ProuctList()
        {
            Products = new List<Prouduct>();
            Products.Add(new Prouduct() { Id = 1, Name = "Phone1", Price = 1000, Image = "1.png" });
            Products.Add(new Prouduct() { Id = 2, Name = "Phone2", Price = 1500, Image = "2.png" });
            Products.Add(new Prouduct() { Id = 3, Name = "Phone3", Price = 2000, Image = "3.png" });
        }
    }
}
