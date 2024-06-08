using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

namespace Assign1_N01652955.Controllers
{
    public class NumberMachineController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <example>
        /// GET localhost:xx/api/NumberMachine/10 => "The number you entered: 10 --- Add 2 = 12 --- Minus 2 = 8 --- Multiply 2 = 20 --- Divide by 2 = 5"
        /// </example>
        /// <example>
        /// GET localhost:xx/api/NumberMachine/-5 => ""The number you entered: -5 --- Add 2 = -3 --- Minus 2 = -7 --- Multiply 2 = -10 --- Divide by 2 = -2""
        /// </example>
        /// <example>
        /// GET localhost:xx/api/NumberMachine/30 => "The number you entered: 30 --- Add 2 = 32 --- Minus 2 = 28 --- Multiply 2 = 60 --- Divide by 2 = 15"
        /// </example>
        [HttpGet]
        [Route("api/NumberMachine/{id}")]
        public string numberMachine(int id)
        {
            //addition variable stores the added value
            int addition = id + 2;

            //subtraction variable stores the subtracted value
            int subtraction = id - 2;

            //multiplication variable stores the multiplied value
            int multiplication = id * 2;

            //division variable stores the divided value
            int division = id / 2;

            //***NOTE*** Having 2 string variables for the final output is intentional as I was testing 

            //outPut1 and outPut2 store string data and variable data
            string outPut1 = ("The number you entered: " + id + " ---" + " Add 2 = " + addition + " ---" + " Minus 2 = " + subtraction);
            string outPut2 = (outPut1 + " ---" + " Multiply 2 = " + multiplication + " ---" + " Divide by 2 = " + division);

            return outPut2;
        }
    }
}
