using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPizza.Models;
using RazorPagesPizza.Services;

namespace RazorPagesPizza.Pages
{
    public class PizzaModel : PageModel
    {
        [BindProperty]
        public Pizza NewPizza { get; set; }
        public List<Pizza> pizzas;
        
        public string GlutenFreeText(Pizza pizza){
            if(pizza.IsGlutenFree){
                return "Gluten Free";
            }
            return "Not Gluten Free";
        }
        public void OnGet()
        {
            pizzas = PizzaServices.GetAll();
        }
        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            PizzaServices.Add(NewPizza);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id){
            PizzaServices.Delete(id);
            return RedirectToAction("Get");
        }
    }
}
