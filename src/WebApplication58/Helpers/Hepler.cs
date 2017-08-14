using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication58.Helpers
{
    public static class Hepler
    {
        public static void GenerateModelState(DateTime? date, string accounts, short groupID, ModelStateDictionary ModelState)
        {
            IEnumerable<int> acc = null;

            if (accounts == null || string.IsNullOrEmpty(accounts.Trim()))
                ModelState.AddModelError("accounts problem", "must add accounts");

            else
                try
                {
                    acc = accounts.Split(',').Select(i => int.Parse(i));
                }
                catch (Exception)
                {
                    ModelState.AddModelError("accounts problem", "illegal accounts format");
                }



            if (acc != null)
            {
                var negative = acc.Any(i => 0 - i >= 0);
                if (negative) ModelState.AddModelError("accounts problem", "negative accounts not allowed");
            }


            if (date == null)
                ModelState.AddModelError("date problem", "illegal date");

            if (0 - groupID >= 0)
                ModelState.AddModelError("groupID problem", "illegal groupID");
        }
    }
}
