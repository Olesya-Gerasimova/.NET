using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hw9.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace hw9.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Result { get; set; }

        public void OnGet(string expression)
        {

        }
    }
}