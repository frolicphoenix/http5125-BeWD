using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign1_N01652955.Controllers
{
    public class SquareController : ApiController
    {
        /// <summary>
        /// Returns the square of the integer input 
        /// </summary>
        /// <param name="id">the integer input to get a number</param>
        /// <returns> {id} * {id} </returns>
        /// <example>
        /// GET localhost:xx/api/Square/2 => 4
        /// </example>
        /// <example>
        /// GET localhost:xx/api/Square/-2 => 4
        /// </example>
        /// <example>
        /// GET localhost:xx/api/Square/10 => 100
        /// </example>
        /// <example>
        /// GET localhost:xx/api/Square/12 => 144
        /// </example>

        [HttpGet]
        [Route("api/Square/{id}")]
        public int square(int id)
        {
            // Total is an integer variable, storing the value of id^2 (square)
            int total = (id * id);
            return total;
        }
    }
}
