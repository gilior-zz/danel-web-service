using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication58.Entities
{
    public class Holdings
    {
        public List<Holding> Hodldings { get; set; }
        public Holdings()
        {
            this.Hodldings = new List<Holding>();
        }
    }

    public class Holding
    {
        public int SecurityID { get; set; }
        public string SecurityName { get; set; }
        public double SecurityQuantity { get; set; }
        public double SecurityAmount { get; set; }
        public double SecurityRate { get; set; }
    }
}
