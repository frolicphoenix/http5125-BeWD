using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Schema;

namespace Assign1_N01652955.Controllers
{
    public class AddTenController : ApiController
    {
        /// <summary>
        /// Returns 10 more than the integer input 
        /// </summary>
        /// <param name="id">the integer input to get a number</param>
        /// <returns> {id} + 10 </returns>
        /// <example>
        /// GET localhost:xx/api/AddTen/21 => 31
        /// </example>
        /// <example>
        /// GET localhost:xx/api/AddTen/0 => 10
        /// </example>
        /// <example>
        /// GET localhost:xx/api/AddTen/-9 => 1
        /// </example>
        /// <example>
        /// GET localhost:xx/api/AddTen/-16 => -6
        /// </example>

        [HttpGet]
        [Route("api/AddTen/{id}")]
        public int addTen(int id)
        {
            // Total is an integer variable, storing the value of id + 10 (Sum)
            int total = id + 10;
            return total;
        }

    }
}
