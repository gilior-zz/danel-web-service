using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication58.Dto;

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
            HodldingsDto hodldingsDto = new HodldingsDto();

            for (int i = 0; i < 20; i++)
            {
                HoldingDto h = new HoldingDto();
                h.Name = i.ToString();
                h.Number = new Random().Next();
                h.Quantity = new Random().Next();
                h.Rate = new Random().Next();
                h.Amount = h.Quantity * h.Rate;
                hodldingsDto.Hodldings.Add(h);
            }
            return Ok(hodldingsDto.Hodldings);
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
