using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2_N01652955.Controllers
{
    public class CalorieCountController : ApiController
    {
        /// <summary>
        /// Printing out a string to test.
        /// </summary>
        /// <returns> "this is menu" </returns>

        // Added a new page for menu items
        [HttpGet]
        [Route("api/J1/Menu")]
        public string sampleMenu()
        {
            return "this is menu";
        }

        /// <summary>
        /// Calculating the total calories of the meal.
        /// </summary>
        /// <param name="burger"> digit choice of food item burger </param>
        /// <param name="drink"> digit choice of food item drink </param>
        /// <param name="side"> digit choice of food item side </param>
        /// <param name="dessert"> digit choice of food dessert </param>
        /// <returns>
        /// Your total calorie count is {sum of calories of chose food items}
        /// </returns>
        /// <example>
        /// GET localhost:xx/api/J1/Menu/4/4/4/4 => Your total calorie count is 0
        /// </example>
        /// <example>
        /// GET localhost:xx/api/J1/Menu/1/2/3/4 => Your total calorie count is 691
        /// </example>
        /// <example>
        /// GET localhost:xx/api/J1/Menu/2/4/1/3 => Your total calorie count is 606
        /// </example>

        // Taking number input for menu items to calculate total calories
        [HttpGet]
        [Route("api/J1/Menu/{burger}/{drink}/{side}/{dessert}")]
        public string menuList(int burger, int drink, int side, int dessert)
        {

            int burgerCalories = 0;
            int drinkCalories = 0;
            int sideCalories = 0;
            int dessertCalories = 0;

            //BURGER
            if (burger == 1)
            {
                burgerCalories = 461;
            }
            else if (burger == 2)
            {
                burgerCalories = 431;
            }
            else if (burger == 3)
            {
                burgerCalories = 420;
            }

            //DRINK
            if (drink == 1)
            {
                drinkCalories = 130;
            }
            else if (drink == 2)
            {
                drinkCalories = 160;
            }
            else if (drink == 3)
            {
                drinkCalories = 118;
            }

            //SIDE
            if (side == 1)
            {
                sideCalories = 100;
            }
            else if (side == 2)
            {
                sideCalories = 57;
            }
            else if (side == 3)
            {
                sideCalories = 70;
            }

            //DESSERT
            if (dessert == 1)
            {
                dessertCalories = 167;
            }
            else if (dessert == 2)
            {
                dessertCalories = 266;
            }
            else if (dessert == 3)
            {
                dessertCalories = 75;
            }

            int totalCal = burgerCalories + drinkCalories + sideCalories + dessertCalories;
            string totalString = "Your total calorie count is " + totalCal;

            return totalString;

        }
    }
}
