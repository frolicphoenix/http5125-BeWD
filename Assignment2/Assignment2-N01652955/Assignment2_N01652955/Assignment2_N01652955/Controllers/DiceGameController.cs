using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Runtime.Remoting;
using WebGrease.Css.Ast.Selectors;

namespace Assignment2_N01652955.Controllers
{
    public class DiceGameController : ApiController
    {
        /// <summary>
        /// Determining how many ways the dice can roll 10
        /// </summary>
        /// <param name="m"> number of sides of dice 1 </param>
        /// <param name="n"> number of sides of dice 2 </param>
        /// <returns>
        /// There are {number of ways} total ways to get the sum 10.
        /// </returns>
        /// <example>
        /// GET localhost:xx/api/J2/DiceGame/6/8 => There are 5 total ways to get the sum 10.
        /// </example>
        /// /// <example>
        /// GET localhost:xx/api/J2/DiceGame/12/4 => There are 4 total ways to get the sum 10.
        /// </example>
        /// /// <example>
        /// GET localhost:xx/api/J2/DiceGame/3/3 => There are 0 total ways to get the sum 10.
        /// </example>
        /// /// <example>
        /// GET localhost:xx/api/J2/DiceGame/5/5 => There are 1 total ways to get the sum 10.
        /// </example>

        [HttpGet]
        [Route("api/J2/DiceGame/{m}/{n}")]
        public string DiceGame(int m, int n)
        {
            int numOfWays = CountWays(m, n);

            string shortMsg = "There are " + numOfWays + " total ways to get the sum 10. ";

            return shortMsg;

        }
        private int CountWays(int m, int n)
        {
            int count = 0;

            for (int j = 1; j <= n; j++)
            {
                for (int i = 1; i <= m; i++)
                {
                    if (i + j == 10)
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
