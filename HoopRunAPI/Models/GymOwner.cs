using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoopRunAPI.Models
{
    public class GymOwner:Person
    {
        public List<Gym> GymList { get; set; }
    }
}
