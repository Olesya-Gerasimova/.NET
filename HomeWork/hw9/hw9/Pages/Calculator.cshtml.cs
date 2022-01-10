using System;
using System.Globalization;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace hw9.Pages
{
    public class Calculator : PageModel
    {
        public IActionResult OnGet(string expression)
        {
            try
            {
                var result = new Infrastructure.Calculator().Calculate(expression);
                return Content(result.ToString(CultureInfo.InvariantCulture));
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}