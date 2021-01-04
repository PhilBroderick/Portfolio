﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Portfolio.Models.Content;

namespace Portfolio.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public static IndexContent Content;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            Content = new IndexContent(
                "Hi, I'm Phil Broderick",
                "Full stack developer specialising in Azure and DevOps practices",
                "https://pbportfolio.blob.core.windows.net/images/photo-1600267185393-e158a98703de.jpg");
        }

        public void OnGet()
        {
        }
    }
}