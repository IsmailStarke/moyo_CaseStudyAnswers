namespace moyo_ismailstarke_backend.ViewModels
{
    public class OrderResponseDTO
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserName { get; set; }
        public string OrderStatus { get; set; }
        public string ProductDescription { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
