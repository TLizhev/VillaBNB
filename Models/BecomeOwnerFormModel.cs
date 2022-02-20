using System.ComponentModel.DataAnnotations;

namespace VillaBNB.Models
{
    public class BecomeOwnerFormModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
    }
}