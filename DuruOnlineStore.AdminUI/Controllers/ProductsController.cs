﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DuruOnlineStore.Data.Context;
using DuruOnlineStore.Data.Entities;
using DuruOnlineStore.AdminUI.Models;
using DuruOnlineStore.Common.Configurations;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace DuruOnlineStore.AdminUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly DuruStoreContext _context;

        public ProductsController(DuruStoreContext context)
        {
            _context = context;
        }

        //// GET: Products
        [AllowAnonymous]
        public async Task<IActionResult> Index(ProductSearchModel? model = null)
        {
            model = model ?? new ProductSearchModel();

            var productList = from p in _context.Products
                               .Include(p => p.Campaign)
                               .Include(p => p.Category)
                              where
                                (String.IsNullOrEmpty(model.Name) || p.Name.Contains(model.Name))
                                 && (!model.CategoryId.HasValue || p.CategoryId == model.CategoryId)

                              select new ProductViewModel()
                              {
                                  Id = p.Id,
                                  Name = p.Name,
                                  Price = p.Price,
                                  Description = p.Description,
                                  StockQuantity = p.StockQuantity ?? 0,
                                  Campaign = p.Campaign.Name,
                                  Category = p.Category.Name,
                                  ImageUrl = MyApplicationConfig.ImageBaseUrl + p.ImageName
                              };

            //return View(await productList.OrderBy(x => x.Category).ToListAsync());

            var sortedProductList = await productList.OrderBy(x => x.Category).ToListAsync();
            if (model.CategoryId.HasValue)
            {
                var category = await _context.Categories.FindAsync(model.CategoryId);
                var productCountInCategory = await _context.Products.CountAsync(p => p.CategoryId == model.CategoryId);

                if (productCountInCategory == 0)
                {
                    // Kategoride henüz ürün bulunamadı
                    TempData["CategoryMessage"] = $"{category?.Name} kategorisinde henüz ürün bulunmamaktadır.";
                }
            }
            return View(sortedProductList);
        }

        // GET: Products/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Campaign)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Description");
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,StockQuantity,CategoryId,Id")] Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                // ImageName'e benzersiz bir isim vererek çakışmaları önle
                product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                product.AddedDate = DateTime.Now;

                // wwwroot/images/products klasörüne dosyayı kaydet
                var imagePath = Path.Combine(MyApplicationConfig.ImageBaseFolder, product.ImageName);
               
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }

                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Description", product.CampaignId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Description", product.CampaignId);
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Price,StockQuantity,CategoryId,Id")] Product product, IFormFile imageFile)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            try
            {
                // Eğer yeni bir resim dosyası seçilmişse
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Eski resmi sil (varsa)
                    var existingProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if (!string.IsNullOrEmpty(existingProduct.ImageName))
                    {
                        var imagePath = Path.Combine(MyApplicationConfig.ImageBaseFolder, existingProduct.ImageName);
                        if (System.IO.File.Exists(imagePath))
                        {
                            System.IO.File.Delete(imagePath);
                        }
                    }

                    // Yeni resmi kaydet
                    product.ImageName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);

                    var newImagePath = Path.Combine(MyApplicationConfig.ImageBaseFolder, product.ImageName);

                    using (var stream = new FileStream(newImagePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }
                }
                else
                {
                    // Eğer yeni bir resim dosyası seçilmemişse, mevcut resmin adını koru
                    var existingProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    product.ImageName = existingProduct.ImageName;
                }

                // Eğer resim dosyası güncellenmiyorsa, doğrudan güncelleme yapabilirsiniz.
                _context.Update(product);
                await _context.SaveChangesAsync();

                // ModelState temizleniyor
                ModelState.Clear();

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                // Hata işleme
                throw;
            }
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Name,Description,Price,StockQuantity,CategoryId,Id")] Product product)
        //{
        //    if (id != product.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(product);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!ProductExists(product.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    ViewData["CampaignId"] = new SelectList(_context.Campaigns, "Id", "Description", product.CampaignId);
        //    ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);
        //    return View(product);
        //}

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Campaign)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'DuruStoreContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            // İlgili resmi kaldır
            var imagePath = Path.Combine(MyApplicationConfig.ImageBaseFolder, product.ImageName);
            if (System.IO.File.Exists(imagePath))
            {
                System.IO.File.Delete(imagePath);
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
          return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
