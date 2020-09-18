using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using OdeToFood.Core;
using OdeToFood.Data;

namespace OdeToFood.Pages.Restaurants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration config;

        public string Message { get; set; }
        private readonly IRestaurantData restaurantData;
        public IEnumerable<Restaurant> Restaurants { get; set; }

        [BindProperty(SupportsGet = true)] // binduje info z requestu automatycznie gdy httpPost inaczej trzeba ustawic ta flge
        public string SearchTerm { get; set; }

        public ListModel(IConfiguration config, IRestaurantData restaurantData)
        {
            this.config = config;
            this.restaurantData = restaurantData;
        }
        public void OnGet(string SearchTerm) //musi sie zgadzac z tym co jest w html input
        {
            //SearchTerm = searchTerm; // Reczny binding - nie trzeba uzywac
            //HttpContext.Request.QueryString. tak mozna sie dostac dowartosci ale to malo wydajne
            Message = config["Message"]; // pobranie wartosci z appsettings.json
            //Message = "Hello World!";
            Restaurants = restaurantData.GetRestaurantsByName(SearchTerm);
         }
    }
}