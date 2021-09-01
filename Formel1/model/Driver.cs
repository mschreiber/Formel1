using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formel1.model
{
    public class Driver
    {
        public int Id { get; set; }

        // One Driver could be in one Team.
        // TODO: It might be that the driver changes after one season to another team
        // so it should be a n:m relationship between team and driver
        // for now it is a 1:n
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
