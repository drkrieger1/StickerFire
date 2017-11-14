using Microsoft.AspNetCore.Mvc;
using StickerFire.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Controllers
{
    public class CampaignController : Controller
    {
        private readonly StickerFireDbContext _context;

        public CampaignController(StickerFireDbContext context)
        {
            _context = context;
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
