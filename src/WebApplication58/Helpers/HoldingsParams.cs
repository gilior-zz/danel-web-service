using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication58.Helpers
{
    public class HoldingsParams
    {
        public DateTime dateFrom { get; set; } = DateTime.Now;
        public DateTime dateTo { get; set; } = DateTime.Now;

        public string entities { get; set; } = "";
        public Int16 entitiesType { get; set; } = 0;
        public Int16 groupID { get; set; } = 0;


    }
}
