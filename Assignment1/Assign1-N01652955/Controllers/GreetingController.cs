using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assign1_N01652955.Controllers
{
    public class GreetingController : ApiController
    {

        /// <summary>
        /// Using POST to return a string 
        /// </summary>
        /// <returns>"Hello Professor!"</returns>
        /// <example>
        /// curl -d "" http://localhost:xx/api/Greeting => "Hello Professor!"
        /// </example>
        [HttpPost]
        [Route("api/Greeting")]
        public string greeting()
        {
            return "Hello Professor!";
        }

        /// <summary>
        /// Returns a string with the integer value
        /// </summary>
        /// <param name="id">the integer value to ask number of people</param>
        /// <returns>"Greeting to {id} people!"</returns>
        /// <example>
        /// GET localhost:xx/api/Greeting/3 => "Greetings to 3 people!"
        /// </example>
        /// <example>
        /// GET localhost:xx/api/Greeting/6 => "Greetings to 6 people!"
        /// </example>
        /// <example>
        /// GET localhost:xx/api/Greeting/0 => "Greetings to 0 people!"
        /// </example>
        [HttpGet]
        [Route("api/Greeting/{id}")]
        public string greetingPeople(int id)
        {
            //stores a value to return (in this case)
            string greets = "Greetings to " + id + " people!";
            return (greets);
        }
    }
}
