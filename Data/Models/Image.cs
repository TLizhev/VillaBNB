using System.ComponentModel.DataAnnotations;

namespace VillaBNB.Data.Models
{
    public class Image
    {
        [Key]
        public int ImageId { get; set; }

        public string ImageUrl { get; set; }

        public string Extensions { get; set; }

        public int VillaId { get; set; }

        public virtual Villa Villa { get; set; }

    }
}