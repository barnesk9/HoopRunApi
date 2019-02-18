using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoopRunAPI.Models
{
    public class Player: Person
    {
        public ICollection<PlayerRun> PlayerRuns { get; set; }
    }
}
