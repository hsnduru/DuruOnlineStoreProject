using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.AdminUI.Models;

namespace DuruOnlineStore.AdminUI.Controllers
{
    public class CampaignsController : Controller
    {
        private readonly DuruStoreContext _context;

        public CampaignsController(DuruStoreContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var campaignViewModels = await _context.Campaigns
                .Select(campaign => new CampaignViewModel
                {
                    Id = campaign.Id,
                    Name = campaign.Name,
                    Description = campaign.Description,
                    IsActive = campaign.IsActive,
                    DiscountRate = campaign.DiscountRate
                })
                .ToListAsync();

            return View(campaignViewModels);
        }

        // GET: Campaigns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Campaigns == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // GET: Campaigns/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campaigns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,IsActive,DiscountRate,Id")] CampaignViewModel campaignViewModel)
        {
            if (ModelState.IsValid)
            {
                var campaign = new Campaign
                {
                    Id = campaignViewModel.Id,
                    Name = campaignViewModel.Name,
                    Description = campaignViewModel.Description,
                    IsActive = campaignViewModel.IsActive,
                    DiscountRate = campaignViewModel.DiscountRate
                };

                _context.Add(campaign);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campaignViewModel);
        }

        // GET: Campaigns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Campaigns == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign == null)
            {
                return NotFound();
            }
            return View(campaign);
        }

        // POST: Campaigns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,IsActive,DiscountRate,Id")] Campaign campaign)
        {
            if (id != campaign.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campaign);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampaignExists(campaign.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(campaign);
        }

        [HttpPost]
        public IActionResult AddProduct(int id, int ProductId)
        {
            var product = _context.Products.Find(ProductId);

            if (product != null)
            {
                product.CampaignId = id;
                _context.SaveChanges();

                TempData["SuccessMessage"] = $"{product.Name} kampanyaya başarıyla eklenmiştir.";
            }

            return RedirectToAction("CampaignProducts", new { id = id });
        }

        public IActionResult RemoveProduct(int id, int ProductId)
        {
            Console.WriteLine($"RemoveProduct Action Called. id: {id}, ProductId: {ProductId}");
            var product = _context.Products.Find(ProductId);

            if (product != null)
            {
                product.CampaignId = null;
                _context.SaveChanges();
            }

            return RedirectToAction("CampaignProducts", new { id = id });
        }

        public IActionResult CampaignProducts(int id)
        {
            var data = _context.Campaigns.Include(it => it.Pruducts).FirstOrDefault(it => it.Id == id);

            return View(data);
        }

        // GET: Campaigns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Campaigns == null)
            {
                return NotFound();
            }

            var campaign = await _context.Campaigns
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campaign == null)
            {
                return NotFound();
            }

            return View(campaign);
        }

        // POST: Campaigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Campaigns == null)
            {
                return Problem("Entity set 'DuruStoreContext.Campaigns'  is null.");
            }
            var campaign = await _context.Campaigns.FindAsync(id);
            if (campaign != null)
            {
                _context.Campaigns.Remove(campaign);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampaignExists(int id)
        {
          return (_context.Campaigns?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
