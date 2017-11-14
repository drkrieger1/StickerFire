using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using StickerFire.Data;
using StickerFire.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StickerFire.Controllers
{
    public class CampaignController : Controller
    {

        private readonly StickerFireDbContext _Context;

        public CampaignController(StickerFireDbContext context)
        {
            _Context = context;
        }

        //Index Gathering all campaigns from the Context
        public async Task<IActionResult> Index()
        {
            return View(await _Context.Campaign.ToListAsync());
        }
        //Get the create View

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,OwnerID,Votes,Views,ImgPath,Description,DenyMessage,Published,Active,Category,Status")]Campaign campaign)
        {
            if (ModelState.IsValid)
            {
                _Context.Add(campaign);
                await _Context.SaveChangesAsync();
                // return RedirectToAction(nameof(Index));
            }
            return CreatedAtAction("Create", new { id = campaign.ID }, campaign);

            //return View(campaign);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campaign = await _Context.Campaign.SingleOrDefaultAsync(c => c.ID == id);

            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id,[Bind("ID,OwnerID,Votes,Views,ImgPath,Description,DenyMessage,Published,Active,Category,Status")]Campaign campaign)
        //{
        //    if(id != campaign.ID)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _Context.Update(campaign);
        //            await _Context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!CampaignExists(campaign.ID))
        //            {

        //            }
        //        }
        //    }
        //}
    }
}
