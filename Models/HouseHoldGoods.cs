namespace SafeChest.Models
{
    public class HouseHoldGoods
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Value { get; set; }
        public string Picture { get; set; }
        public DateTime Date { get; set; }

        public HouseHoldGoods()
        {
            
        }
    }
}
