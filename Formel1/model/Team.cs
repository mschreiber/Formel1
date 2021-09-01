using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formel1.model
{
    public class Team
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Driver> Drivers { get; set; } = new ObservableCollection<Driver>();

    }
}
