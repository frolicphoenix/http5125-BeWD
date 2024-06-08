using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign1_N01652955.Controllers
{
    public class HostingCostController : ApiController
    {
        /// <summary>
        /// Calculating the price for web hosting and maintenance with HST
        /// </summary>
        /// <param name="id"> the number of days, elapsed since the hosting</param>
        /// <returns>"{number of fortnight elapsed} fortnights at $5.50/FN = {base price}"
        ///          "HST 13% = {caclulated HST per base value}"
        ///          "Total = {total price with hst}"
        /// </returns>
        /// <example>
        /// GET localhost/api/HostingCost/0 => "1 fortnights at 5.5/FN = 5.5CAD, HST 13% = 0.715CAD, Total = 6.215CAD"
        /// </example>
        /// <example>
        /// GET localhost/api/HostingCost/14 => "2 fortnights at 5.5/FN = 11CAD, HST 13% = 1.43CAD, Total = 12.43CAD"
        /// </example> 
        /// <example>
        /// GET localhost/api/HostingCost/15 => "2 fortnights at 5.5/FN = 11CAD, HST 13% = 1.43CAD, Total = 12.43CAD"
        /// </example>
        /// <example>
        /// GET localhost/api/HostingCost/21 => "2 fortnights at 5.5/FN = 11CAD, HST 13% = 1.43CAD, Total = 12.43CAD"
        /// </example>
        /// <example>
        /// GET localhost/api/HostingCost/28 => "3 fortnights at 5.5/FN = 16.5CAD, HST 13% = 2.145CAD, Total = 18.645CAD"
        /// </example>

        [HttpGet]
        [Route("api/HostingCost/{id}")]
        public string hostingCost(int id)
        {
            //initialize the variables and values
            //Used double because of decimal values
            int fortnight = 14;

            const double pricePerFN = 5.50;
            const double hstValue = 0.13;

            //fnElapsed stores the value of number of fortnights elapsed since the beginning of the hosting
            //Eg: if 15 days have passed then 1 complete fortnight is done and [+ 1] is showing the current fortnight which is 2nd (2)
            //so charging for the second fortnite too.
            int fnElapsed = (id / fortnight) + 1;

            //stores base price per fortnight without the tax
            double priceWithoutTax = fnElapsed * pricePerFN;

            //stores total hst according to the price 
            // in this case, 13% of the base price
            double calcHST = priceWithoutTax * hstValue;

            //stores total price with HST
            double total = priceWithoutTax + calcHST;


            string outPut = (fnElapsed + " fortnights at " + pricePerFN +"/FN = " + priceWithoutTax + "CAD," + 
                            " HST 13% = " + calcHST + "CAD," +
                            " Total = " + total + "CAD");

            return outPut;

        }
    }
}
