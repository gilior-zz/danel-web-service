using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication58.Dto
{

    public class HodldingsDto
    {
        public List<HoldingDto> Hodldings { get; set; }
        public HodldingsDto()
        {
            this.Hodldings = new List<HoldingDto>();
        }
    }
    public class HoldingDto
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Amount { get; set; }
        public double Rate { get; set; }
    }

}
