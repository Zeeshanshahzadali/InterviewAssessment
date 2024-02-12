namespace InterviewTask.Models
{
    public class ItemDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string VariationName { get; set; }
        public int CategoryID { get; set; }
        public decimal Price { get; set; }
        public decimal DeliveryPrice { get; set; }
        public decimal PickUpPrice { get; set; }
        public decimal DineInPrice { get; set; }
        public string Image { get; set; }
    }
}
