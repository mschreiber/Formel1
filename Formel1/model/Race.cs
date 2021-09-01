using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Formel1.model
{
    public class Race
    {
        public int Id { get; set; }
        public int SeasionId { get; set; }
        public virtual Season Season { get; set; }
        public string Name { get;  set; }
        public System.DateTime Date { get; set; }
        public virtual List<Result> Results { get; set; }

    }
}
