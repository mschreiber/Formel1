using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Formel1.model
{
    public class Season
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Race> Races { get; set; } = new ObservableCollection<Race>();
    }
}
