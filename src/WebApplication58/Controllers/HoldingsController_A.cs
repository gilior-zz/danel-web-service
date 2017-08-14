﻿using System;
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
    [Route("api/holdings_A")]
    public class HoldingsController_A : Controller
    {
        private IHodldingsRepository hodldingsRepository;

        //api/holdings_A/accountHodlings?date=12-12-2012&accounts=3,4&groupID=1
        public HoldingsController_A(IHodldingsRepository HodldingsRepository)
        {
            this.hodldingsRepository = HodldingsRepository;
        }

        [HttpGet("accountHodlings")]
        public IActionResult GetAccountHodlings([FromQuery] DateTime? date = null,
                                               [FromQuery] string accounts = "",
                                              [FromQuery] Int16 groupID = 0)
        {
            Hepler.GenerateModelState(date, accounts, groupID, ModelState);

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var res = this.hodldingsRepository.GetHoldings(date.Value, accounts, groupID);

            var dto = AutoMapper.Mapper.Map<IEnumerable<Entities.Holding>, IEnumerable<Dto.HoldingDto>>(res);

            return Ok(dto);
        }



        // api/holdings_A/accountHodlings/date/12-12-2012/accounts/12,12,12/groupID/1
        [HttpGet("accountHodlings/date/{date}/accounts/{accounts}/groupID/{groupID}")]
        public IActionResult LoadAccountHodlings(DateTime? date = null,
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


    }
}
