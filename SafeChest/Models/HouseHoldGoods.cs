namespace SafeChest.Models
{
    public class HouseHoldGoods
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Value { get; set; }
        public string Image { get; set; }
        public DateTime DatePurchased { get; set; }


        public HouseHoldGoods()
        {
            
        }
    }
}
