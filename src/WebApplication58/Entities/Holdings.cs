using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication58.Entities
{

    public interface IHodldingsRepository
    {
        IEnumerable<Holding> GetHoldings(DateTime dateFrom, DateTime dateTo, string entities, Int16 entitiesType, short groupID);
    }

    public class HodldingsRepository : IHodldingsRepository
    {


        public IEnumerable<Holding> GetHoldings(DateTime dateFrom, DateTime dateTo, string entities, short entitiesType, short groupID)
        {
            Holdings holdings = new Holdings();
            for (int i = 0; i < 20; i++)
            {
                Holding h = new Holding();
                h.HoldingDate = dateTo;
                h.SecurityName = i.ToString();
                h.SecurityID = new Random().Next();
                h.SecurityQuantity = new Random().Next(1000);
                h.SecurityRate = new Random().Next(1000);
                h.SecurityAmount = h.SecurityQuantity * h.SecurityRate;
                h.SecurityGroupId = i % 4;
                holdings.Hodldings.Add(h);
            }

            return holdings.Hodldings;
        }
    }
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
        public int SecurityGroupId { get; set; }
        public DateTime HoldingDate { get; internal set; }
    }
}
