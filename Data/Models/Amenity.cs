namespace VillaBNB.Data.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int VillaId { get; set; }

        public virtual Villa Villa { get; set; }
    }
}