using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC005.Models;

namespace MVC005.Controllers
{
    public class TblHanghoasController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly DbShop4TrainingContext _context;

        public TblHanghoasController(DbShop4TrainingContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment= webHostEnvironment;
        }

        // GET: TblHanghoas
        public async Task<IActionResult> Index()
        {
              return _context.TblHanghoas != null ? 
                          View(await _context.TblHanghoas.ToListAsync()) :
                          Problem("Entity set 'DbShop4TrainingContext.TblHanghoas'  is null.");
        }

        // GET: TblHanghoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblHanghoas == null)
            {
                return NotFound();
            }

            var tblHanghoa = await _context.TblHanghoas
                .FirstOrDefaultAsync(m => m.PkIHanghoaId == id);
            if (tblHanghoa == null)
            {
                return NotFound();
            }

            return View(tblHanghoa);
        }

        // GET: TblHanghoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblHanghoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TblHanghoa tblHanghoa, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null && file.Length > 0)
                {
                    string fileExtension = Path.GetExtension(file.FileName).ToLower();
                    if (fileExtension != ".png" && fileExtension != ".jpg")
                    {
                        ModelState.AddModelError(string.Empty, "Vui lòng chỉ chọn tập tin ảnh định dạng PNG hoặc JPG.");
                        return View(tblHanghoa);
                    }

                    string filename = Guid.NewGuid().ToString() + fileExtension;
                    string hanghoaPath = Path.Combine(wwwRootPath, @"images\hanghoa");

                    // Xóa hình ảnh cũ nếu đã có
                    if (!string.IsNullOrEmpty(tblHanghoa.SAnhminhhoa))
                    {
                        string oldImagePath = Path.Combine(wwwRootPath, tblHanghoa.SAnhminhhoa.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Lưu hình ảnh mới
                    string filePath = Path.Combine(hanghoaPath, filename);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }

                    tblHanghoa.SAnhminhhoa = @"\images\hanghoa\" + filename;
                }

                _context.Add(tblHanghoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(tblHanghoa);
        }


        // GET: TblHanghoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblHanghoas == null)
            {
                return NotFound();
            }

            var tblHanghoa = await _context.TblHanghoas.FindAsync(id);
            if (tblHanghoa == null)
            {
                return NotFound();
            }
            return View(tblHanghoa);
        }

        // POST: TblHanghoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PkIHanghoaId,STenhang,FGianiemyet,SDacdiem,SXuatxu,SAnhminhhoa")] TblHanghoa tblHanghoa)
        {
            if (id != tblHanghoa.PkIHanghoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblHanghoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblHanghoaExists(tblHanghoa.PkIHanghoaId))
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
            return View(tblHanghoa);
        }

        // GET: TblHanghoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblHanghoas == null)
            {
                return NotFound();
            }

            var tblHanghoa = await _context.TblHanghoas
                .FirstOrDefaultAsync(m => m.PkIHanghoaId == id);
            if (tblHanghoa == null)
            {
                return NotFound();
            }

            return View(tblHanghoa);
        }

        // POST: TblHanghoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblHanghoas == null)
            {
                return Problem("Entity set 'DbShop4TrainingContext.TblHanghoas'  is null.");
            }
            var tblHanghoa = await _context.TblHanghoas.FindAsync(id);
            var oldImageUrl = Path.Combine(_webHostEnvironment.WebRootPath, tblHanghoa.SAnhminhhoa.TrimStart('\\'));
            if (tblHanghoa != null)
            {
                if (System.IO.File.Exists(oldImageUrl))
                {

                    System.IO.File.Delete(oldImageUrl);

                }
                _context.TblHanghoas.Remove(tblHanghoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblHanghoaExists(int id)
        {
          return (_context.TblHanghoas?.Any(e => e.PkIHanghoaId == id)).GetValueOrDefault();
        }
    }
}
