using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication58.Dto;
using WebApplication58.Entities;

namespace WebApplication58.Controllers
{
    [Route("api/holdings_A")]
    public class HoldingsController_A : Controller
    {
        // GET api/holdings_A
        [HttpGet("accountHodlings")]
        public IActionResult GetAccountHodlings([FromQuery] string accounts,
                                               [FromQuery] DateTime date,
                                              [FromQuery] Int16 groupID = 1)
        {
            Holdings holdings = new Holdings();

            for (int i = 0; i < 20; i++)
            {
                Holding h = new Holding();
                h.SecurityName = i.ToString();
                h.SecurityID = new Random().Next();
                h.SecurityQuantity = new Random().Next(1000);
                h.SecurityRate = new Random().Next(1000);
                h.SecurityAmount = h.SecurityQuantity * h.SecurityRate;
                holdings.Hodldings.Add(h);
            }
            var res = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(holdings.Hodldings);
            return Ok(res);
        }

        // GET api/holdings_A/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/holdings_A
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/holdings_A/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/holdings_A/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
