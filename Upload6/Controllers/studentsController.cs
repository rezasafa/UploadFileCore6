using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Upload6.Models;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Hosting.IHostEnvironment;
namespace Upload6
{
    public class studentsController : Controller
    {
        private readonly UploadContext _context;
        private readonly IWebHostEnvironment  _env;

        public studentsController(UploadContext context,IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: students
        public async Task<IActionResult> Index()
        {
            return View(await _context.students.ToListAsync());
        }

        // GET: students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // GET: students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("studentID,name,img")] students stu,IFormFile uf1)
        {
            var myfile = "";
            if (uf1.Length > 0)
            {
                
                var filename = DateTime.Now.ToString("yyyyMMddHHmmss");
                var filePath = Path.Combine(_env.WebRootPath);
                myfile = filePath + @"\up\" + filename;
                
                using (var stream = System.IO.File.Create(myfile))
                {
                    await uf1.CopyToAsync(stream);
                }
            }
            
            stu.img = myfile;
            Console.WriteLine(stu.name);
            Console.WriteLine(stu.img);
            Console.WriteLine(myfile);

            if (ModelState.IsValid)
            {
                _context.Add(stu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(stu);
        }

        // GET: students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("studentID,name,img")] students students)
        {
            if (id != students.studentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!studentsExists(students.studentID))
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
            return View(students);
        }

        // GET: students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.students
                .FirstOrDefaultAsync(m => m.studentID == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var students = await _context.students.FindAsync(id);
            _context.students.Remove(students);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool studentsExists(int id)
        {
            return _context.students.Any(e => e.studentID == id);
        }
    }
}
