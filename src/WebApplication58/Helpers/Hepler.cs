using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication58.Helpers
{
    public static class Hepler
    {
        public static void GenerateModelState(DateTime? dateFrom, DateTime? dateTo, string entities, Int16 entitiesType, short groupID, ModelStateDictionary ModelState)
        {
            IEnumerable<int> acc = null;

            if (entities == null || string.IsNullOrEmpty(entities.Trim()))
                ModelState.AddModelError("accounts problem", "must add accounts");

            else
                try
                {
                    acc = entities.Split(',').Select(i => int.Parse(i));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("accounts problem", "illegal accounts format");
                }

            if (entitiesType <= 0) ModelState.AddModelError("entitiesType problem", "negative entitiesType not allowed");



            if (acc != null)
            {
                var negative = acc.Any(i => i <= 0);
                if (negative) ModelState.AddModelError("entities problem", "negative accounts not allowed");
            }


            if (dateFrom == null)
                ModelState.AddModelError("dateFrom problem", "illegal date");
            if (dateTo == null)
                ModelState.AddModelError("dateTo problem", "illegal date");

            if (0 - groupID >= 0)
                ModelState.AddModelError("groupID problem", "illegal groupID");
        }
    }
}
