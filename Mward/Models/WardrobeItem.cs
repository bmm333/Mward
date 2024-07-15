namespace Mward.Models
{
    public class WardrobeItem
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LastWorn { get; set; }
        public string LastWashed { get; set; }
        public string Status { get; set; } // Available or Not Available
        public string Preference { get; set; } // Preferred or Less Preferred
    }
}
