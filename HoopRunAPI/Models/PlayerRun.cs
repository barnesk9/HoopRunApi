using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HoopRunAPI.Models
{
    public class PlayerRun
    {
        public virtual int Id { get; set; }

        //[ForeignKey("PlayerID")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        //[ForeignKey("RunID")]

        public int RunId { get; set; }
        public Run Run { get; set; }

    }
}
