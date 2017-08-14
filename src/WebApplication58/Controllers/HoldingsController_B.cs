using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication58.Dto;
using WebApplication58.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using WebApplication58.Helpers;

namespace WebApplication58.Controllers
{
    [Route("api/holdings_B/{accounts}/{date}")]
    public class HoldingsController_B : Controller
    {
        private IHodldingsRepository hodldingsRepository;

        public HoldingsController_B(IHodldingsRepository HodldingsRepository)
        {
            this.hodldingsRepository = HodldingsRepository;
        }


        // api/holdings_B/12/12-12-2012/accountGroupedHoldings/1
        [HttpGet("accountGroupedHoldings/{groupID}")]
        public IActionResult GetGroupedHodlings(DateTime? date = null,
                                              string accounts = "",
                                             Int16 groupID = 0)
        {
            Hepler.GenerateModelState(date, accounts, groupID, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(date.Value, accounts, groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }


        // api/holdings_B/12,13/12-12-2012/accountFlatHoldings
        [HttpGet("accountFlatHoldings")]
        public IActionResult GetFlatHodlings(DateTime? date = null,
                                             string accounts = "",
                                            Int16 groupID = 1)
        {
            Hepler.GenerateModelState(date, accounts, groupID, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(date.Value, accounts, groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }






    }
}
