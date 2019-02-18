using System.ComponentModel.DataAnnotations;

namespace HoopRunAPI.Models
{
    public class Address
    {
        public virtual int Id { get; set; }

        [Display(Name = "Address Line 1")]
        [Required(ErrorMessage = "Street Line 1 is required")]
        [StringLength(50)]
        public virtual string Line1 { get; set; }

        [Display(Name = "Address Line 2")]
        [StringLength(50)]
        public virtual string Line2 { get; set; }

        [Display(Name = "City")]
        [Required(ErrorMessage = "City is required")]
        [StringLength(50)]
        public virtual string City { get; set; }

        [Display(Name = "State")]
        [Required(ErrorMessage = "State is required")]
        [StringLength(50)]
        public virtual string state { get; set; }

        [Display(Name = "Zip Code")]
        [Required(ErrorMessage = "Zip code is required")]
        [StringLength(5)]
        public virtual string ZipCode { get; set; }
    }
}
