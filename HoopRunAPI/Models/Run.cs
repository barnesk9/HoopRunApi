using System.Collections.Generic;

namespace HoopRunAPI.Models
{
    public class Run
    {
        public virtual int Id { get; set; }

        public decimal ParticipationFee { get; set; }

        public string RunName { get; set; }

        public string Availability { get; set; }

        public string SkillLevel { get; set; }

        public int MinimumAge { get; set; }

        public Gym Gym { get; set; }
        public ICollection<PlayerRun> RunningPlayers { get; set; }
    }
}
