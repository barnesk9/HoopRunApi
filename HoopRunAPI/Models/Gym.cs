using System.ComponentModel.DataAnnotations;

namespace HoopRunAPI.Models
{
    public class Gym
    {
        public virtual int Id { get; set; }

        [Display(Name = "Gym Name")]
        [Required]
        [DataType(DataType.Text)]
        public virtual string Name { get; set; }

        [Display(Name = "Line 1")]
        [Required]
        [DataType(DataType.Text)]
        public virtual string AddressLine1 { get; set; }

        [Display(Name = "Address Line 2")]
        [Required]
        [DataType(DataType.Text)]
        public virtual string AddressLine2 { get; set; }

        [Display(Name = "City")]
        [Required]
        [DataType(DataType.Text)]
        public virtual string City { get; set; }

        [Display(Name = "State")]
        [Required]
        [DataType(DataType.Text)]
        public virtual string State { get; set; }

        [Display(Name = "Zip Code")]
        [Required]
        [DataType(DataType.PostalCode)]
        public virtual string ZipCode { get; set; }

        public virtual string Coordinates { get; set; }

    }
}
