namespace CumbinaTelefonaraWebAPI.Models
{
    public class Phone : Product
    {
        public override string Type
        {
            get { return "Phone"; }
            set { /* do nothing */}
        }
        public int Memory { get; set; }
        public string Color { get; set; } = string.Empty;
        public int BatteryLife { get; set; }
    }
}
