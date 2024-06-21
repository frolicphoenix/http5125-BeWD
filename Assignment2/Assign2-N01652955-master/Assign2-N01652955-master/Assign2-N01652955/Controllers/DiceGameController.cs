using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Web.Http;
using WebGrease.Css.Ast.Selectors;

namespace Assign2_N01652955.Controllers
{
    public class DiceGameController : ApiController
    {

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
