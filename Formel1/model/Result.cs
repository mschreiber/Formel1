using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formel1.model
{
    public class Result
    {
        public int Id { get; set; }

        public int Position { get; set; }
        public int RaceId { get; set; }
        public virtual Race Race { get; set; }
        public int DriverId { get; set; }
        public virtual Driver Driver { get; set; }
    }
}
